using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AldagiTPL.Migrations
{
    public partial class addingnewfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TPLRequests_TPLConditions_LimitId",
                table: "TPLRequests");

            migrationBuilder.RenameColumn(
                name: "LimitId",
                table: "TPLRequests",
                newName: "LimitAmount");

            migrationBuilder.RenameIndex(
                name: "IX_TPLRequests_LimitId",
                table: "TPLRequests",
                newName: "IX_TPLRequests_LimitAmount");

            migrationBuilder.AddForeignKey(
                name: "FK_TPLRequests_TPLConditions_LimitAmount",
                table: "TPLRequests",
                column: "LimitAmount",
                principalTable: "TPLConditions",
                principalColumn: "LimitId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TPLRequests_TPLConditions_LimitAmount",
                table: "TPLRequests");

            migrationBuilder.RenameColumn(
                name: "LimitAmount",
                table: "TPLRequests",
                newName: "LimitId");

            migrationBuilder.RenameIndex(
                name: "IX_TPLRequests_LimitAmount",
                table: "TPLRequests",
                newName: "IX_TPLRequests_LimitId");

            migrationBuilder.AddForeignKey(
                name: "FK_TPLRequests_TPLConditions_LimitId",
                table: "TPLRequests",
                column: "LimitId",
                principalTable: "TPLConditions",
                principalColumn: "LimitId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
