using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalDB.Migrations
{
    public partial class AddingRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "78A7570F-3CE5-48BA-9461-80283ED1D94D", "bf9387fd-a8d2-43e5-8247-1785f0f98e15", "Doctor", "DOCTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78A7570F-3CE5-48BA-9461-80283ED1D94D");
        }
    }
}
