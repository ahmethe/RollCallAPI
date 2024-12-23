using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b5790f3-7c70-441a-bb6b-758f7fefe960");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e00c45fa-91dc-42ff-8f29-ceaeef31581c");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RefreshTokenExpireTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06ec347c-ed41-4783-800e-61d1ee40f3b7", null, "User", "USER" },
                    { "2c66ea05-601c-4d45-b5b0-07588ba6f38c", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06ec347c-ed41-4783-800e-61d1ee40f3b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c66ea05-601c-4d45-b5b0-07588ba6f38c");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshTokenExpireTime",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8b5790f3-7c70-441a-bb6b-758f7fefe960", null, "Admin", "ADMIN" },
                    { "e00c45fa-91dc-42ff-8f29-ceaeef31581c", null, "User", "USER" }
                });
        }
    }
}
