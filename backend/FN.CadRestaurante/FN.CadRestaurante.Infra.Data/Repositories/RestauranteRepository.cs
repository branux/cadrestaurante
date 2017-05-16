using FN.CadRestaurante.Domain.Entities;
using FN.CadRestaurante.Domain.Contracts.Repositories;
using FN.CadRestaurante.Infra.Data.EF;

namespace FN.CadRestaurante.Infra.Data.Repositories
{
    public class RestauranteRepository : Repository<Restaurante>, IRestauranteRepository
    {
        public RestauranteRepository(CadRestauranteDataContext context) : base(context)
        {}
    }
}
