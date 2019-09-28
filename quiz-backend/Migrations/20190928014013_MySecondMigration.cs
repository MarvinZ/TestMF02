using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace quiz_backend.Migrations
{
    public partial class MySecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TestField",
                table: "Quiz",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Answer4",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestField",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "Answer4",
                table: "Questions");
        }
    }
}
