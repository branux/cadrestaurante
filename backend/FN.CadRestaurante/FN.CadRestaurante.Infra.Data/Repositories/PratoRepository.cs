using FN.CadRestaurante.Domain.Contracts.Repositories;
using FN.CadRestaurante.Domain.Entities;
using FN.CadRestaurante.Infra.Data.EF;

namespace FN.CadRestaurante.Infra.Data.Repositories
{
    public class PratoRepository : Repository<Prato>, IPratoRepository
    {
        public PratoRepository(CadRestauranteDataContext context) : base(context)
        {}
    }
}
