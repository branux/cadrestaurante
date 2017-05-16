using FN.CadRestaurante.Domain.Contracts.Infra;

namespace FN.CadRestaurante.Infra.Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CadRestauranteDataContext _context;
        public UnitOfWork(CadRestauranteDataContext context)
        {
            this._context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Roolback()
        {
            return;
        }
    }
}
