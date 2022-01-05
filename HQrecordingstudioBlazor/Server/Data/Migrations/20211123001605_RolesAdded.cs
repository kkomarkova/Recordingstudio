using Microsoft.EntityFrameworkCore.Migrations;

namespace HQrecordingstudioBlazor.Server.Data.Migrations
{
    public partial class RolesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c1dbc838-93fb-4b11-9850-b7788b591c44", "24b6e17a-b296-4f27-a6ff-33fccd0ec5bc", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fcbd9b30-c9fc-4b14-8e41-0362423504be", "77ea0482-91a2-47c2-968a-8d45ce1af80d", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1dbc838-93fb-4b11-9850-b7788b591c44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcbd9b30-c9fc-4b14-8e41-0362423504be");
        }
    }
}
