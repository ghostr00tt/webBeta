using Microsoft.EntityFrameworkCore.Migrations;

namespace BiOgrenBeta.Migrations
{
    public partial class addCourseCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "TestClasses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseCategories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCategories", x => x.CategoryID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestClasses_CategoryID",
                table: "TestClasses",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_TestClasses_CourseCategories_CategoryID",
                table: "TestClasses",
                column: "CategoryID",
                principalTable: "CourseCategories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestClasses_CourseCategories_CategoryID",
                table: "TestClasses");

            migrationBuilder.DropTable(
                name: "CourseCategories");

            migrationBuilder.DropIndex(
                name: "IX_TestClasses_CategoryID",
                table: "TestClasses");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "TestClasses");
        }
    }
}
