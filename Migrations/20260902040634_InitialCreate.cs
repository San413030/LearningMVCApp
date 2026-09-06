using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningPlatform.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterCourses",
                columns: table => new
                {
                    MasterCourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterCourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterCourses", x => x.MasterCourseId);
                });

            migrationBuilder.CreateTable(
                name: "SubCourses",
                columns: table => new
                {
                    SubCourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterCourseId = table.Column<int>(type: "int", nullable: false),
                    SubCourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCourses", x => x.SubCourseId);
                    table.ForeignKey(
                        name: "FK_SubCourses_MasterCourses_MasterCourseId",
                        column: x => x.MasterCourseId,
                        principalTable: "MasterCourses",
                        principalColumn: "MasterCourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCourses_MasterCourseId",
                table: "SubCourses",
                column: "MasterCourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubCourses");

            migrationBuilder.DropTable(
                name: "MasterCourses");
        }
    }
}
