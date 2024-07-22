using Departments.BL.IManager;

namespace Mail.Service.Hosts
{
    public class MailService : IHostedService
    {
        const string DEFAULT_SEND_MAIL_INTERVAL = "60";//1 Minute

        private readonly IServiceProvider _serviceProvider;

        private readonly IConfiguration _configuration;

        private Timer? _timer = null;

        private IMailManager? _mailManager = null;

        public MailService(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _configuration = configuration;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(SendMails, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(double.Parse(_configuration["Mail:SendsEvery"] ?? DEFAULT_SEND_MAIL_INTERVAL)));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private async void SendMails(object? state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                _mailManager = scope.ServiceProvider.GetRequiredService<IMailManager>();

                await SendMailsScoped();
            }
        }

        private async Task SendMailsScoped()
        {
            if (_mailManager == null)
                throw new ArgumentNullException();

            await _mailManager.SendMails();
        }
    }
}