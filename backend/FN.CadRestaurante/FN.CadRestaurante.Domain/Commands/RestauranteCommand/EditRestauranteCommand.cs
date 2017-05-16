using FN.CadRestaurante.Domain.Contracts.Commands;
using System;

namespace FN.CadRestaurante.Domain.Commands.RestauranteCommand
{
    public class EditRestauranteCommand:ICommand
    {
        public EditRestauranteCommand()
        {}

        public EditRestauranteCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
