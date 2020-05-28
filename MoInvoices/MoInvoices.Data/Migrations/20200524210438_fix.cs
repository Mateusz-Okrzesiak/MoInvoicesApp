using Microsoft.EntityFrameworkCore.Migrations;

namespace MoInvoices.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contractor_Invoice_ContractorID",
                table: "Contractor");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceRowService_Invoice_InvoiceId",
                table: "InvoiceRowService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contractor",
                table: "Contractor");

            migrationBuilder.DropColumn(
                name: "Quantiy",
                table: "InvoiceRowService");

            migrationBuilder.DropColumn(
                name: "ContractorID",
                table: "Contractor");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "InvoiceRowService",
                newName: "InvoiceID");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceRowService_InvoiceId",
                table: "InvoiceRowService",
                newName: "IX_InvoiceRowService_InvoiceID");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "InvoiceRowService",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Contractor",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceID",
                table: "Contractor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contractor",
                table: "Contractor",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_InvoiceID",
                table: "Contractor",
                column: "InvoiceID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contractor_Invoice_InvoiceID",
                table: "Contractor",
                column: "InvoiceID",
                principalTable: "Invoice",
                principalColumn: "InvoiceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceRowService_Invoice_InvoiceID",
                table: "InvoiceRowService",
                column: "InvoiceID",
                principalTable: "Invoice",
                principalColumn: "InvoiceID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contractor_Invoice_InvoiceID",
                table: "Contractor");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceRowService_Invoice_InvoiceID",
                table: "InvoiceRowService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contractor",
                table: "Contractor");

            migrationBuilder.DropIndex(
                name: "IX_Contractor_InvoiceID",
                table: "Contractor");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "InvoiceRowService");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Contractor");

            migrationBuilder.DropColumn(
                name: "InvoiceID",
                table: "Contractor");

            migrationBuilder.RenameColumn(
                name: "InvoiceID",
                table: "InvoiceRowService",
                newName: "InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceRowService_InvoiceID",
                table: "InvoiceRowService",
                newName: "IX_InvoiceRowService_InvoiceId");

            migrationBuilder.AddColumn<int>(
                name: "Quantiy",
                table: "InvoiceRowService",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContractorID",
                table: "Contractor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contractor",
                table: "Contractor",
                column: "ContractorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contractor_Invoice_ContractorID",
                table: "Contractor",
                column: "ContractorID",
                principalTable: "Invoice",
                principalColumn: "InvoiceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceRowService_Invoice_InvoiceId",
                table: "InvoiceRowService",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "InvoiceID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
