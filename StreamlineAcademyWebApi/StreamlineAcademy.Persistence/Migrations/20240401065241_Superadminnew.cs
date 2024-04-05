using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamlineAcademy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Superadminnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SuperAdmins",
                keyColumn: "Id",
                keyValue: new Guid("19700f39-c11f-48e1-86f2-ab6d543c1846"));

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "SuperAdmins");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "Salt", "UserRole" },
                values: new object[] { new Guid("3cdf7cf6-b0f8-4c97-855f-2b59b1c529cb"), "123 Main Street,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 1, 12, 22, 41, 92, DateTimeKind.Unspecified).AddTicks(4802), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "ram@gmail.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 1, 12, 22, 41, 92, DateTimeKind.Unspecified).AddTicks(4851), new TimeSpan(0, 5, 30, 0, 0)), "Ram", "9MylLKnnj+bK/771cqsLijhQ6GqTnMkT+eOvr/pPHo0=", "8997654556", "786545", null, "BfjbuXzcNQQce5oNSGBRnQ==", (byte)1 });

            migrationBuilder.InsertData(
                table: "SuperAdmins",
                column: "Id",
                value: new Guid("3cdf7cf6-b0f8-4c97-855f-2b59b1c529cb"));

            migrationBuilder.AddForeignKey(
                name: "FK_SuperAdmins_Users_Id",
                table: "SuperAdmins",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperAdmins_Users_Id",
                table: "SuperAdmins");

            migrationBuilder.DeleteData(
                table: "SuperAdmins",
                keyColumn: "Id",
                keyValue: new Guid("3cdf7cf6-b0f8-4c97-855f-2b59b1c529cb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3cdf7cf6-b0f8-4c97-855f-2b59b1c529cb"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "SuperAdmins",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "SuperAdmins",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "SuperAdmins",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedDate",
                table: "SuperAdmins",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "SuperAdmins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SuperAdmins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "SuperAdmins",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "SuperAdmins",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SuperAdmins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "SuperAdmins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "SuperAdmins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "SuperAdmins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "SuperAdmins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "UserRole",
                table: "SuperAdmins",
                type: "tinyint",
                nullable: true);

            migrationBuilder.InsertData(
                table: "SuperAdmins",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "Salt", "UserName", "UserRole" },
                values: new object[] { new Guid("19700f39-c11f-48e1-86f2-ab6d543c1846"), null, new DateTimeOffset(new DateTime(2024, 3, 29, 15, 4, 35, 370, DateTimeKind.Unspecified).AddTicks(8097), new TimeSpan(0, 5, 30, 0, 0)), null, null, "ram@gmail.com", false, null, null, "Ram", "3ixUSbUjQWqHJJ3Zo7XT9JcOcrnfVgGhW6TGCkfvbRA=", "7267636376", "T5mEISJczRgmdsEAjppWYw==", "superadmin@123", (byte)1 });
        }
    }
}
