using FN.CadRestaurante.Domain.Contracts.Repositories;
using FN.CadRestaurante.Domain.Entities;
using FN.CadRestaurante.Infra.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FN.CadRestaurante.Infra.Data.Respositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly CadRestauranteDataContext _context;
        public Repository(CadRestauranteDataContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<T> Obter()
        {
            return _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> ObterAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }


        public virtual T Obter(Guid key)
        {
            return _context.Set<T>().Find(key);
        }



        public virtual async Task<T> ObterAsync(Guid key)
        {
            return await _context.Set<T>().FindAsync(key);
        }


        public void Adicionar(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Atualizar(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Excluir(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Excluir(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
