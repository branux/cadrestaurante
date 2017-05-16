using FN.CadRestaurante.Domain.FluentValidator;

namespace FN.CadRestaurante.Domain.Entities
{
    public class Restaurante : Entity
    {
        protected Restaurante()
        {}

        public Restaurante(string nome)
        {
            Nome = nome;
            validar();
        }

        public string Nome { get; private set; }

        public void Alterar(string nome)
        {
            Nome = nome;
            validar();
        }

        private void validar()
        {
            new ValidationContract<Restaurante>(this)
                .IsRequired(p => p.Nome, "O nome do reaturante é obrigatório")
                .HasMaxLenght(p => p.Nome, 100, "O nome do restaurante deve ter até 100 caracteres")
                .HasMinLenght(p => p.Nome, 3, "O nome do restaurante deve ter ao menos 3 caracteres");
        }
    }
}
