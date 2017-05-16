using Microsoft.Extensions.DependencyInjection;
using FN.CadRestaurante.Infra.Data.EF;
using FN.CadRestaurante.Domain.Contracts.Repositories;
using FN.CadRestaurante.Infra.Data.Repositories;
using FN.CadRestaurante.Domain.Contracts.Infra;
using FN.CadRestaurante.Domain.Commands.RestauranteCommand;

namespace FN.CadRestaurante.CrossCutting.IoC
{
    public class IoCConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped(typeof(CadRestauranteDataContext));

            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddTransient(typeof(RestauranteCommandHandler));

            services.AddTransient(typeof(IRestauranteRepository), typeof(RestauranteRepository));
            services.AddTransient(typeof(IPratoRepository), typeof(PratoRepository));
        }
    }
}
