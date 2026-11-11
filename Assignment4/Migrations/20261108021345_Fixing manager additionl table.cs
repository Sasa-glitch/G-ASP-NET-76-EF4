using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment4.Migrations
{
    /// <inheritdoc />
    public partial class Fixingmanageradditionltable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manager");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    ManagerPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
