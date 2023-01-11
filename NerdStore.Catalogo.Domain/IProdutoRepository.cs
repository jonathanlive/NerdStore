using NerdStore.Core.Data;


namespace NerdStore.Catalogo.Domain
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorId(Guid id);
        Task<IEnumerable<Produto>> ObterPorCategoria(int codigo);
        Task<IEnumerable<Categoria>> ObterCategorias();

        void AdicionarProdutos(Produto produto);

        void AtualizarProdutos(Produto produto);

        void AdicionarCategoria(Categoria categoria);

        void AtualizarCategoria(Categoria categoria);

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
