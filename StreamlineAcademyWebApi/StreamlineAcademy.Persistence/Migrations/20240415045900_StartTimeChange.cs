using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamlineAcademy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class StartTimeChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("66bf7a81-730e-4b57-86c1-1f885734b717"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "ResetExpiry", "Salt", "UserRole" },
                values: new object[] { new Guid("e5d71f25-3d84-45b1-b1a1-d58f53e77d08"), "Hsr,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 15, 10, 28, 59, 504, DateTimeKind.Unspecified).AddTicks(5030), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 15, 10, 28, 59, 504, DateTimeKind.Unspecified).AddTicks(5072), new TimeSpan(0, 5, 30, 0, 0)), "amir", "RhmM4lcVDcP1jJeMGtSdFHSzR/y00M1/dXRHQScJA5M=", "8997654556", "786545", "", null, "KdLsd41VVBRyrY9v7fPkmQ==", (byte)1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e5d71f25-3d84-45b1-b1a1-d58f53e77d08"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "ResetExpiry", "Salt", "UserRole" },
                values: new object[] { new Guid("66bf7a81-730e-4b57-86c1-1f885734b717"), "Hsr,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 15, 10, 27, 52, 892, DateTimeKind.Unspecified).AddTicks(7725), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 15, 10, 27, 52, 892, DateTimeKind.Unspecified).AddTicks(7767), new TimeSpan(0, 5, 30, 0, 0)), "amir", "JFC8vDqxDFj2jDWOp/963eQ30d6b8Lv80kDQ27KxthM=", "8997654556", "786545", "", null, "xERJP+pg/FO+1F9H40Va3A==", (byte)1 });
        }
    }
}
