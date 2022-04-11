using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraConfiguration : IEntityTypeConfiguration<SolicitacaoCompraAgg.SolicitacaoCompra>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoCompraAgg.SolicitacaoCompra> builder)
        {
            builder.ToTable("Solicitacoes");
            builder.OwnsOne(s => s.TotalGeral, b => b.Property("Value").HasColumnName("TotalGeral"));
            builder.OwnsOne(s => s.CondicaoPagamento, b => b.Property("Valor").HasColumnName("CondicaoPagamento"));
            builder.OwnsOne(s => s.UsuarioSolicitante, b => b.Property("Nome").HasColumnName("UsuarioSolicitante"));
            builder.OwnsOne(s => s.NomeFornecedor, b => b.Property("Nome").HasColumnName("NomeFornecedor"));
        }
    }
}
