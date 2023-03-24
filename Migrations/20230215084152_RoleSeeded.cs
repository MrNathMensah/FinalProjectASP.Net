using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NETFinalExamsProject.Migrations
{
    public partial class RoleSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "adb46b33-eedb-4422-88f6-0984cc169e7f", "2", "Receptionist", "Receptionist" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b284a199-8d5f-40ba-9203-45cc0d399354", "1", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adb46b33-eedb-4422-88f6-0984cc169e7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b284a199-8d5f-40ba-9203-45cc0d399354");
        }
    }
}
