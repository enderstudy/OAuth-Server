using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnderstudyOAuthServer.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    OwnerWebsite = table.Column<string>(nullable: true),
                    IsOfficial = table.Column<bool>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthorisationCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UsedAt = table.Column<DateTime>(nullable: false),
                    ExpiresAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorisationCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorisationCodes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccessTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ApplicationId = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUsed = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessTokens_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccessTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserApplications",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserApplications", x => new { x.UserId, x.ApplicationId });
                    table.ForeignKey(
                        name: "FK_UserApplications_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserApplications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessTokenUsageEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccessTokenId = table.Column<Guid>(nullable: true),
                    Endpoint = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessTokenUsageEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessTokenUsageEvents_AccessTokens_AccessTokenId",
                        column: x => x.AccessTokenId,
                        principalTable: "AccessTokens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessTokens_ApplicationId",
                table: "AccessTokens",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessTokens_UserId",
                table: "AccessTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessTokenUsageEvents_AccessTokenId",
                table: "AccessTokenUsageEvents",
                column: "AccessTokenId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_OwnerId",
                table: "Applications",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorisationCodes_UserId",
                table: "AuthorisationCodes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserApplications_ApplicationId",
                table: "UserApplications",
                column: "ApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessTokenUsageEvents");

            migrationBuilder.DropTable(
                name: "AuthorisationCodes");

            migrationBuilder.DropTable(
                name: "UserApplications");

            migrationBuilder.DropTable(
                name: "AccessTokens");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
