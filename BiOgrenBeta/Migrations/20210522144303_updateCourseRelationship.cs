using Microsoft.EntityFrameworkCore.Migrations;

namespace BiOgrenBeta.Migrations
{
    public partial class updateCourseRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestClasses_CourseCategories_CategoryID",
                table: "TestClasses");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "TestClasses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TestClasses_CourseCategories_CategoryID",
                table: "TestClasses",
                column: "CategoryID",
                principalTable: "CourseCategories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestClasses_CourseCategories_CategoryID",
                table: "TestClasses");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "TestClasses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TestClasses_CourseCategories_CategoryID",
                table: "TestClasses",
                column: "CategoryID",
                principalTable: "CourseCategories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
