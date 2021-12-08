using Microsoft.EntityFrameworkCore.Migrations;

namespace RentnBuy.DataAccess.Migrations
{
    public partial class order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Car_CarId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "OrderDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Car_CarId",
                table: "OrderDetails",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Car_CarId",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "OrderDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "MenuItemId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Car_CarId",
                table: "OrderDetails",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
