using System.Net.Sockets;
using Departments.BL.IManager;
using Departments.DAL.IRepository;
using Departments.Model;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Departments.BL.Manager
{
    public class MailsManager : IMailManager
    {
        private const string DEFAULT_SMTP_PORT_SSL = "465";
        private readonly IReminderRepository _reminderRepository;
        private readonly IConfiguration _configuration;
        private SmtpClient? _smtpClient;

        public MailsManager(IReminderRepository reminderRepository, IConfiguration configuration)
        {
            _reminderRepository = reminderRepository;
            _configuration = configuration;
        }

        private MailboxAddress SenderMailboxAddress => new MailboxAddress(_configuration["Mail:SenderName"], _configuration["Mail:SenderMailAddress"]);

        private async Task ConnectSmtpClientIfRequired() 
        {
            if (_smtpClient != null && _smtpClient.IsConnected)
                return;

            _smtpClient = new SmtpClient();

            // Read SMTP details from configuration (appsettings.json)
            var host = _configuration["SMTP:Host"];
            var port = int.Parse(_configuration["SMTP:Port"] ?? DEFAULT_SMTP_PORT_SSL);
            var username = _configuration["SMTP:Username"];
            var password = _configuration["SMTP:Password"];

            // Connect to the server (consider using SSL/TLS for security)
            await _smtpClient.ConnectAsync(host, port, true);

            // Optional: Authenticate with username and password (if required)
            await _smtpClient.AuthenticateAsync(username, password);
        }

        private async Task DisconnectSmtpClient()
        {
            if (_smtpClient != null && _smtpClient.IsConnected)
            {
                // Disconnect from the server
                await _smtpClient.DisconnectAsync(true);

                _smtpClient.Dispose();

                _smtpClient = null;
            }
        }

        public async Task SendMails()
        {
            var reminders = await _reminderRepository.GetRemindersToSend();

            if (reminders.Any() == false)
                return;

            foreach(Reminder reminder in reminders)
            {
                await SendReminder(reminder);
            }

            await DisconnectSmtpClient();

            reminders.ForEach(reminder => reminder.IsMailSent = true);

            if (reminders.Any())
            {
                _reminderRepository.BulkSaveChanges();
            }
        }

        private async Task SendReminder(Reminder reminder)
        {
            try
            {
                var message = new MimeMessage();

                message.From.Add(SenderMailboxAddress);
                message.To.Add(new MailboxAddress(_configuration["Mail:RecieverName"], _configuration["Mail:RecieverAddress"]));
                message.Subject = reminder.Title;

                // Create the email body (text or HTML)
                var bodyBuilder = new BodyBuilder { HtmlBody = reminder.Content };

                message.Body = bodyBuilder.ToMessageBody();

                await ConnectSmtpClientIfRequired();
                // Send the email message
                await _smtpClient.SendAsync(message);

                //Wait 2 seconds after sending each mail because the mail provider would consider this a spam email and it won't be delivered.
                Thread.Sleep(2000);

                Console.WriteLine($"Email sent successfully for reminder: ${reminder.ID}");
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}