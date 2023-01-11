namespace NerdStore.Catalogo.Domain
{
    public interface IEstoqueService: IDisposable
    {
        Task<bool> DebitarEstoque(Guid produtoID, int quantidade);
        Task<bool> ReporEstoque(Guid produtoID, int quantidade);
    }
}
