using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamlineAcademy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperAdmins_AcademyTypes_AcademyTypeId",
                table: "SuperAdmins");

            migrationBuilder.DropIndex(
                name: "IX_SuperAdmins_AcademyTypeId",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "AcademyName",
                table: "SuperAdmins");

            migrationBuilder.DropColumn(
                name: "AcademyTypeId",
                table: "SuperAdmins");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcademyName",
                table: "SuperAdmins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AcademyTypeId",
                table: "SuperAdmins",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SuperAdmins_AcademyTypeId",
                table: "SuperAdmins",
                column: "AcademyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SuperAdmins_AcademyTypes_AcademyTypeId",
                table: "SuperAdmins",
                column: "AcademyTypeId",
                principalTable: "AcademyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
