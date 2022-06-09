using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Migration18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f2bebcf5-b644-4f05-9fe8-9a88e50f4de8"));

            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "PlaceOfWork", "Profession", "RoleId" },
                values: new object[] { new Guid("7adbf970-3452-4ef9-8727-a2cf557ac251"), "test", "user@example.com", "Abubakr", "Nazirmadov", "$2a$11$ZUjs6lstJ7AqX.xUEpXFkumgcwNgxRS8hSbeNpR3Av5S4lzIxXHtS", "test", "test", "test", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Descriptions");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7adbf970-3452-4ef9-8727-a2cf557ac251"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "PlaceOfWork", "Profession", "RoleId" },
                values: new object[] { new Guid("f2bebcf5-b644-4f05-9fe8-9a88e50f4de8"), "test", "user@example.com", "Abubakr", "Nazirmadov", "$2a$11$JKxhwX3FCe9VPnsoU3aXOuqsGCfkAeYXCoQCLovTo6tYbWkx2Y/7i", "test", "test", "test", 1 });
        }
    }
}
