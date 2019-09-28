using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace quiz_backend.Migrations
{
    public partial class MyThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestField",
                table: "Quiz");

            migrationBuilder.AddColumn<string>(
                name: "TestFieldXXXXXX",
                table: "Quiz",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestFieldXXXXXX",
                table: "Quiz");

            migrationBuilder.AddColumn<string>(
                name: "TestField",
                table: "Quiz",
                nullable: true);
        }
    }
}
