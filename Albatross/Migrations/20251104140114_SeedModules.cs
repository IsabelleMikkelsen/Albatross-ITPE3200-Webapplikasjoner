using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Albatross.Migrations
{
    /// <inheritdoc />
    public partial class SeedModules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_AspNetUsers_userId",
                table: "Modules");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Modules",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ModuleLevel",
                table: "Modules",
                newName: "IsLocked");

            migrationBuilder.RenameIndex(
                name: "IX_Modules_userId",
                table: "Modules",
                newName: "IX_Modules_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Modules",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "ModuleId", "Description", "IsLocked", "ModuleName", "UserId" },
                values: new object[,]
                {
                    { 10, "Basic Level", false, "A1", null },
                    { 20, "Finish Level A1", true, "A2", null },
                    { 30, "Finish Level A2", true, "B1", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_AspNetUsers_UserId",
                table: "Modules",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_AspNetUsers_UserId",
                table: "Modules");

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 30);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Modules");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Modules",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "IsLocked",
                table: "Modules",
                newName: "ModuleLevel");

            migrationBuilder.RenameIndex(
                name: "IX_Modules_UserId",
                table: "Modules",
                newName: "IX_Modules_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_AspNetUsers_userId",
                table: "Modules",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
