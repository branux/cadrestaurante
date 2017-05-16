using FN.CadRestaurante.Domain.Contracts.Commands;
using System;

namespace FN.CadRestaurante.Domain.Commands.PratoCommand
{
    public class DelPratoCommand:ICommand
    {
        public DelPratoCommand()
        {}

        public DelPratoCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
