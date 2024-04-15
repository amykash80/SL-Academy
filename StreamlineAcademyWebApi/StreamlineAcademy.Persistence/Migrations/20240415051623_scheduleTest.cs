using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamlineAcademy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class scheduleTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44e40b59-fcc2-4daf-8646-cf22464a48ca"));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "Schedules",
                type: "time",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "Schedules",
                type: "time",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "ResetExpiry", "Salt", "UserRole" },
                values: new object[] { new Guid("89ec9ce5-fbc1-4ae4-addc-145ef0dac913"), "Hsr,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 15, 10, 46, 22, 587, DateTimeKind.Unspecified).AddTicks(7195), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 15, 10, 46, 22, 587, DateTimeKind.Unspecified).AddTicks(7229), new TimeSpan(0, 5, 30, 0, 0)), "amir", "ijTG+gfvVSfpKNOjGP6q1cQAnizTs73F8R8lHhoigrM=", "8997654556", "786545", "", null, "aBvlBrug4J6yXJxCxywmvw==", (byte)1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("89ec9ce5-fbc1-4ae4-addc-145ef0dac913"));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "StartTime",
                table: "Schedules",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EndTime",
                table: "Schedules",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "ResetExpiry", "Salt", "UserRole" },
                values: new object[] { new Guid("44e40b59-fcc2-4daf-8646-cf22464a48ca"), "Hsr,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 15, 10, 6, 59, 691, DateTimeKind.Unspecified).AddTicks(2254), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 15, 10, 6, 59, 691, DateTimeKind.Unspecified).AddTicks(2289), new TimeSpan(0, 5, 30, 0, 0)), "amir", "y6brZy8g4CqRZnKSbvJGFDbRfCiA+lrCO9MT4qaOSAw=", "8997654556", "786545", "", null, "Kb1I4Ri+F1a7lqVsQhoWsQ==", (byte)1 });
        }
    }
}
