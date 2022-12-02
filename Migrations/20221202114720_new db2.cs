using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AldagiTPL.Migrations
{
    public partial class newdb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TPLRequests_TPLStatuses_StatusTPLStatusId",
                table: "TPLRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TPLStatuses",
                table: "TPLStatuses");

            migrationBuilder.RenameTable(
                name: "TPLStatuses",
                newName: "TPLStatus");

            migrationBuilder.RenameColumn(
                name: "TPLStatusId",
                table: "TPLStatus",
                newName: "StatusTPLStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TPLStatus",
                table: "TPLStatus",
                column: "StatusTPLStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_TPLRequests_TPLStatus_StatusTPLStatusId",
                table: "TPLRequests",
                column: "StatusTPLStatusId",
                principalTable: "TPLStatus",
                principalColumn: "StatusTPLStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TPLRequests_TPLStatus_StatusTPLStatusId",
                table: "TPLRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TPLStatus",
                table: "TPLStatus");

            migrationBuilder.RenameTable(
                name: "TPLStatus",
                newName: "TPLStatuses");

            migrationBuilder.RenameColumn(
                name: "StatusTPLStatusId",
                table: "TPLStatuses",
                newName: "TPLStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TPLStatuses",
                table: "TPLStatuses",
                column: "TPLStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_TPLRequests_TPLStatuses_StatusTPLStatusId",
                table: "TPLRequests",
                column: "StatusTPLStatusId",
                principalTable: "TPLStatuses",
                principalColumn: "TPLStatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
