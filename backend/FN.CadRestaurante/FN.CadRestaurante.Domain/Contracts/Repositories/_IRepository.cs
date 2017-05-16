using FN.CadRestaurante.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FN.CadRestaurante.Domain.Contracts.Repositories
{
    public interface IRepository<T> :
       IDisposable where T : Entity
    {
        void Adicionar(T entity);
        void Atualizar(T entity);
        void Excluir(T entity);
        void Excluir(IEnumerable<T> entities);
        IEnumerable<T> Obter();
        Task<IEnumerable<T>> ObterAsync();
        T Obter(Guid key);
        Task<T> ObterAsync(Guid key);
    }
}
