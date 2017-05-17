using FN.CadRestaurante.Domain.Contracts.Repositories;
using FN.CadRestaurante.Domain.Entities;
using FN.CadRestaurante.Infra.Data.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FN.CadRestaurante.Infra.Data.Repositories
{
    public class RestauranteRepository : Repository<Restaurante>, IRestauranteRepository
    {
        public RestauranteRepository(CadRestauranteDataContext context) : base(context)
        { }

        public IEnumerable<Restaurante> Obter(string nome)
        {
            return _context.Set<Restaurante>().Where(r=>r.Nome.ToLower().Contains(nome.ToLower()));
        }

        public async Task<IEnumerable<Restaurante>> ObterAsync(string nome)
        {
            return await 
                _context.Set<Restaurante>()
                    .Where(r => r.Nome.ToLower().Contains(nome.ToLower())).ToListAsync();
        }

        //public Restaurante ObterComPratos(Guid id)
        //{
        //    return _context.Set<Restaurante>()
        //            //.Include(p => p.RestaurantePrato)
        //            .FirstOrDefault(r => r.Id == id);
        //}

        //public async Task<Restaurante> ObterComPratosAsync(Guid id)
        //{
        //    return await _context.Set<Restaurante>()
        //        //.Include(p => p.RestaurantePrato)
        //        .FirstOrDefaultAsync(r => r.Id == id);
        //}
    }
}
