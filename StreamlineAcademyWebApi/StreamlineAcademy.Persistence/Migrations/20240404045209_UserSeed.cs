using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamlineAcademy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Enquiries",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Enquiries",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AcademyName",
                table: "Academies",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "Salt", "UserRole" },
                values: new object[] { new Guid("0f6bd4e5-69fe-4d42-85f2-e84a4e357f77"), "123 Main Street,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 4, 10, 22, 9, 401, DateTimeKind.Unspecified).AddTicks(3277), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "ram@gmail.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 4, 10, 22, 9, 401, DateTimeKind.Unspecified).AddTicks(3313), new TimeSpan(0, 5, 30, 0, 0)), "Ram", "xOO/j/8GbVLIze0+PmPHRe0QdrkglNhbksuIFHNaEHU=", "8997654556", "786545", null, "nynNoKa85QsiQQnc1IGi/w==", (byte)1 });

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_Email",
                table: "Enquiries",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiries_Name",
                table: "Enquiries",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Academies_AcademyName",
                table: "Academies",
                column: "AcademyName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Enquiries_Email",
                table: "Enquiries");

            migrationBuilder.DropIndex(
                name: "IX_Enquiries_Name",
                table: "Enquiries");

            migrationBuilder.DropIndex(
                name: "IX_Academies_AcademyName",
                table: "Academies");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0f6bd4e5-69fe-4d42-85f2-e84a4e357f77"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Enquiries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Enquiries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AcademyName",
                table: "Academies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
