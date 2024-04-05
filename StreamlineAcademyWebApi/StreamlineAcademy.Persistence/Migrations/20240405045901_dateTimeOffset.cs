using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamlineAcademy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class dateTimeOffset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("103b4012-e712-4a70-a5e5-8f211b2f9806"));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ResetExpiry",
                table: "Users",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "ResetExpiry", "Salt", "UserRole" },
                values: new object[] { new Guid("ae8a85ec-c3aa-4c95-9325-30f4434176f6"), "Hsr,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 5, 10, 29, 0, 240, DateTimeKind.Unspecified).AddTicks(3848), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 5, 10, 29, 0, 240, DateTimeKind.Unspecified).AddTicks(3884), new TimeSpan(0, 5, 30, 0, 0)), "amir", "lRKuZ1rOmdRth0AXfQ6Z7R4AUJDBarwC5CjfUa4PxKk=", "8997654556", "786545", "", null, "JwkN0wX5x2V0AiGA36+g4A==", (byte)1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ae8a85ec-c3aa-4c95-9325-30f4434176f6"));

            migrationBuilder.AlterColumn<string>(
                name: "ResetExpiry",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "ResetExpiry", "Salt", "UserRole" },
                values: new object[] { new Guid("103b4012-e712-4a70-a5e5-8f211b2f9806"), "Hsr,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 5, 10, 17, 48, 496, DateTimeKind.Unspecified).AddTicks(2794), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 5, 10, 17, 48, 496, DateTimeKind.Unspecified).AddTicks(2838), new TimeSpan(0, 5, 30, 0, 0)), "amir", "ez+Gbp13n/qOtzZKINuceAA6OPXrTe4SGWabFqFmdxQ=", "8997654556", "786545", "", "", "XNkVfDeIJ2DzM/LIJLcjrA==", (byte)1 });
        }
    }
}
