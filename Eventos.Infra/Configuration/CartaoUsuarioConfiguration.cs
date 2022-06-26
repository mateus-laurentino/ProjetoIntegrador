using Eventos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos.Infra.Configuration
{
    public class CartaoUsuarioConfiguration : IEntityTypeConfiguration<CartaoUsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<CartaoUsuarioEntity> builder)
        {
            builder.ToTable("CartaoUsuario");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnType("int").IsRequired();
            builder.Property(c => c.IdUsuario).HasColumnType("int").IsRequired();
            builder.Property(c => c.NumeroCartao).HasColumnType("varchar()").IsRequired();
            builder.Property(c => c.NomeCartao).HasColumnType("varchar()").IsRequired();
            builder.Property(c => c.Cvc).HasColumnType("int").IsRequired();
            builder.Property(c => c.DataVencimento).HasColumnType("datetime").IsRequired();
        }
    }
}