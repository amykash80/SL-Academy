using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamlineAcademy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class locationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ca19ecfb-a117-4146-ba25-5a31f00a66cb"));

            migrationBuilder.AddColumn<Guid>(
                name: "AcademyId",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Locations",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Locations",
                type: "float",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "ResetExpiry", "Salt", "UserRole" },
                values: new object[] { new Guid("2ab4c80f-59c1-4490-96c5-6229ff2b9fc2"), "Hsr,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 10, 14, 23, 41, 579, DateTimeKind.Unspecified).AddTicks(761), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 10, 14, 23, 41, 579, DateTimeKind.Unspecified).AddTicks(796), new TimeSpan(0, 5, 30, 0, 0)), "amir", "O7bIqf/vdJaEaxv0sB/3InwlOu+QDsuLFhrGwOTR4zw=", "8997654556", "786545", "", null, "ERqtpzqHhnGfssVuvVIjTQ==", (byte)1 });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AcademyId",
                table: "Locations",
                column: "AcademyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Academies_AcademyId",
                table: "Locations",
                column: "AcademyId",
                principalTable: "Academies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Academies_AcademyId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_AcademyId",
                table: "Locations");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2ab4c80f-59c1-4490-96c5-6229ff2b9fc2"));

            migrationBuilder.DropColumn(
                name: "AcademyId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Locations");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "ResetExpiry", "Salt", "UserRole" },
                values: new object[] { new Guid("ca19ecfb-a117-4146-ba25-5a31f00a66cb"), "Hsr,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 10, 12, 34, 53, 875, DateTimeKind.Unspecified).AddTicks(6561), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 10, 12, 34, 53, 875, DateTimeKind.Unspecified).AddTicks(6594), new TimeSpan(0, 5, 30, 0, 0)), "amir", "a3b0nXl2k/IQ/gwijv35XlA/mcljMwAbS7W41RQhBZc=", "8997654556", "786545", "", null, "936ngVBN+8CvxGH8uS8y0Q==", (byte)1 });
        }
    }
}
