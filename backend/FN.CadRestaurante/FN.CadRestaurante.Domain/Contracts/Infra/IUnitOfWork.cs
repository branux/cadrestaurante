namespace FN.CadRestaurante.Domain.Contracts.Infra
{
    public interface IUnitOfWork
    {
        void Commit();
        void Roolback();
    }
}
