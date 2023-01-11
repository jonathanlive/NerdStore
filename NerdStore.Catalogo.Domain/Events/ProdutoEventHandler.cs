using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoEventHandler : INotificationHandler<ProdutoEstoqueAbaixoEvent>
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoEventHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Handle(ProdutoEstoqueAbaixoEvent mensagem, CancellationToken cancellationToken)
        {
            var produto = _produtoRepository.ObterPorId(mensagem.AggregateId);

            //Enviar email para aquisição de mais produtos
            Console.WriteLine("Evento: Enviar email para aquisição de mais produtos");

        }
    }
}
