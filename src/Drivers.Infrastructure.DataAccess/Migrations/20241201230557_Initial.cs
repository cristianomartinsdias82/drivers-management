using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Drivers.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverSince = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achievements_Driver",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "CreatedOn", "DriverSince", "Name" },
                values: new object[,]
                {
                    { new Guid("101ca01f-8dc7-4663-98d2-168dcff327a1"), new DateTimeOffset(new DateTime(2024, 12, 1, 23, 5, 55, 794, DateTimeKind.Unspecified).AddTicks(8037), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2024, 10, 1), "Eneas Martins Dias" },
                    { new Guid("21299a2d-90a2-40ce-923e-3ec90a714201"), new DateTimeOffset(new DateTime(2024, 12, 1, 23, 5, 55, 794, DateTimeKind.Unspecified).AddTicks(8052), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2024, 9, 1), "Erica Martins Dias" },
                    { new Guid("4b4e6600-7a5a-488c-9ab1-beb1679a3e2f"), new DateTimeOffset(new DateTime(2024, 12, 1, 23, 5, 55, 794, DateTimeKind.Unspecified).AddTicks(8056), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2024, 11, 1), "Cristiano Martins Dias" },
                    { new Guid("8dbaed53-7981-4c2a-b398-cd9e102f1867"), new DateTimeOffset(new DateTime(2024, 12, 1, 23, 5, 55, 794, DateTimeKind.Unspecified).AddTicks(8047), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2024, 9, 1), "Maria Aparecida Martins Dias" },
                    { new Guid("cd85c2d2-eaed-499b-97ff-1df08984275d"), new DateTimeOffset(new DateTime(2024, 12, 1, 23, 5, 55, 794, DateTimeKind.Unspecified).AddTicks(8060), new TimeSpan(0, 0, 0, 0, 0)), new DateOnly(2024, 8, 1), "Adriana da Silva de Sena" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_DriverId",
                table: "Achievements",
                column: "DriverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
