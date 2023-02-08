using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeAcademyFinalExam.Migrations
{
    /// <inheritdoc />
    public partial class humaninformationppicturetabdeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "HumanInformation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "HumanInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
