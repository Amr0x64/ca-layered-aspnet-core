using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NoteMigr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentNoteId",
                table: "Notes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ParentNoteId",
                table: "Notes",
                column: "ParentNoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Notes_ParentNoteId",
                table: "Notes",
                column: "ParentNoteId",
                principalTable: "Notes",
                principalColumn: "NoteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Notes_ParentNoteId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_ParentNoteId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "ParentNoteId",
                table: "Notes");
        }
    }
}
