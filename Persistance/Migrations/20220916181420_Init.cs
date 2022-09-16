using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthProviderId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkItemTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkItemTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkItems_WorkItemTypes_WorkItemTypeId",
                        column: x => x.WorkItemTypeId,
                        principalTable: "WorkItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkItemStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkItemBaseState = table.Column<int>(type: "int", nullable: false),
                    WorkItemTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItemStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkItemStates_WorkItemTypes_WorkItemTypeId",
                        column: x => x.WorkItemTypeId,
                        principalTable: "WorkItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "WorkItemTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("cdb05cfd-d4ea-4931-adcd-5b57a65b9f33"), "User Story" });

            migrationBuilder.InsertData(
                table: "WorkItemStates",
                columns: new[] { "Id", "Name", "WorkItemBaseState", "WorkItemTypeId" },
                values: new object[,]
                {
                    { new Guid("1cf9a860-6815-46ce-b5a2-400711a5c508"), "New", 0, new Guid("cdb05cfd-d4ea-4931-adcd-5b57a65b9f33") },
                    { new Guid("215c9008-5608-4c7d-a183-8bb8ccd179f6"), "Closed", 2, new Guid("cdb05cfd-d4ea-4931-adcd-5b57a65b9f33") },
                    { new Guid("53eba1e9-91ec-4332-bade-b428420919d0"), "Resolved", 1, new Guid("cdb05cfd-d4ea-4931-adcd-5b57a65b9f33") },
                    { new Guid("6d68864c-366d-4d60-95b1-f1a8c52bcfbb"), "Removed", 3, new Guid("cdb05cfd-d4ea-4931-adcd-5b57a65b9f33") },
                    { new Guid("8c63c9ab-f57a-4395-b01b-429f72d7c39b"), "Active", 1, new Guid("cdb05cfd-d4ea-4931-adcd-5b57a65b9f33") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkItems_WorkItemTypeId",
                table: "WorkItems",
                column: "WorkItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItemStates_WorkItemTypeId",
                table: "WorkItemStates",
                column: "WorkItemTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "WorkItems");

            migrationBuilder.DropTable(
                name: "WorkItemStates");

            migrationBuilder.DropTable(
                name: "WorkItemTypes");
        }
    }
}
