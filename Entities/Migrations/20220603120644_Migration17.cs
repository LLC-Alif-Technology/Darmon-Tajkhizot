using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Migration17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38ad079d-dd54-4488-b471-295d2ab052d0"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "PlaceOfWork", "Profession", "RoleId" },
                values: new object[] { new Guid("f2bebcf5-b644-4f05-9fe8-9a88e50f4de8"), "test", "user@example.com", "Abubakr", "Nazirmadov", "$2a$11$JKxhwX3FCe9VPnsoU3aXOuqsGCfkAeYXCoQCLovTo6tYbWkx2Y/7i", "test", "test", "test", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f2bebcf5-b644-4f05-9fe8-9a88e50f4de8"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "PlaceOfWork", "Profession", "RoleId" },
                values: new object[] { new Guid("38ad079d-dd54-4488-b471-295d2ab052d0"), "test", "user@example.com", "Abubakr", "Nazirmadov", "$2a$11$0DisGh06zZg8AKJ/vIMZgOzZQUgtERPDgRJ4wDw7C7gVzKQzJwycC", "test", null, null, 1 });
        }
    }
}
