using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Albatross.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "ModuleId", "ModuleName", "userId" },
                values: new object[,]
                {
                    { 8, "Your Quizzes", null },
                    { 9, "Browse Quizzes", null }
                });

            migrationBuilder.InsertData(
                table: "ModuleTopics",
                columns: new[] { "ModuleTopicId", "ModuleId", "ModuleTopicName" },
                values: new object[,]
                {
                    { 118, 8, "Demo: Words and phrases" },
                    { 119, 8, "Demo: Nature" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModuleTopics",
                keyColumn: "ModuleTopicId",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "ModuleTopics",
                keyColumn: "ModuleTopicId",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 8);
        }
    }
}
