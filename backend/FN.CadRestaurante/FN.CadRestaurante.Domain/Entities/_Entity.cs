using FN.CadRestaurante.Domain.FluentValidator;
using System;

namespace FN.CadRestaurante.Domain.Entities
{
    public abstract class Entity : Notifiable
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            DataCadastro = DateTime.Now;
        }
        public Guid Id { get; private set; }
        public DateTime DataCadastro { get; private set; }

    }
}
