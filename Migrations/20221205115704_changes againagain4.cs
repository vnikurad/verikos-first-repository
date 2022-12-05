using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AldagiTPL.Migrations
{
    public partial class changesagainagain4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarkId",
                table: "TPLRequests");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "TPLRequests");

            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "TPLRequests");

            migrationBuilder.DropColumn(
                name: "VehicleYear",
                table: "TPLRequests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MarkId",
                table: "TPLRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ModelId",
                table: "TPLRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "TPLRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VehicleYear",
                table: "TPLRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
