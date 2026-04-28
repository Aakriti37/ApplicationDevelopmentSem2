using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sem2FirstProject.Migrations
{
    /// <inheritdoc />
    public partial class RolesSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3ac132dd-1f1b-45ae-aad3-9974d4ff78e5"), "3448f227-acb6-49bc-8169-4c1a2a8a1dbc", "Admin", "ADMIN" },
                    { new Guid("ce76ebcf-2bb0-445d-a4bd-156917fae84f"), "587a29b8-4471-4f05-bac1-6f204f9e256a", "Staff", "STAFF" },
                    { new Guid("e45f59e0-aadb-44f6-b418-7b8882278307"), "05981ee3-1e5d-4105-891f-1708cc1ddff2", "Student", "STUDENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3ac132dd-1f1b-45ae-aad3-9974d4ff78e5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ce76ebcf-2bb0-445d-a4bd-156917fae84f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e45f59e0-aadb-44f6-b418-7b8882278307"));
        }
    }
}
