using FN.CadRestaurante.Domain.Entities;
using FN.CadRestaurante.Domain.Contracts.Repositories;
using FN.CadRestaurante.Infra.Data.EF;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FN.CadRestaurante.Infra.Data.Repositories
{
    public class RestauranteRepository : Repository<Restaurante>, IRestauranteRepository
    {
        public RestauranteRepository(CadRestauranteDataContext context) : base(context)
        { }

        public Restaurante ObterComPratos(Guid id)
        {
            return _context.Set<Restaurante>()
                    //.Include(p => p.RestaurantePrato)
                    .FirstOrDefault(r => r.Id == id);
        }

        public async Task<Restaurante> ObterComPratosAsync(Guid id)
        {
            return await _context.Set<Restaurante>()
                //.Include(p => p.RestaurantePrato)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
