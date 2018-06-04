using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1.Migrations
{
    public partial class RouteReview6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RouteReviews_Users_UserID",
                table: "RouteReviews");

            migrationBuilder.DropIndex(
                name: "IX_RouteReviews_UserID",
                table: "RouteReviews");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "RouteReviews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "RouteReviews",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RouteReviews_UserID",
                table: "RouteReviews",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_RouteReviews_Users_UserID",
                table: "RouteReviews",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
