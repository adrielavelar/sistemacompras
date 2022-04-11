using MediatR;
using SistemaCompra.Domain.ProdutoAggregate;
using System;

namespace SistemaCompra.Application.Produto.Command.RegistrarProduto
{
    public class RegistrarProdutoCommand : IRequest<bool>
    {
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
    }
}
