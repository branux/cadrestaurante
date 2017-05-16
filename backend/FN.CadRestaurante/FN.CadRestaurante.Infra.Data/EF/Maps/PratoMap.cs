using FN.CadRestaurante.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FN.CadRestaurante.Infra.Data.EF.Maps
{
    public class PratoMap
    {
        public PratoMap(EntityTypeBuilder<Prato> entity)
        {
            entity.ToTable(nameof(Prato));
            entity.HasKey(c => c.Id);

            entity.Property(col => col.Id)
                    .HasColumnName("Id")
                    .HasColumnType("uniqueidentifier");


            entity.Property(col => col.Nome)
                   .HasColumnName("Nome")
                   .HasColumnType($"varchar(100)")
                   .IsRequired();

            entity.Property(col => col.Preco)
                   .HasColumnName("Preco")
                   .HasColumnType($"money")
                   .IsRequired();

            entity.Property(col => col.DataCadastro)
                   .HasColumnName("DataCadastro")
                   .HasColumnType($"datetime")
                   .IsRequired();

            entity
                .HasOne(p => p.Restaurante)
                .WithMany(b => b.Pratos);

            entity.Ignore(col => col.Notifications);
        }
    }
}
