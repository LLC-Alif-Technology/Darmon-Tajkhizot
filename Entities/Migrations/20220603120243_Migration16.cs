using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Migration16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5aaa3c1c-5215-4c32-9043-ca19964c2f97"));

            migrationBuilder.AddColumn<string>(
                name: "PlaceOfWork",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "PlaceOfWork", "Profession", "RoleId" },
                values: new object[] { new Guid("38ad079d-dd54-4488-b471-295d2ab052d0"), "test", "user@example.com", "Abubakr", "Nazirmadov", "$2a$11$0DisGh06zZg8AKJ/vIMZgOzZQUgtERPDgRJ4wDw7C7gVzKQzJwycC", "test", null, null, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38ad079d-dd54-4488-b471-295d2ab052d0"));

            migrationBuilder.DropColumn(
                name: "PlaceOfWork",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Profession",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId" },
                values: new object[] { new Guid("5aaa3c1c-5215-4c32-9043-ca19964c2f97"), "test", "user@example.com", "Abubakr", "Nazirmadov", "$2a$11$gTAd/z2JCIXfcegrIJ3voOqiJ0uGDWb/z6wap1GE79D4cg8ygWEqC", "test", 1 });
        }
    }
}
