using Microsoft.Extensions.DependencyInjection;
using TaskBoard.Application.Services;
using TaskBoard.Application.Services.Interfaces;

namespace TaskBoard.Application
{
    public static class ServiceRegistration
    {
        public static void AddCustomApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IProjectService, ProjectService>();
        }
    }
}