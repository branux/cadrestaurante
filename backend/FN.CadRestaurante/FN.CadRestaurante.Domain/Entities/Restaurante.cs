using FN.CadRestaurante.Domain.FluentValidator;
using System.Collections.Generic;

namespace FN.CadRestaurante.Domain.Entities
{
    public class Restaurante : Entity
    {
        protected Restaurante()
        { }

        public Restaurante(string nome)
        {
            Nome = nome;
            Pratos = new List<Prato>();
            validar();
        }

        public string Nome { get; private set; }
        public List<Prato> Pratos { get; set; }

        public void Alterar(string nome)
        {
            Nome = nome;
            validar();
        }

        private void validar()
        {
            new ValidationContract<Restaurante>(this)
                .IsRequired(p => p.Nome, "O nome do restaurante é obrigatório")
                .HasMaxLenght(p => p.Nome, 100, "O nome do restaurante deve ter até 100 caracteres")
                .HasMinLenght(p => p.Nome, 3, "O nome do restaurante deve ter ao menos 3 caracteres");
        }
    }
}
