using FN.CadRestaurante.Domain.Contracts.Commands;
using System;

namespace FN.CadRestaurante.Domain.Commands.RestauranteCommand
{
    public class AddPratoNoRestauranteCommand:ICommand
    {
        public AddPratoNoRestauranteCommand()
        {}

        public AddPratoNoRestauranteCommand(Guid restauranteId, Guid pratoId)
        {
            RestauranteId = restauranteId;
            PratoId = pratoId;
        }

        public Guid RestauranteId { get; set; }
        public Guid PratoId { get; set; }
    }
}
