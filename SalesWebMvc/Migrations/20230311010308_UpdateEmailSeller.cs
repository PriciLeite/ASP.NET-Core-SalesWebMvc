using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesWebMvc.Migrations
{
    public partial class UpdateEmailSeller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BithDate",
                table: "Seller",
                newName: "BirthDate");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Seller",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Seller");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Seller",
                newName: "BithDate");
        }
    }
}
