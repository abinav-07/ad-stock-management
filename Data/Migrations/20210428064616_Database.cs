using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupCourseWork.Data.Migrations
{
    public partial class Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "PurchaseDetail",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ManufactureDate",
                table: "PurchaseDetail",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "PurchaseDetail");

            migrationBuilder.DropColumn(
                name: "ManufactureDate",
                table: "PurchaseDetail");
        }
    }
}
