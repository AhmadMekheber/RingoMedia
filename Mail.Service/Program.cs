using Departments.Migrations.Data;
using Mail.Service.Hosts;
using Microsoft.EntityFrameworkCore;
using Departments.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Departments.Migrations"));
});

builder.Services.AddCoreServices();

builder.Services.AddHttpClient();

builder.Services.AddHostedService<MailService>();

var app = builder.Build();

app.Run();
