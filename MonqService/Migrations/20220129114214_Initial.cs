using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MonqService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Subject = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Body = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Result = table.Column<int>(type: "INTEGER", nullable: false),
                    FailedMessage = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recicpients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmailAdress = table.Column<string>(type: "TEXT", nullable: true),
                    MailId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recicpients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recicpients_Mails_MailId",
                        column: x => x.MailId,
                        principalTable: "Mails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recicpients_MailId",
                table: "Recicpients",
                column: "MailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recicpients");

            migrationBuilder.DropTable(
                name: "Mails");
        }
    }
}
