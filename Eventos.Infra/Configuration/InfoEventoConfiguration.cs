using Eventos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos.Infra.Configuration
{
    public class InfoEventoConfiguration : IEntityTypeConfiguration<InfoEventoEntity>
    {
        public void Configure(EntityTypeBuilder<InfoEventoEntity> builder)
        {
            builder.ToTable("InfoEvento");
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id).HasColumnType("int").IsRequired();
            builder.Property(i => i.Imagem).HasColumnType("varchar(100)");
            builder.Property(i => i.Nome).HasColumnType("Varchar").HasMaxLength(70).IsRequired();
            builder.Property(i => i.Localidade).HasColumnType("Varchar").HasMaxLength(70).IsRequired();
            builder.Property(i => i.DataEHora).HasColumnType("smalldatetime").IsRequired();
            builder.Property(i => i.QtdeTotalPessoa).HasColumnType("int").IsRequired();
            builder.Property(i => i.Categoria).HasColumnType("smallint").IsRequired();
            builder.Property(i => i.IdUsuario).HasColumnType("int").IsRequired();
        }
    }
}
