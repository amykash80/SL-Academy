using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamlineAcademy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class resetExpiry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e6a47921-9985-403a-ac73-098e43c4d06e"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "ResetExpiry", "Salt", "UserRole" },
                values: new object[] { new Guid("103b4012-e712-4a70-a5e5-8f211b2f9806"), "Hsr,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 5, 10, 17, 48, 496, DateTimeKind.Unspecified).AddTicks(2794), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 5, 10, 17, 48, 496, DateTimeKind.Unspecified).AddTicks(2838), new TimeSpan(0, 5, 30, 0, 0)), "amir", "ez+Gbp13n/qOtzZKINuceAA6OPXrTe4SGWabFqFmdxQ=", "8997654556", "786545", "", "", "XNkVfDeIJ2DzM/LIJLcjrA==", (byte)1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("103b4012-e712-4a70-a5e5-8f211b2f9806"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "ModifiedBy", "ModifiedDate", "Name", "Password", "PhoneNumber", "PostalCode", "ResetCode", "ResetExpiry", "Salt", "UserRole" },
                values: new object[] { new Guid("e6a47921-9985-403a-ac73-098e43c4d06e"), "Hsr,Bangalore", new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 5, 10, 16, 10, 601, DateTimeKind.Unspecified).AddTicks(887), new TimeSpan(0, 5, 30, 0, 0)), new Guid("00000000-0000-0000-0000-000000000000"), null, "aamir@anterntech.com", true, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 4, 5, 10, 16, 10, 601, DateTimeKind.Unspecified).AddTicks(924), new TimeSpan(0, 5, 30, 0, 0)), "amir", "/dq/ldqFDAmtxHviashvHH+tgWhxifa4xuKYz4TrUXs=", "8997654556", "786545", "", null, "NljCmOLIOHH34RG0xmT/gg==", (byte)1 });
        }
    }
}
