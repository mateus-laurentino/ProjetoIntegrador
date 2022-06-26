using Eventos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos.Infra.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnType("int").IsRequired();
            builder.Property(x => x.Usuario).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.Password).HasColumnType("varchar(20)").IsRequired();
            builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Idade).HasColumnType("int").IsRequired();
            builder.Property(x => x.DataNascimento).HasColumnType("datetime").IsRequired();
        }
    }
}
