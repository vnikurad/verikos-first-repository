using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AldagiTPL.Migrations
{
    public partial class addingnewtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientIntegration",
                table: "TPLRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Limit",
                table: "TPLRequests",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "TPLConditions",
                columns: table => new
                {
                    LimitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LimitAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientIntegration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPLConditions", x => x.LimitId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TPLConditions");

            migrationBuilder.DropColumn(
                name: "ClientIntegration",
                table: "TPLRequests");

            migrationBuilder.DropColumn(
                name: "Limit",
                table: "TPLRequests");
        }
    }
}
