using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Albatross.Migrations
{
    /// <inheritdoc />
    public partial class NewName_NewQuiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATasks");

            migrationBuilder.CreateTable(
                name: "NewQuizzes",
                columns: table => new
                {
                    NewQuizId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NewQuizName = table.Column<string>(type: "TEXT", nullable: false),
                    ModuleTopicId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewQuizzes", x => x.NewQuizId);
                    table.ForeignKey(
                        name: "FK_NewQuizzes_ModuleTopics_ModuleTopicId",
                        column: x => x.ModuleTopicId,
                        principalTable: "ModuleTopics",
                        principalColumn: "ModuleTopicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewQuizzes_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewQuizzes_ModuleTopicId",
                table: "NewQuizzes",
                column: "ModuleTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_NewQuizzes_QuestionId",
                table: "NewQuizzes",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewQuizzes");

            migrationBuilder.CreateTable(
                name: "ATasks",
                columns: table => new
                {
                    ATaskId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModuleTopicId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestionId = table.Column<int>(type: "INTEGER", nullable: false),
                    RewardId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATasks", x => x.ATaskId);
                });
        }
    }
}
