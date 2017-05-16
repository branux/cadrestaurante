namespace FN.CadRestaurante.Domain.Contracts.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
}
