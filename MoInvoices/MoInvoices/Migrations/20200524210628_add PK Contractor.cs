using Microsoft.EntityFrameworkCore.Migrations;

namespace MoInvoices.Migrations
{
    public partial class addPKContractor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contractor",
                table: "Contractor");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Contractor");

            migrationBuilder.AddColumn<int>(
                name: "ContractorID",
                table: "Contractor",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contractor",
                table: "Contractor",
                column: "ContractorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contractor",
                table: "Contractor");

            migrationBuilder.DropColumn(
                name: "ContractorID",
                table: "Contractor");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Contractor",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contractor",
                table: "Contractor",
                column: "id");
        }
    }
}
