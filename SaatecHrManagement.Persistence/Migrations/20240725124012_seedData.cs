using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaatecHrManagement.Persistence.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "DefaultDays", "ModifiedBy", "Name" },
                values: new object[] { 1, null, null, null, 10, null, "Vacation" });

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "DefaultDays", "ModifiedBy", "Name" },
                values: new object[] { 2, null, null, null, 15, null, "Sick" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
