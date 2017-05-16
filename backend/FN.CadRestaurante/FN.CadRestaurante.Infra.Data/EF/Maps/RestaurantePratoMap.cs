using FN.CadRestaurante.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/*
 * de acordo com o artigo https://docs.microsoft.com/en-us/ef/core/modeling/relationships
 * many to many não é aceito ainda pelo EF Core
 */

namespace FN.CadRestaurante.Infra.Data.EF.Maps
{
    public class RestaurantePratoMap
    {
        public RestaurantePratoMap(EntityTypeBuilder<RestaurantePrato> entity)
        {
            entity.ToTable(nameof(RestaurantePrato));
            entity.HasKey(c => new { c.RestauranteId, c.PratoId });

            entity.Property(col => col.RestauranteId)
                    .HasColumnName("RestauranteId")
                    .HasColumnType("uniqueidentifier");

            entity.Property(col => col.PratoId)
                    .HasColumnName("PratoId")
                    .HasColumnType("uniqueidentifier");

            entity
                .HasOne(r => r.Restaurante)
                .WithMany(rp => rp.RestaurantePrato)
                .HasForeignKey(pk => pk.RestauranteId);

            entity
                .HasOne(r => r.Prato)
                .WithMany(rp => rp.RestaurantePrato)
                .HasForeignKey(pk => pk.PratoId);



        }
}
}
