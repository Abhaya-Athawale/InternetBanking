using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customer.Migrations
{
    public partial class new8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerLogin_Customer_CustomerId",
                table: "CustomerLogin");

            migrationBuilder.DropIndex(
                name: "IX_CustomerLogin_CustomerId",
                table: "CustomerLogin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CustomerLogin_CustomerId",
                table: "CustomerLogin",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerLogin_Customer_CustomerId",
                table: "CustomerLogin",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
