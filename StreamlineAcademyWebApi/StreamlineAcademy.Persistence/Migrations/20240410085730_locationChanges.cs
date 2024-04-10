using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamlineAcademy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class locationChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2ab4c80f-59c1-4490-96c5-6229ff2b9fc2"));

            migrationBuilder.RenameColumn(
                name: "LocationName",
                table: "Locations",
                newName: "Address");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "ResetExpiry", "Salt", "UserRole" },
                values: new object[] { new Guid("139589d5-7002-4e78-b1f9-059671eeb1fe"), "Hsr,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 10, 14, 27, 30, 303, DateTimeKind.Unspecified).AddTicks(6226), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 10, 14, 27, 30, 303, DateTimeKind.Unspecified).AddTicks(6263), new TimeSpan(0, 5, 30, 0, 0)), "amir", "sK7B5B7hZXlNQfXIjukyfTo9uM0h8Axsmv7kxtlLoj4=", "8997654556", "786545", "", null, "mkUBBB9k53ZvlJp8Fgt4pA==", (byte)1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("139589d5-7002-4e78-b1f9-059671eeb1fe"));

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Locations",
                newName: "LocationName");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "ResetExpiry", "Salt", "UserRole" },
                values: new object[] { new Guid("2ab4c80f-59c1-4490-96c5-6229ff2b9fc2"), "Hsr,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 10, 14, 23, 41, 579, DateTimeKind.Unspecified).AddTicks(761), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 10, 14, 23, 41, 579, DateTimeKind.Unspecified).AddTicks(796), new TimeSpan(0, 5, 30, 0, 0)), "amir", "O7bIqf/vdJaEaxv0sB/3InwlOu+QDsuLFhrGwOTR4zw=", "8997654556", "786545", "", null, "ERqtpzqHhnGfssVuvVIjTQ==", (byte)1 });
        }
    }
}
