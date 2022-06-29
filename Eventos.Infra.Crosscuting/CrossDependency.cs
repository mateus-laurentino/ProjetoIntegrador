using Eventos.Application.Service;
using Eventos.Domain.Interfaces.IRepository;
using Eventos.Domain.Interfaces.IRepository.Common;
using Eventos.Domain.Interfaces.IService;
using Eventos.Infra.Repositories;
using Eventos.Infra.Repositories.Common;
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
            services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            return services;
        }

        private static void ConfiguringRepositories(this IServiceCollection service)
        {
            service.AddTransient<ICartaoRepository, CartaoRepository>();
            service.AddTransient<IEventoParticipanteRepository, EventoParticipanteRepository>();
            service.AddTransient<IEventoRepository, EventoRepository>();
            service.AddTransient<ILogadoRepositoty, LogadoRepositoty>();
            service.AddTransient<IUsuarioRepository, UsuarioRepository>();
        }

        private static void ConfiguringServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddTransient<IEventoParticipanteService, EventoParticipanteService>();
            service.AddTransient<IEventoService, EventoService>();
            service.AddTransient<ILogadoService, LogadoService>();
            service.AddTransient<IPerfilService, PerfilService>();
            service.AddTransient<IUsuarioService, UsuarioService>();
        }
    }
}
