using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamlineAcademy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class instructor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Academies_Cities_CityId",
                table: "Academies");

            migrationBuilder.DropForeignKey(
                name: "FK_Academies_Countries_CountryId",
                table: "Academies");

            migrationBuilder.DropForeignKey(
                name: "FK_Academies_States_StateId",
                table: "Academies");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62b334dc-b5d4-4465-bc9d-1f228457c888"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateOfBirth",
                table: "Instructors",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "Skill",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkExperiance",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "StateId",
                table: "Academies",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "Academies",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CityId",
                table: "Academies",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "ResetExpiry", "Salt", "UserRole" },
                values: new object[] { new Guid("73581fec-683f-472b-b802-1f9427183940"), "Hsr,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 8, 14, 13, 38, 501, DateTimeKind.Unspecified).AddTicks(7288), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 8, 14, 13, 38, 501, DateTimeKind.Unspecified).AddTicks(7362), new TimeSpan(0, 5, 30, 0, 0)), "amir", "MtRQAyZHnABddpdOTEO0flcAI0XReBCeHqfowr52Ulw=", "8997654556", "786545", "", null, "FmgUZoSkSbXL58nqMzmZjg==", (byte)1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Academies_Cities_CityId",
                table: "Academies",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Academies_Countries_CountryId",
                table: "Academies",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Academies_States_StateId",
                table: "Academies",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Academies_Cities_CityId",
                table: "Academies");

            migrationBuilder.DropForeignKey(
                name: "FK_Academies_Countries_CountryId",
                table: "Academies");

            migrationBuilder.DropForeignKey(
                name: "FK_Academies_States_StateId",
                table: "Academies");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("73581fec-683f-472b-b802-1f9427183940"));

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "Skill",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "WorkExperiance",
                table: "Instructors");

            migrationBuilder.AlterColumn<Guid>(
                name: "StateId",
                table: "Academies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "Academies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CityId",
                table: "Academies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "ResetExpiry", "Salt", "UserRole" },
                values: new object[] { new Guid("62b334dc-b5d4-4465-bc9d-1f228457c888"), "Hsr,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 8, 11, 18, 20, 569, DateTimeKind.Unspecified).AddTicks(3703), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 8, 11, 18, 20, 569, DateTimeKind.Unspecified).AddTicks(3744), new TimeSpan(0, 5, 30, 0, 0)), "amir", "M/S0GOokbNjIy/4XLQh+85NUb2xEaU3UYXiVjBNv4Hw=", "8997654556", "786545", "", null, "nObDdazeJYzDs26OZG/4Tg==", (byte)1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Academies_Cities_CityId",
                table: "Academies",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Academies_Countries_CountryId",
                table: "Academies",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Academies_States_StateId",
                table: "Academies",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
