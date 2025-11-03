using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Albatross.Migrations
{
    /// <inheritdoc />
    public partial class MakeModuleIdNullable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleTopics_Modules_ModuleId",
                table: "ModuleTopics");

            migrationBuilder.AlterColumn<int>(
                name: "ModuleId",
                table: "ModuleTopics",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleTopics_Modules_ModuleId",
                table: "ModuleTopics",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "ModuleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleTopics_Modules_ModuleId",
                table: "ModuleTopics");

            migrationBuilder.AlterColumn<int>(
                name: "ModuleId",
                table: "ModuleTopics",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleTopics_Modules_ModuleId",
                table: "ModuleTopics",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
