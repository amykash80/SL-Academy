using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamlineAcademy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class academyTableUpdation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SuperAdmins",
                keyColumn: "Id",
                keyValue: new Guid("177a3042-934e-4631-8e86-ca1907945d1a"));

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Academies");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Academies");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Academies");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Academies");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Academies");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Academies");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Academies");

            migrationBuilder.InsertData(
                table: "SuperAdmins",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "Salt", "UserName", "UserRole" },
                values: new object[] { new Guid("19700f39-c11f-48e1-86f2-ab6d543c1846"), null, new DateTimeOffset(new DateTime(2024, 3, 29, 15, 4, 35, 370, DateTimeKind.Unspecified).AddTicks(8097), new TimeSpan(0, 5, 30, 0, 0)), null, null, "ram@gmail.com", false, null, null, "Ram", "3ixUSbUjQWqHJJ3Zo7XT9JcOcrnfVgGhW6TGCkfvbRA=", "7267636376", "T5mEISJczRgmdsEAjppWYw==", "superadmin@123", (byte)1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SuperAdmins",
                keyColumn: "Id",
                keyValue: new Guid("19700f39-c11f-48e1-86f2-ab6d543c1846"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Academies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Academies",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Academies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedDate",
                table: "Academies",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Academies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Academies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "Academies",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.InsertData(
                table: "SuperAdmins",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "Salt", "UserName", "UserRole" },
                values: new object[] { new Guid("177a3042-934e-4631-8e86-ca1907945d1a"), null, new DateTimeOffset(new DateTime(2024, 3, 28, 15, 32, 48, 984, DateTimeKind.Unspecified).AddTicks(2465), new TimeSpan(0, 5, 30, 0, 0)), null, null, "ram@gmail.com", false, null, null, "Ram", "/O+qfqmYBxJzgCINTmiJUUKioDb7exEDeyoPSyYWj/M=", "7267636376", "1Lf03rOw0kZZkPnhzssf2A==", "superadmin@123", (byte)1 });
        }
    }
}
