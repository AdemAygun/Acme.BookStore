using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Acme.BookStore.Migrations
{
    public partial class Added_Film : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppFilms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    AuthorId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFilms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppFilms_AppAuthors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AppAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppFilms_AppAuthors_AuthorId1",
                        column: x => x.AuthorId1,
                        principalTable: "AppAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppFilms_AuthorId",
                table: "AppFilms",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppFilms_AuthorId1",
                table: "AppFilms",
                column: "AuthorId1");

            migrationBuilder.CreateIndex(
                name: "IX_AppFilms_Name",
                table: "AppFilms",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppFilms");
        }
    }
}
