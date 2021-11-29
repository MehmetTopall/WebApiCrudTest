using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSuperVisor",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "SuperVisorId",
                table: "Employees",
                newName: "ParentId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId1",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeId1",
                table: "Employees",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_EmployeeId1",
                table: "Employees",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_EmployeeId1",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeId1",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Employees",
                newName: "SuperVisorId");

            migrationBuilder.AddColumn<bool>(
                name: "IsSuperVisor",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
