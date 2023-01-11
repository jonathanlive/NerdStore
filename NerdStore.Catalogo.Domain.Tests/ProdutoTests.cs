using NerdStore.Core.DomainObjects;
using System;
using Xunit;

namespace NerdStore.Catalogo.Domain.Tests
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_Validar_PropriedadeNomeVazioDeveRetornarException()
        {
            //Arrange & Act & Assert
            var ex = Assert.Throws<DomainException>(() => new Produto(Guid.NewGuid(), string.Empty, "Descricao", false, 100, DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)));
     
            Assert.Equal("O campo Nome do produto não pode estar vazio.", ex.Message);
        }


        [Fact]
        public void Produto_Validar_PropriedadeDescricaoVazioDeveRetornarException()
        {
            //Arrange & Act & Assert
            var ex = Assert.Throws<DomainException>(() => new Produto(Guid.NewGuid(), "Descricao", string.Empty, false, 100, DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)));

            Assert.Equal("O campo Descricao do produto não pode estar vazio.", ex.Message);
        }

        [Fact]
        public void Produto_Validar_PropriedadeValorZeradoDeveRetornarException()
        {
            //Arrange & Act & Assert
            var ex = Assert.Throws<DomainException>(() => new Produto(Guid.NewGuid(), "Nome", "Descricao", false, 0, DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)));

            Assert.Equal("O campo Valor do produto não pode ser menor ou igual a zero.", ex.Message);
        }

        [Fact]
        public void Produto_Validar_PropriedadeCategoriaIdZeradoDeveRetornarException()
        {
            //Arrange & Act & Assert
            var ex = Assert.Throws<DomainException>(() => new Produto(Guid.Empty, "Nome", "Descricao", false, 100, DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)));

            Assert.Equal("O campo CategoriaId do produto não pode estar vazio.", ex.Message);
        }

        [Fact]
        public void Produto_Validar_PropriedadeImagemZeradoDeveRetornarException()
        {
            //Arrange & Act & Assert
            var ex = Assert.Throws<DomainException>(() => new Produto(Guid.NewGuid(), "Nome", "Descricao", false, 100, DateTime.Now, string.Empty, new Dimensoes(1, 1, 1)));

            Assert.Equal("O campo Imagem do produto não pode estar vazio.", ex.Message);
        }
    }
}