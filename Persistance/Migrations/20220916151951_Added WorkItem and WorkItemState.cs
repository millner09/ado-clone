using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class AddedWorkItemandWorkItemState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkItemType = table.Column<int>(type: "int", nullable: false),
                    CurrentStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkItemStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkItemBaseState = table.Column<int>(type: "int", nullable: false),
                    Default = table.Column<bool>(type: "bit", nullable: false),
                    WorkItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItemStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkItemStates_WorkItems_WorkItemId",
                        column: x => x.WorkItemId,
                        principalTable: "WorkItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkItems_CurrentStateId",
                table: "WorkItems",
                column: "CurrentStateId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItemStates_WorkItemId",
                table: "WorkItemStates",
                column: "WorkItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_WorkItemStates_CurrentStateId",
                table: "WorkItems",
                column: "CurrentStateId",
                principalTable: "WorkItemStates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_WorkItemStates_CurrentStateId",
                table: "WorkItems");

            migrationBuilder.DropTable(
                name: "WorkItemStates");

            migrationBuilder.DropTable(
                name: "WorkItems");
        }
    }
}
