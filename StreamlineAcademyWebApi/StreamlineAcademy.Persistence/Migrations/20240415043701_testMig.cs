using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamlineAcademy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class testMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7765047e-205b-4855-90fb-53960e982d2e"));

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EndTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    BatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "ResetExpiry", "Salt", "UserRole" },
                values: new object[] { new Guid("44e40b59-fcc2-4daf-8646-cf22464a48ca"), "Hsr,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 15, 10, 6, 59, 691, DateTimeKind.Unspecified).AddTicks(2254), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 15, 10, 6, 59, 691, DateTimeKind.Unspecified).AddTicks(2289), new TimeSpan(0, 5, 30, 0, 0)), "amir", "y6brZy8g4CqRZnKSbvJGFDbRfCiA+lrCO9MT4qaOSAw=", "8997654556", "786545", "", null, "Kb1I4Ri+F1a7lqVsQhoWsQ==", (byte)1 });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_BatchId",
                table: "Schedules",
                column: "BatchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44e40b59-fcc2-4daf-8646-cf22464a48ca"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "ResetExpiry", "Salt", "UserRole" },
                values: new object[] { new Guid("7765047e-205b-4855-90fb-53960e982d2e"), "Hsr,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 12, 9, 17, 35, 354, DateTimeKind.Unspecified).AddTicks(6603), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 12, 9, 17, 35, 354, DateTimeKind.Unspecified).AddTicks(6638), new TimeSpan(0, 5, 30, 0, 0)), "amir", "TYhpn4PK21jld18kRcGNLBhH9M0ePvxxOihLcMrpZaE=", "8997654556", "786545", "", null, "jNHJDRTg7o4nW2Bkl2OIbQ==", (byte)1 });
        }
    }
}
