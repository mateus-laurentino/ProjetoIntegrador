using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eventos.Infra.Context
{
    public static class ContextConfiguration
    {
        public static IServiceCollection ConfiguringContext(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContextPool<EventoContext>((provider, options) =>
            {
                var conn = configuration.GetConnectionString("Evento");
                options.UseSqlServer(conn);
            });

            return service;
        }
    }
}
