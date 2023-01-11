using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain
{
    public class Dimensoes
    {
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            Validacoes.ValidarSeMenorQue(altura, 0, "O campo Altura não pode ser menor ou igual a zero.");
            Validacoes.ValidarSeMenorQue(largura, 0, "O campo Altura não pode ser menor ou igual a zero.");
            Validacoes.ValidarSeMenorQue(profundidade, 0, "O campo Altura não pode ser menor ou igual a zero.");

            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
        }

        public string DescricaoFormatada()
        {
            return $"LxAxP: {Largura} {Altura} {Profundidade}";
        }
    }
}
