using FN.CadRestaurante.Domain.FluentValidator;

namespace FN.CadRestaurante.Domain.Entities
{
    public class Prato : Entity
    {
        protected Prato() { }

        public Prato(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
            validar();
        }

        public string Nome { get; private set; }
        public decimal Preco { get; private set; }

        public void Alterar(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
            validar();
        }

        private void validar()
        {
            new ValidationContract<Prato>(this)
                .IsRequired(p => p.Nome, "O nome do prato é obrigatório")
                .HasMaxLenght(p => p.Nome, 100, "O nome do prato deve ter até 100 caracteres")
                .HasMinLenght(p => p.Nome, 3, "O nome do prato deve ter ao menos 3 caracteres")
                .IsGreaterOrEqualsThan(p => p.Preco, 0M, "O preço deve ser acima de 0");
        }
    }
}
