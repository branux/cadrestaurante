using FN.CadRestaurante.Domain.Contracts.Commands;
using System;

namespace FN.CadRestaurante.Domain.Commands.RestauranteCommand
{
    public class AddRestauranteCommand : ICommand
    {
        public AddRestauranteCommand()
        {}

        public AddRestauranteCommand(string nome)
        {
            Nome = nome;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
