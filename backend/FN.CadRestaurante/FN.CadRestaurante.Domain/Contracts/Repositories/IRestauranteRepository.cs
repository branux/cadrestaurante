using FN.CadRestaurante.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace FN.CadRestaurante.Domain.Contracts.Repositories
{
    public interface IRestauranteRepository : IRepository<Restaurante>
    {

        Restaurante ObterComPratos(Guid id);
        Task<Restaurante> ObterComPratosAsync(Guid id);
    }
}
