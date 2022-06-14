using Eventos.Infra.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Infra.Context
{
    public class EventoContext : DbContext
    {
        public EventoContext(DbContextOptions<EventoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InfoEventoConfiguration());
        }
    }
}
