using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class add_solicitacao_compra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_SolicitacaoCompra_SolicitacaoCompraId",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolicitacaoCompra",
                table: "SolicitacaoCompra");

            migrationBuilder.RenameTable(
                name: "SolicitacaoCompra",
                newName: "Solicitacoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Solicitacoes",
                table: "Solicitacoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Solicitacoes_SolicitacaoCompraId",
                table: "Item",
                column: "SolicitacaoCompraId",
                principalTable: "Solicitacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Solicitacoes_SolicitacaoCompraId",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Solicitacoes",
                table: "Solicitacoes");

            migrationBuilder.RenameTable(
                name: "Solicitacoes",
                newName: "SolicitacaoCompra");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolicitacaoCompra",
                table: "SolicitacaoCompra",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_SolicitacaoCompra_SolicitacaoCompraId",
                table: "Item",
                column: "SolicitacaoCompraId",
                principalTable: "SolicitacaoCompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
