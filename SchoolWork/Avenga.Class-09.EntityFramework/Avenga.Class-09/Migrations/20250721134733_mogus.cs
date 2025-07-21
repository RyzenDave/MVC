using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Avenga.Class_09.Migrations
{
    /// <inheritdoc />
    public partial class mogus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name", "NumberOfClasses" },
                values: new object[,]
                {
                    { 4, "Entity Framework Core", 18 },
                    { 5, "Azure Fundamentals", 15 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ActiveCourseId", "DateOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 4, 4, new DateTime(2002, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diana", "Evans" },
                    { 5, 5, new DateTime(2000, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ethan", "Williams" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
