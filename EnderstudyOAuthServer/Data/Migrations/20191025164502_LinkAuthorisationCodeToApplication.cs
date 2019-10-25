using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnderstudyOAuthServer.Data.Migrations
{
    public partial class LinkAuthorisationCodeToApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationId",
                table: "AuthorisationCodes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorisationCodes_ApplicationId",
                table: "AuthorisationCodes",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorisationCodes_Applications_ApplicationId",
                table: "AuthorisationCodes",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorisationCodes_Applications_ApplicationId",
                table: "AuthorisationCodes");

            migrationBuilder.DropIndex(
                name: "IX_AuthorisationCodes_ApplicationId",
                table: "AuthorisationCodes");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "AuthorisationCodes");
        }
    }
}
