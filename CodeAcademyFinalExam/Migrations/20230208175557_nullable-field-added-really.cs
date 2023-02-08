using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeAcademyFinalExam.Migrations
{
    /// <inheritdoc />
    public partial class nullablefieldaddedreally : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_HumanInformation_HumanInformationId",
                table: "Accounts");

            migrationBuilder.AlterColumn<int>(
                name: "HumanInformationId",
                table: "Accounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_HumanInformation_HumanInformationId",
                table: "Accounts",
                column: "HumanInformationId",
                principalTable: "HumanInformation",
                principalColumn: "HumanInformationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_HumanInformation_HumanInformationId",
                table: "Accounts");

            migrationBuilder.AlterColumn<int>(
                name: "HumanInformationId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_HumanInformation_HumanInformationId",
                table: "Accounts",
                column: "HumanInformationId",
                principalTable: "HumanInformation",
                principalColumn: "HumanInformationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
