using Microsoft.EntityFrameworkCore.Migrations;

namespace MoInvoices.Migrations
{
    public partial class addcontractortypeIDtoinvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContractorTypeID",
                table: "Contractor",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractorTypeID",
                table: "Contractor");
        }
    }
}
