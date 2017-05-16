using FN.CadRestaurante.Domain.Contracts.Commands;
using FN.CadRestaurante.Domain.Contracts.Repositories;
using FN.CadRestaurante.Domain.Entities;
using FN.CadRestaurante.Domain.FluentValidator;

namespace FN.CadRestaurante.Domain.Commands.RestauranteCommand
{
    public class RestauranteCommandHandler : Notifiable,
        ICommandHandler<AddRestauranteCommand>,
        ICommandHandler<EditRestauranteCommand>
    {
        private readonly IRestauranteRepository _restauranteRepo;

        public RestauranteCommandHandler(IRestauranteRepository restauranteRepo)
        {
            _restauranteRepo = restauranteRepo;
        }

        public void Handle(AddRestauranteCommand command)
        {
            var restaurante = new Restaurante(command.Nome);
            AddNotifications(restaurante.Notifications);

            if (!IsValid())
                return;

            _restauranteRepo.Adicionar(restaurante);
            command.Id = restaurante.Id;
        }

        public void Handle(EditRestauranteCommand command)
        {
            var restaurante = _restauranteRepo.Obter(command.Id);
            if (restaurante == null)
                AddNotification("restauranteId", "Restaurante não encontrado");

            if (!IsValid())
                return;

            restaurante.Alterar(command.Nome);
            AddNotifications(restaurante.Notifications);
        }
    }
}
