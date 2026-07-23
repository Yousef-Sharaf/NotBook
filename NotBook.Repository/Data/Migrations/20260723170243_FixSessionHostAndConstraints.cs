using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotBook.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixSessionHostAndConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Users_HostUserId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_SessionMembers_SessionId",
                table: "SessionMembers");

            migrationBuilder.RenameColumn(
                name: "HostUserId",
                table: "Sessions",
                newName: "UserHostId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_HostUserId",
                table: "Sessions",
                newName: "IX_Sessions_UserHostId");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Sessions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SessionMembers_SessionId_UserId",
                table: "SessionMembers",
                columns: new[] { "SessionId", "UserId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Users_UserHostId",
                table: "Sessions",
                column: "UserHostId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Users_UserHostId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_SessionMembers_SessionId_UserId",
                table: "SessionMembers");

            migrationBuilder.RenameColumn(
                name: "UserHostId",
                table: "Sessions",
                newName: "HostUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_UserHostId",
                table: "Sessions",
                newName: "IX_Sessions_HostUserId");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.CreateIndex(
                name: "IX_SessionMembers_SessionId",
                table: "SessionMembers",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Users_HostUserId",
                table: "Sessions",
                column: "HostUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
