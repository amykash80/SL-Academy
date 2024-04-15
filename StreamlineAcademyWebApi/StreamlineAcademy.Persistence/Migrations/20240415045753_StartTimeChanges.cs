using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamlineAcademy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class StartTimeChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0a91c3be-020d-4643-aa4c-af3fe160ecbb"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "ResetExpiry", "Salt", "UserRole" },
                values: new object[] { new Guid("66bf7a81-730e-4b57-86c1-1f885734b717"), "Hsr,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 15, 10, 27, 52, 892, DateTimeKind.Unspecified).AddTicks(7725), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 15, 10, 27, 52, 892, DateTimeKind.Unspecified).AddTicks(7767), new TimeSpan(0, 5, 30, 0, 0)), "amir", "JFC8vDqxDFj2jDWOp/963eQ30d6b8Lv80kDQ27KxthM=", "8997654556", "786545", "", null, "xERJP+pg/FO+1F9H40Va3A==", (byte)1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("66bf7a81-730e-4b57-86c1-1f885734b717"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "ResetExpiry", "Salt", "UserRole" },
                values: new object[] { new Guid("0a91c3be-020d-4643-aa4c-af3fe160ecbb"), "Hsr,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 15, 10, 24, 0, 318, DateTimeKind.Unspecified).AddTicks(9310), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 15, 10, 24, 0, 318, DateTimeKind.Unspecified).AddTicks(9351), new TimeSpan(0, 5, 30, 0, 0)), "amir", "+//r9u+adX3WGsftB/bIsYXksGBHeHbSAuChZEMXBs4=", "8997654556", "786545", "", null, "2hRr1pT8QFHblICXqVVoig==", (byte)1 });
        }
    }
}
