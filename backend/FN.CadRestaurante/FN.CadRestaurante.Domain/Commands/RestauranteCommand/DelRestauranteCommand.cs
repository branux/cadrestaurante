using FN.CadRestaurante.Domain.Contracts.Commands;
using System;

namespace FN.CadRestaurante.Domain.Commands.RestauranteCommand
{
    public class DelRestauranteCommand:ICommand
    {
        public DelRestauranteCommand()
        {}

        public DelRestauranteCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
