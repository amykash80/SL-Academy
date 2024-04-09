using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamlineAcademy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class courseMig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7fb04f12-ac87-4568-8a98-5dc78959e4b9"));

            migrationBuilder.DropColumn(
                name: "InstructorName",
                table: "Courses");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "ResetExpiry", "Salt", "UserRole" },
                values: new object[] { new Guid("c9515b08-b730-4cb2-91f7-4d3e760a75ad"), "Hsr,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 9, 10, 35, 49, 50, DateTimeKind.Unspecified).AddTicks(9244), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 9, 10, 35, 49, 50, DateTimeKind.Unspecified).AddTicks(9301), new TimeSpan(0, 5, 30, 0, 0)), "amir", "aNmMEFM8rzL5J/gPL0MsfbhXmUOqtY/I66vJny6A/1E=", "8997654556", "786545", "", null, "oRmxg9a1I5fi3S775Ilf3A==", (byte)1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c9515b08-b730-4cb2-91f7-4d3e760a75ad"));

            migrationBuilder.AddColumn<string>(
                name: "InstructorName",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "ResetExpiry", "Salt", "UserRole" },
                values: new object[] { new Guid("7fb04f12-ac87-4568-8a98-5dc78959e4b9"), "Hsr,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 9, 10, 33, 31, 186, DateTimeKind.Unspecified).AddTicks(5694), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 9, 10, 33, 31, 186, DateTimeKind.Unspecified).AddTicks(5744), new TimeSpan(0, 5, 30, 0, 0)), "amir", "aUE4+9+P3rqxRnMMGdsI6YhTHR+BYlQpq1aJgT+1lxc=", "8997654556", "786545", "", null, "EhyVPrIVKjJ8IAfkGVCuFw==", (byte)1 });
        }
    }
}
