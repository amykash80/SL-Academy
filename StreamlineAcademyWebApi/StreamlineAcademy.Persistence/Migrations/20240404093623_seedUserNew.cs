using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamlineAcademy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seedUserNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1ec366ca-072b-4088-a8c4-510822110d8c"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "ConfirmationCode", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "Salt", "UserRole" },
                values: new object[] { new Guid("f351e6af-ce60-4166-9835-287edebe5431"), "Hsr,Bangalore", null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 4, 15, 6, 23, 155, DateTimeKind.Unspecified).AddTicks(5275), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 4, 15, 6, 23, 155, DateTimeKind.Unspecified).AddTicks(5304), new TimeSpan(0, 5, 30, 0, 0)), "amir", "86rJ11CT+PSBxHmZAizslKV0whSWxPuOQCBNo6WthCM=", "8997654556", "786545", null, "6SgMmQDK89tEYkU7RmMqJg==", (byte)1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f351e6af-ce60-4166-9835-287edebe5431"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "ConfirmationCode", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "Salt", "UserRole" },
                values: new object[] { new Guid("1ec366ca-072b-4088-a8c4-510822110d8c"), "123 Main Street,Bangalore", null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 4, 12, 42, 24, 345, DateTimeKind.Unspecified).AddTicks(1550), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "ram@gmail.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 4, 12, 42, 24, 345, DateTimeKind.Unspecified).AddTicks(1588), new TimeSpan(0, 5, 30, 0, 0)), "Ram", "+HaQE5Vp8qEZFDIHpZOZG7S59exAyrAcpfKqeVSyfvs=", "8997654556", "786545", null, "AUucac9X4gWRxtpKBiAe7A==", (byte)1 });
        }
    }
}
