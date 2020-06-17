using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoInvoices.Data.Migrations
{
    public partial class updateInvoiceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountNR",
                table: "Invoice",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "Invoice",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatusID",
                table: "Invoice",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeID",
                table: "Invoice",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNR",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "PaymentStatusID",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "PaymentTypeID",
                table: "Invoice");
        }
    }
}
