using FN.CadRestaurante.Domain.Contracts.Commands;
using System;

namespace FN.CadRestaurante.Domain.Commands.PratoCommand
{
    public class EditPratoCommand:ICommand
    {
        public EditPratoCommand()
        {}

        public EditPratoCommand(Guid id, string nome, decimal preco, Guid restauranteId)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            RestauranteId = restauranteId;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public Guid RestauranteId { get; set; }
    }
}
