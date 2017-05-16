using FN.CadRestaurante.Domain.Contracts.Commands;
using FN.CadRestaurante.Domain.Contracts.Repositories;
using FN.CadRestaurante.Domain.Entities;
using FN.CadRestaurante.Domain.FluentValidator;
using System.Linq;

namespace FN.CadRestaurante.Domain.Commands.RestauranteCommand
{
    public class RestauranteCommandHandler : Notifiable,
        ICommandHandler<AddRestauranteCommand>,
        ICommandHandler<AddPratoNoRestauranteCommand>
    {
        private readonly IRestauranteRepository _restauranteRepo;
        private readonly IPratoRepository _pratoRepo;

        public RestauranteCommandHandler(
            IRestauranteRepository restauranteRepo, IPratoRepository pratoRepo)
        {
            _restauranteRepo = restauranteRepo;
            _pratoRepo = pratoRepo;
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

        public void Handle(AddPratoNoRestauranteCommand command)
        {
            var restaurante = _restauranteRepo.ObterComPratos(command.RestauranteId);

            if (restaurante == null)
            {
                AddNotification("RestauranteId", "Restaurante não encontrado");
            }

            if (restaurante != null && restaurante.RestaurantePrato.Any(p => p.PratoId == command.PratoId))
            {
                AddNotification("PratoId", "Este prato já foi adicionado");
            }

            var prato = _pratoRepo.Obter(command.PratoId);
            if (prato == null)
            {
                AddNotification("PratoId", "Prato não encontrado");
            }

            if (!IsValid())
                return;

            restaurante.AdicionarPrato(prato);
        }
    }
}
