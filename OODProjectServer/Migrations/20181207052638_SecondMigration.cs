using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OODProjectServer.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserItemId",
                table: "CoffeeItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserItems", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeItems_UserItemId",
                table: "CoffeeItems",
                column: "UserItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeItems_UserItems_UserItemId",
                table: "CoffeeItems",
                column: "UserItemId",
                principalTable: "UserItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeItems_UserItems_UserItemId",
                table: "CoffeeItems");

            migrationBuilder.DropTable(
                name: "UserItems");

            migrationBuilder.DropIndex(
                name: "IX_CoffeeItems_UserItemId",
                table: "CoffeeItems");

            migrationBuilder.DropColumn(
                name: "UserItemId",
                table: "CoffeeItems");
        }
    }
}
