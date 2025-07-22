using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VROS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MovieDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Part = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cast", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Length = table.Column<TimeSpan>(type: "time", nullable: false),
                    AgeRestriction = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RentedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSubscriptionExpired = table.Column<bool>(type: "bit", nullable: false),
                    SubscriptionType = table.Column<int>(type: "int", nullable: false),
                    Roles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cast",
                columns: new[] { "Id", "MovieId", "Name", "Part" },
                values: new object[,]
                {
                    { 1, 1, "John Smith", 0 },
                    { 2, 2, "Jane Doe", 1 },
                    { 3, 2, "Alice Brown", 0 },
                    { 4, 3, "Bob White", 2 },
                    { 5, 4, "Eve Black", 3 }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeRestriction", "Genre", "IsAvailable", "Language", "Length", "Quantity", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 16, 0, true, 0, new TimeSpan(0, 2, 0, 0, 0), 5, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The First Movie" },
                    { 2, 12, 2, true, 0, new TimeSpan(0, 1, 50, 0, 0), 3, new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Second Chance" },
                    { 3, 10, 1, true, 0, new TimeSpan(0, 1, 35, 0, 0), 4, new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comedy Night" },
                    { 4, 18, 3, false, 0, new TimeSpan(0, 1, 40, 0, 0), 2, new DateTime(2022, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Horror House" },
                    { 5, 14, 4, true, 0, new TimeSpan(0, 2, 10, 0, 0), 6, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sci-Fi World" }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "MovieId", "RentedOn", "ReturnedOn", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 2, 2, new DateTime(2025, 7, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 7, 18, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 3, 3, new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { 4, 4, new DateTime(2025, 7, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, 5, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "CardNumber", "CreatedOn", "FullName", "IsSubscriptionExpired", "Roles", "SubscriptionType" },
                values: new object[,]
                {
                    { 1, 28, "1234567890", new DateTime(2023, 7, 21, 0, 0, 0, 0, DateTimeKind.Local), "Alice Johnson", false, 1, 1 },
                    { 2, 35, "2345678901", new DateTime(2024, 7, 21, 0, 0, 0, 0, DateTimeKind.Local), "Bob Smith", false, 0, 2 },
                    { 3, 22, "3456789012", new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Local), "Charlie Brown", true, 0, 0 },
                    { 4, 30, "4567890123", new DateTime(2022, 7, 21, 0, 0, 0, 0, DateTimeKind.Local), "Diana Prince", false, 0, 3 },
                    { 5, 40, "5678901234", new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Local), "Ethan Hunt", true, 0, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cast");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
