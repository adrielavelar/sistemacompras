using FluentValidation.Results;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.Enums;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.Validators;
using System;
using System.Collections.Generic;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }
        public Money TotalGeral { get; private set; }
        public Situacao Situacao { get; private set; }
        public CondicaoPagamento CondicaoPagamento { get; private set; }

        private SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;
        }

        public void AdicionarItem(Produto produto, int qtde)
        {
            Itens = new List<Item>();
            Itens.Add(new Item(produto, qtde));
        }

        public void RegistrarCompra(IEnumerable<Item> itens)
        {
            TotalGeral = new Money(0);
            foreach (Item item in itens)
            {
                TotalGeral.Add(item.Subtotal);
            }

            int condicao = TotalGeral.Value > 500000 ? 30 : 0;

            CondicaoPagamento = new CondicaoPagamento(condicao);
        }

        protected EntityValidate ValidateProperties()
        {
            var result = Validate();

            if (!result.IsValid)
            {
                return EntityValidate.Fail;
            }

            return EntityValidate.Valid;
        }

        public ValidationResult Validate() => new SolicitacaoCompraValidator().Validate(this);
    }
}
