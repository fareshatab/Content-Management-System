using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisments");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "BaseEntities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "BaseEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "BaseEntities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Post_Title",
                table: "BaseEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "BaseEntities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebURL",
                table: "BaseEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntities_OwnerID",
                table: "BaseEntities",
                column: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntities_AspNetUsers_OwnerID",
                table: "BaseEntities",
                column: "OwnerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntities_AspNetUsers_OwnerID",
                table: "BaseEntities");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntities_OwnerID",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "Post_Title",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "WebURL",
                table: "BaseEntities");

            migrationBuilder.CreateTable(
                name: "Advertisments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertisments_AspNetUsers_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisments_OwnerID",
                table: "Advertisments",
                column: "OwnerID");
        }
    }
}
