using FluentValidation;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Domain.Validators
{
    public class SolicitacaoCompraValidator : AbstractValidator<SolicitacaoCompra>
    {
        public SolicitacaoCompraValidator()
        {
            RuleFor(solicitacao => solicitacao)
                .Must(x => ValidaCondicaoPagamento(x.TotalGeral, x.CondicaoPagamento))
                .WithMessage("A condição de pagamento para essa compra deve ser de 30 dias.");

            RuleFor(solicitacao => solicitacao.Itens.Count)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("O total de itens de compra deve ser maior que 0.");
        }

        private bool ValidaCondicaoPagamento(Money totalGeral, CondicaoPagamento condicaoPagamento)
        {
            if (totalGeral.Value > 50000 && condicaoPagamento.Valor != 30)
                return false;
            return true;
        }
    }
}
