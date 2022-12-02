using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AldagiTPL.Migrations
{
    public partial class changingstatusfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TPLRequests");

            migrationBuilder.AddColumn<int>(
                name: "StatusTPLStatusId",
                table: "TPLRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TPLStatusId",
                table: "TPLRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TPLRequests_StatusTPLStatusId",
                table: "TPLRequests",
                column: "StatusTPLStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_TPLRequests_TPLStatuses_StatusTPLStatusId",
                table: "TPLRequests",
                column: "StatusTPLStatusId",
                principalTable: "TPLStatuses",
                principalColumn: "TPLStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TPLRequests_TPLStatuses_StatusTPLStatusId",
                table: "TPLRequests");

            migrationBuilder.DropIndex(
                name: "IX_TPLRequests_StatusTPLStatusId",
                table: "TPLRequests");

            migrationBuilder.DropColumn(
                name: "StatusTPLStatusId",
                table: "TPLRequests");

            migrationBuilder.DropColumn(
                name: "TPLStatusId",
                table: "TPLRequests");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "TPLRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
