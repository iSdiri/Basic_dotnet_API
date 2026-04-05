using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basic_dotnet_API.Migrations
{
    /// <inheritdoc />
    public partial class LinkFolderToAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Users_UserId",
                table: "Folders");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Folders",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Folders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Folders_AppUserId",
                table: "Folders",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_AppUsers_AppUserId",
                table: "Folders",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Users_UserId",
                table: "Folders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_AppUsers_AppUserId",
                table: "Folders");

            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Users_UserId",
                table: "Folders");

            migrationBuilder.DropIndex(
                name: "IX_Folders_AppUserId",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Folders");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Folders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Users_UserId",
                table: "Folders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
