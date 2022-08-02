using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalDB.Migrations
{
    public partial class CreatingIdentityTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Doctors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Doctors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Doctors");
        }
    }
}
