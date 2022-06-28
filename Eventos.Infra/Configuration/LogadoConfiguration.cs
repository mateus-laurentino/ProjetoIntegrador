using Eventos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos.Infra.Configuration
{
    public class LogadoConfiguration : IEntityTypeConfiguration<LogadoEntity>
    {
        public void Configure(EntityTypeBuilder<LogadoEntity> builder)
        {
            builder.ToTable("Logado");
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id).HasColumnType("int").IsRequired();
            builder.Property(l => l.UsuarioLogado).HasColumnType("bit").IsRequired();
            builder.Property(l => l.Usuario).HasColumnType("varchar(100)").IsRequired();
        }
    }
}
