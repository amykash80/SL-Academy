using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamlineAcademy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class confirmationCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SuperAdmins",
                keyColumn: "Id",
                keyValue: new Guid("0f6bd4e5-69fe-4d42-85f2-e84a4e357f77"));

            migrationBuilder.AddColumn<string>(
                name: "ConfirmationCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "ConfirmationCode", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "Salt", "UserRole" },
                values: new object[] { new Guid("1ec366ca-072b-4088-a8c4-510822110d8c"), "123 Main Street,Bangalore", null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 4, 12, 42, 24, 345, DateTimeKind.Unspecified).AddTicks(1550), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "ram@gmail.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 4, 12, 42, 24, 345, DateTimeKind.Unspecified).AddTicks(1588), new TimeSpan(0, 5, 30, 0, 0)), "Ram", "+HaQE5Vp8qEZFDIHpZOZG7S59exAyrAcpfKqeVSyfvs=", "8997654556", "786545", null, "AUucac9X4gWRxtpKBiAe7A==", (byte)1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1ec366ca-072b-4088-a8c4-510822110d8c"));

            migrationBuilder.DropColumn(
                name: "ConfirmationCode",
                table: "Users");

            migrationBuilder.InsertData(
                table: "SuperAdmins",
                columns: new[] { "Id", "CityId", "CountryId", "StateId" },
                values: new object[] { new Guid("0f6bd4e5-69fe-4d42-85f2-e84a4e357f77"), new Guid("677483a5-5af3-47d0-9a99-fd876c3ca0c9"), new Guid("4d67c002-eaa2-4519-b83b-0690abd17483"), new Guid("bd0eba4e-77b7-47fb-929c-12a793e158b9") });
        }
    }
}
