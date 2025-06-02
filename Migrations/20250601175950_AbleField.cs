using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoInterdisciplinar.Migrations
{
    /// <inheritdoc />
    public partial class AbleField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Able",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Able",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "AspNetUsers");
        }
    }
}
