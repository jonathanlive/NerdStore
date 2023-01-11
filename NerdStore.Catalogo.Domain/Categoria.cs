using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public string Nome { get; set; }
        public int Codigo { get; set; }

        //EF Relation
        public ICollection<Produto> Produtos { get; set; }
        protected Categoria() { }
        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome da categoria não pode estar vazio.");
            Validacoes.ValidarSeMenorQue(Codigo, 1, "O campo código da categoria não pode ser menor ou igual a zero.");
        }
    }
}
