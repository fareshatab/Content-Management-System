using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class modelPro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AutherID",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "TrackURl",
                table: "Tracks",
                newName: "TrackUrl");

            migrationBuilder.RenameColumn(
                name: "TimeInMintes",
                table: "Tracks",
                newName: "TimeInMinute");

            migrationBuilder.RenameColumn(
                name: "TimeInMintes",
                table: "Posts",
                newName: "TimeInMinute");

            migrationBuilder.RenameColumn(
                name: "AutherID",
                table: "Posts",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AutherID",
                table: "Posts",
                newName: "IX_Posts_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "TrackUrl",
                table: "Tracks",
                newName: "TrackURl");

            migrationBuilder.RenameColumn(
                name: "TimeInMinute",
                table: "Tracks",
                newName: "TimeInMintes");

            migrationBuilder.RenameColumn(
                name: "TimeInMinute",
                table: "Posts",
                newName: "TimeInMintes");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Posts",
                newName: "AutherID");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                newName: "IX_Posts_AutherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AutherID",
                table: "Posts",
                column: "AutherID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
