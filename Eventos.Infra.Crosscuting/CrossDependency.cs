using Eventos.Application.Service;
using Eventos.Domain.Interfaces.IRepository;
using Eventos.Domain.Interfaces.IService;
using Eventos.Infra.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eventos.Infra.Crosscuting
{
    public static class CrossDependency
    {
        public static IServiceCollection ConfiguringDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfiguringRepositories();
            services.ConfiguringServices(configuration);

            return services;
        }

        private static void ConfiguringRepositories(this IServiceCollection service)
        {
            service.AddTransient<IEventoRepository, EventoRepository>();
        }

        private static void ConfiguringServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddTransient<IEventoService, EventoService>();
        }
    }
}
