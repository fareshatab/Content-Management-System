using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialTpc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_BaseEntities_PostId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntities_AspNetUsers_AutherID",
                table: "BaseEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntities_AspNetUsers_OwnerID",
                table: "BaseEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntities_AspNetUsers_PublishedByID",
                table: "BaseEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntities_BaseEntities_CategoryId",
                table: "BaseEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntities_BaseEntities_Track_CategoryId",
                table: "BaseEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_AspNetUsers_UserId",
                table: "notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_notifications",
                table: "notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseEntities",
                table: "BaseEntities");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntities_AutherID",
                table: "BaseEntities");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntities_OwnerID",
                table: "BaseEntities");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntities_Track_CategoryId",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "AutherID",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "Body",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "Name",
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
                name: "Track_CategoryId",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "Track_Status",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "Track_TimeInMintes",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "Track_Title",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "WebURL",
                table: "BaseEntities");

            migrationBuilder.RenameTable(
                name: "notifications",
                newName: "Notifications");

            migrationBuilder.RenameTable(
                name: "BaseEntities",
                newName: "Tracks");

            migrationBuilder.RenameIndex(
                name: "IX_notifications_UserId",
                table: "Notifications",
                newName: "IX_Notifications_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseEntities_PublishedByID",
                table: "Tracks",
                newName: "IX_Tracks_PublishedByID");

            migrationBuilder.RenameIndex(
                name: "IX_BaseEntities_CategoryId",
                table: "Tracks",
                newName: "IX_Tracks_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "TrackURl",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TimeInMintes",
                table: "Tracks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Tracks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PublishedByID",
                table: "Tracks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OwnerName",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Tracks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tracks",
                table: "Tracks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Advertisments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertisments_AspNetUsers_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeInMintes = table.Column<int>(type: "int", nullable: false),
                    AutherID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_AutherID",
                        column: x => x.AutherID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisments_OwnerID",
                table: "Advertisments",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AutherID",
                table: "Posts",
                column: "AutherID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Posts_PostId",
                table: "Attachments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_AspNetUsers_PublishedByID",
                table: "Tracks",
                column: "PublishedByID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Categories_CategoryId",
                table: "Tracks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Posts_PostId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_AspNetUsers_PublishedByID",
                table: "Tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Categories_CategoryId",
                table: "Tracks");

            migrationBuilder.DropTable(
                name: "Advertisments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tracks",
                table: "Tracks");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "notifications");

            migrationBuilder.RenameTable(
                name: "Tracks",
                newName: "BaseEntities");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserId",
                table: "notifications",
                newName: "IX_notifications_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tracks_PublishedByID",
                table: "BaseEntities",
                newName: "IX_BaseEntities_PublishedByID");

            migrationBuilder.RenameIndex(
                name: "IX_Tracks_CategoryId",
                table: "BaseEntities",
                newName: "IX_BaseEntities_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "TrackURl",
                table: "BaseEntities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "BaseEntities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TimeInMintes",
                table: "BaseEntities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "BaseEntities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PublishedByID",
                table: "BaseEntities",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerName",
                table: "BaseEntities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "BaseEntities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AutherID",
                table: "BaseEntities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "BaseEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseEntities",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

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
                name: "Name",
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

            migrationBuilder.AddColumn<int>(
                name: "Track_CategoryId",
                table: "BaseEntities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Track_Status",
                table: "BaseEntities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Track_TimeInMintes",
                table: "BaseEntities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Track_Title",
                table: "BaseEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebURL",
                table: "BaseEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_notifications",
                table: "notifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseEntities",
                table: "BaseEntities",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntities_AutherID",
                table: "BaseEntities",
                column: "AutherID");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntities_OwnerID",
                table: "BaseEntities",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntities_Track_CategoryId",
                table: "BaseEntities",
                column: "Track_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_BaseEntities_PostId",
                table: "Attachments",
                column: "PostId",
                principalTable: "BaseEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntities_AspNetUsers_AutherID",
                table: "BaseEntities",
                column: "AutherID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntities_AspNetUsers_OwnerID",
                table: "BaseEntities",
                column: "OwnerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntities_AspNetUsers_PublishedByID",
                table: "BaseEntities",
                column: "PublishedByID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntities_BaseEntities_CategoryId",
                table: "BaseEntities",
                column: "CategoryId",
                principalTable: "BaseEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntities_BaseEntities_Track_CategoryId",
                table: "BaseEntities",
                column: "Track_CategoryId",
                principalTable: "BaseEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_AspNetUsers_UserId",
                table: "notifications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
