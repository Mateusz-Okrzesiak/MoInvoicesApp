using Microsoft.EntityFrameworkCore.Migrations;

namespace MoInvoices.Migrations
{
    public partial class poprawarelacji : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contractor_InvoiceID",
                table: "Contractor");

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_InvoiceID",
                table: "Contractor",
                column: "InvoiceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contractor_InvoiceID",
                table: "Contractor");

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_InvoiceID",
                table: "Contractor",
                column: "InvoiceID",
                unique: true);
        }
    }
}
