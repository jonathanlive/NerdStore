using NerdStore.Catalogo.Domain.Events;
using NerdStore.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediatrHandler _bus;

        public EstoqueService(IProdutoRepository produtoRepository, IMediatrHandler bus)
        {
            _produtoRepository = produtoRepository;
            _bus = bus;
        }
        public async Task<bool> DebitarEstoque(Guid produtoID, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoID);
            if (produto == null) return false;
            if(!produto.PossuiEstoque(quantidade)) return false;

            produto.DebitarEstoque(quantidade);

            if(produto.QuantidadeEstoque < 10)
            {
                await _bus.PublicarEvento(new ProdutoEstoqueAbaixoEvent(produto.Id, produto.QuantidadeEstoque));
            }

            _produtoRepository.AtualizarProdutos(produto);
            return await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> ReporEstoque(Guid produtoID, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoID);
            if (produto == null) return false;
            produto.ReporEstoque(quantidade);

            _produtoRepository.AtualizarProdutos(produto);
            return await _produtoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }
}
