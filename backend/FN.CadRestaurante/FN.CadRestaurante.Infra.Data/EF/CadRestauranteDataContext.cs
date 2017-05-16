using FN.CadRestaurante.Domain.Entities;
using FN.CadRestaurante.Infra.Data.EF.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace FN.CadRestaurante.Infra.Data.EF
{
    public class CadRestauranteDataContext:DbContext
    {
        public readonly string _conn;

        public CadRestauranteDataContext(IConfigurationRoot config)
        {
            _conn = config["ConnectionStrings:CadRestauranteConn"];

            if (string.IsNullOrWhiteSpace(_conn))
            {
                throw new ArgumentException("ConnectionString não encontrada");
            }

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_conn);

            //Configurar na unha a ConectionString para rodar o Migrations
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CadRestauranteDB;Trusted_Connection=True;MultipleActiveResultSets=true");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new RestauranteMap(modelBuilder.Entity<Restaurante>());
            new PratoMap(modelBuilder.Entity<Prato>());
            new RestaurantePratoMap(modelBuilder.Entity<RestaurantePrato>());
        }
    }
}
