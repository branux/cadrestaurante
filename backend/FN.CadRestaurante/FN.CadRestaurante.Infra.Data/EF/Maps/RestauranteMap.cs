﻿using FN.CadRestaurante.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FN.CadRestaurante.Infra.Data.EF.Maps
{
    public class RestauranteMap
    {
        public RestauranteMap(EntityTypeBuilder<Restaurante> entity)
        {
            entity.ToTable(nameof(Restaurante));
            entity.HasKey(c => c.Id);

            entity.Property(col => col.Id)
                    .HasColumnName("Id")
                    .HasColumnType("uniqueidentifier");


            entity.Property(col => col.Nome)
                   .HasColumnName("Nome")
                   .HasColumnType($"varchar(100)")
                   .IsRequired();

            entity.Property(col => col.DataCadastro)
                   .HasColumnName("DataCadastro")
                   .HasColumnType($"datetime")
                   .IsRequired();

            entity.Ignore(col => col.Notifications);
        }
    }
}
