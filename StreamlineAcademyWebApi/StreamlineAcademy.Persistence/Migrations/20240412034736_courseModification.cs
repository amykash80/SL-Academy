using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamlineAcademy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class courseModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Academies_AcademyId",
                table: "Locations");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("139589d5-7002-4e78-b1f9-059671eeb1fe"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AcademyId",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "AcademyId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "ResetExpiry", "Salt", "UserRole" },
                values: new object[] { new Guid("7765047e-205b-4855-90fb-53960e982d2e"), "Hsr,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 12, 9, 17, 35, 354, DateTimeKind.Unspecified).AddTicks(6603), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 12, 9, 17, 35, 354, DateTimeKind.Unspecified).AddTicks(6638), new TimeSpan(0, 5, 30, 0, 0)), "amir", "TYhpn4PK21jld18kRcGNLBhH9M0ePvxxOihLcMrpZaE=", "8997654556", "786545", "", null, "jNHJDRTg7o4nW2Bkl2OIbQ==", (byte)1 });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AcademyId",
                table: "Courses",
                column: "AcademyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Academies_AcademyId",
                table: "Courses",
                column: "AcademyId",
                principalTable: "Academies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Academies_AcademyId",
                table: "Locations",
                column: "AcademyId",
                principalTable: "Academies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Academies_AcademyId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Academies_AcademyId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Courses_AcademyId",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7765047e-205b-4855-90fb-53960e982d2e"));

            migrationBuilder.DropColumn(
                name: "AcademyId",
                table: "Courses");

            migrationBuilder.AlterColumn<Guid>(
                name: "AcademyId",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "ResetExpiry", "Salt", "UserRole" },
                values: new object[] { new Guid("139589d5-7002-4e78-b1f9-059671eeb1fe"), "Hsr,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 10, 14, 27, 30, 303, DateTimeKind.Unspecified).AddTicks(6226), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 10, 14, 27, 30, 303, DateTimeKind.Unspecified).AddTicks(6263), new TimeSpan(0, 5, 30, 0, 0)), "amir", "sK7B5B7hZXlNQfXIjukyfTo9uM0h8Axsmv7kxtlLoj4=", "8997654556", "786545", "", null, "mkUBBB9k53ZvlJp8Fgt4pA==", (byte)1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Academies_AcademyId",
                table: "Locations",
                column: "AcademyId",
                principalTable: "Academies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
