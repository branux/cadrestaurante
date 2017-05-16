using System;
using FN.CadRestaurante.Domain.Contracts.Commands;
using FN.CadRestaurante.Domain.Contracts.Repositories;
using FN.CadRestaurante.Domain.Entities;
using FN.CadRestaurante.Domain.FluentValidator;

namespace FN.CadRestaurante.Domain.Commands.PratoCommand
{
    public class PratoCommandHandler : Notifiable,
        ICommandHandler<AddPratoCommand>,
        ICommandHandler<EditPratoCommand>,
        ICommandHandler<DelPratoCommand>
    {
        private readonly IPratoRepository _pratoRepo;

        public PratoCommandHandler(IPratoRepository pratoRepo)
        {
            _pratoRepo = pratoRepo;
        }


        public void Handle(AddPratoCommand command)
        {
            var prato = new Prato(command.Nome,command.Preco,command.RestauranteId);
            AddNotifications(prato.Notifications);

            if (!IsValid())
                return;

            _pratoRepo.Adicionar(prato);
            command.Id = prato.Id;
        }

        public void Handle(EditPratoCommand command)
        {
            var prato = _pratoRepo.Obter(command.Id);

            prato.Alterar(command.Nome, command.Preco, command.RestauranteId);
            AddNotifications(prato.Notifications);

        }

        public void Handle(DelPratoCommand command)
        {
            var prato = _pratoRepo.Obter(command.Id);

            if (prato == null)
            {
                AddNotification("pratoId", "Prato não localizado");
                return;
            }

            _pratoRepo.Excluir(prato);
        }
    }
}
