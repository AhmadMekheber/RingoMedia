using Departments.DAL.IRepository;
using Departments.DAL.Reporsitory;
using Microsoft.Extensions.DependencyInjection;

namespace Departments.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            return services;
        }
    }
}