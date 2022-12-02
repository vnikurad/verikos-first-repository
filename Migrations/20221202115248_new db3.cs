using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AldagiTPL.Migrations
{
    public partial class newdb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TPLRequests_TPLStatus_StatusTPLStatusId",
                table: "TPLRequests");

            migrationBuilder.DropIndex(
                name: "IX_TPLRequests_StatusTPLStatusId",
                table: "TPLRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TPLStatus",
                table: "TPLStatus");

            migrationBuilder.DropColumn(
                name: "StatusTPLStatusId",
                table: "TPLRequests");

            migrationBuilder.RenameTable(
                name: "TPLStatus",
                newName: "TPLStatuses");

            migrationBuilder.RenameColumn(
                name: "TPLStatusId",
                table: "TPLRequests",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "StatusTPLStatusId",
                table: "TPLStatuses",
                newName: "TPLStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TPLStatuses",
                table: "TPLStatuses",
                column: "TPLStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TPLRequests_StatusId",
                table: "TPLRequests",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_TPLRequests_TPLStatuses_StatusId",
                table: "TPLRequests",
                column: "StatusId",
                principalTable: "TPLStatuses",
                principalColumn: "TPLStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TPLRequests_TPLStatuses_StatusId",
                table: "TPLRequests");

            migrationBuilder.DropIndex(
                name: "IX_TPLRequests_StatusId",
                table: "TPLRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TPLStatuses",
                table: "TPLStatuses");

            migrationBuilder.RenameTable(
                name: "TPLStatuses",
                newName: "TPLStatus");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "TPLRequests",
                newName: "TPLStatusId");

            migrationBuilder.RenameColumn(
                name: "TPLStatusId",
                table: "TPLStatus",
                newName: "StatusTPLStatusId");

            migrationBuilder.AddColumn<int>(
                name: "StatusTPLStatusId",
                table: "TPLRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TPLStatus",
                table: "TPLStatus",
                column: "StatusTPLStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TPLRequests_StatusTPLStatusId",
                table: "TPLRequests",
                column: "StatusTPLStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_TPLRequests_TPLStatus_StatusTPLStatusId",
                table: "TPLRequests",
                column: "StatusTPLStatusId",
                principalTable: "TPLStatus",
                principalColumn: "StatusTPLStatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
