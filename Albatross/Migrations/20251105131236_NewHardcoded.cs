using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Albatross.Migrations
{
    /// <inheritdoc />
    public partial class NewHardcoded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ModuleTopics",
                columns: new[] { "ModuleTopicId", "ModuleId", "ModuleTopicName" },
                values: new object[,]
                {
                    { 114, 10, "Demo: Alphabet" },
                    { 115, 10, "Demo: Numbers" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModuleTopics",
                keyColumn: "ModuleTopicId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "ModuleTopics",
                keyColumn: "ModuleTopicId",
                keyValue: 115);
        }
    }
}
