using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Migration15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId" },
                values: new object[] { new Guid("5aaa3c1c-5215-4c32-9043-ca19964c2f97"), "test", "user@example.com", "Abubakr", "Nazirmadov", "$2a$11$gTAd/z2JCIXfcegrIJ3voOqiJ0uGDWb/z6wap1GE79D4cg8ygWEqC", "test", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5aaa3c1c-5215-4c32-9043-ca19964c2f97"));
        }
    }
}
