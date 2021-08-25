using Microsoft.EntityFrameworkCore.Migrations;

namespace FruitEcommerce.Infrastructure.Migrations
{
    public partial class RemovingFieldQuantityOfTableFruits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Fruits");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Fruits",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
