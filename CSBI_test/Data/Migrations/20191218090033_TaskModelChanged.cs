using Microsoft.EntityFrameworkCore.Migrations;

namespace CSBI_test.Data.Migrations
{
    public partial class TaskModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DelegateUserId",
                table: "Task");

            migrationBuilder.AddColumn<string>(
                name: "DelegatedManagerId",
                table: "Task",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_DelegatedManagerId",
                table: "Task",
                column: "DelegatedManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_AspNetUsers_DelegatedManagerId",
                table: "Task",
                column: "DelegatedManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_AspNetUsers_DelegatedManagerId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_DelegatedManagerId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "DelegatedManagerId",
                table: "Task");

            migrationBuilder.AddColumn<int>(
                name: "DelegateUserId",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
