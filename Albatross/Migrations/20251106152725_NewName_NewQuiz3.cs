using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Albatross.Migrations
{
    /// <inheritdoc />
    public partial class NewName_NewQuiz3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_AspNetUsers_UserId",
                table: "Modules");

            migrationBuilder.DeleteData(
                table: "ModuleTopics",
                keyColumn: "ModuleTopicId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "ModuleTopics",
                keyColumn: "ModuleTopicId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 5);

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Modules",
                newName: "userId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_AspNetUsers_userId",
                table: "Modules");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Modules",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Modules_userId",
                table: "Modules",
                newName: "IX_Modules_UserId");

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "ModuleId", "ModuleName", "UserId" },
                values: new object[,]
                {
                    { 5, "Your Quizzes", null },
                    { 6, "Browse Quizzes", null }
                });

            migrationBuilder.InsertData(
                table: "ModuleTopics",
                columns: new[] { "ModuleTopicId", "ModuleId", "ModuleTopicName" },
                values: new object[,]
                {
                    { 116, 5, "Demo: Alphabet" },
                    { 117, 5, "Demo: Numbers" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_AspNetUsers_UserId",
                table: "Modules",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
