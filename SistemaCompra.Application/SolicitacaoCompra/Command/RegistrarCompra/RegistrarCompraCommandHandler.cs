using MediatR;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Infra.Data.UoW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly ISolicitacaoCompraRepository _repository;
        private readonly IProdutoRepository _produtoRepository;

        public RegistrarCompraCommandHandler(ISolicitacaoCompraRepository repository, IProdutoRepository produtoRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            _repository = repository;
            _produtoRepository = produtoRepository;
        }

        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var solicitacao = new SolicitacaoCompraAgg.SolicitacaoCompra(request.UsuarioSolicitante,
                                                                         request.NomeFornecedor);

            foreach (Item item in request.Itens)
            {
                item.Produto = _produtoRepository.Obter(item.Id);
                solicitacao.AdicionarItem(item.Produto, item.Qtde);
            }
                
            solicitacao.RegistrarCompra(request.Itens);

            _repository.RegistrarCompra(solicitacao);

            Commit();
            PublishEvents(solicitacao.Events);

            return Task.FromResult(true);
        }
    }
}
