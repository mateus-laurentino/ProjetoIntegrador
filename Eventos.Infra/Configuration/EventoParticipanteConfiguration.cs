using Eventos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos.Infra.Configuration
{
    public class EventoParticipanteConfiguration : IEntityTypeConfiguration<EventoParticipanteEntity>
    {
        public void Configure(EntityTypeBuilder<EventoParticipanteEntity> builder)
        {
            builder.ToTable("EventoParticipante");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnType("int").IsRequired();
            builder.Property(e => e.IdEvento).HasColumnType("int").IsRequired();
            builder.Property(e => e.IdUsuario).HasColumnType("int").IsRequired();
        }
    }
}
