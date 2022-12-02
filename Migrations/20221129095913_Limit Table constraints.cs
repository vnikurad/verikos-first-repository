using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AldagiTPL.Migrations
{
    public partial class LimitTableconstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Limit",
                table: "TPLRequests");

            migrationBuilder.AddColumn<int>(
                name: "LimitId",
                table: "TPLRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TPLRequests_LimitId",
                table: "TPLRequests",
                column: "LimitId");

            migrationBuilder.AddForeignKey(
                name: "FK_TPLRequests_TPLConditions_LimitId",
                table: "TPLRequests",
                column: "LimitId",
                principalTable: "TPLConditions",
                principalColumn: "LimitId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TPLRequests_TPLConditions_LimitId",
                table: "TPLRequests");

            migrationBuilder.DropIndex(
                name: "IX_TPLRequests_LimitId",
                table: "TPLRequests");

            migrationBuilder.DropColumn(
                name: "LimitId",
                table: "TPLRequests");

            migrationBuilder.AddColumn<decimal>(
                name: "Limit",
                table: "TPLRequests",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
