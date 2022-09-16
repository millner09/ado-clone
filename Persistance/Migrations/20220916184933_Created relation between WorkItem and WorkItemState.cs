using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class CreatedrelationbetweenWorkItemandWorkItemState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkItemStates",
                keyColumn: "Id",
                keyValue: new Guid("2ea4afa0-b2cf-4cf1-bfa4-d8b975412ccb"));

            migrationBuilder.DeleteData(
                table: "WorkItemStates",
                keyColumn: "Id",
                keyValue: new Guid("ac23df95-30a9-4bd9-bd8f-db1ee4024525"));

            migrationBuilder.DeleteData(
                table: "WorkItemStates",
                keyColumn: "Id",
                keyValue: new Guid("af304833-a099-4103-81c1-6701d3ce7f23"));

            migrationBuilder.DeleteData(
                table: "WorkItemStates",
                keyColumn: "Id",
                keyValue: new Guid("c32f27c7-b77d-494b-a5e7-c5846537562f"));

            migrationBuilder.DeleteData(
                table: "WorkItemStates",
                keyColumn: "Id",
                keyValue: new Guid("e25ee486-41aa-44b3-8897-95528d5b7b9d"));

            migrationBuilder.DeleteData(
                table: "WorkItems",
                keyColumn: "Id",
                keyValue: new Guid("2e21d546-e35e-40da-878f-c99baeac247e"));

            migrationBuilder.DeleteData(
                table: "WorkItemTypes",
                keyColumn: "Id",
                keyValue: new Guid("5fe4f257-f7a3-4996-9818-b72098dcb59c"));

            migrationBuilder.AddColumn<Guid>(
                name: "WorkItemStateId",
                table: "WorkItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "WorkItemTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("4289d687-3f68-4079-9399-8dd6ba3b7d84"), "User Story" });

            migrationBuilder.InsertData(
                table: "WorkItemStates",
                columns: new[] { "Id", "Name", "WorkItemBaseState", "WorkItemTypeId" },
                values: new object[,]
                {
                    { new Guid("250b3eb8-1100-454b-8ca5-dd840b45d354"), "Removed", 3, new Guid("4289d687-3f68-4079-9399-8dd6ba3b7d84") },
                    { new Guid("5e77b602-d769-41e9-85e6-91da32284057"), "Resolved", 1, new Guid("4289d687-3f68-4079-9399-8dd6ba3b7d84") },
                    { new Guid("6ade6878-0311-4454-8cc8-4ab2afc1582b"), "Closed", 2, new Guid("4289d687-3f68-4079-9399-8dd6ba3b7d84") },
                    { new Guid("72ad6b05-eebd-4f8d-8b51-34902a77e754"), "Active", 1, new Guid("4289d687-3f68-4079-9399-8dd6ba3b7d84") },
                    { new Guid("d0b1d039-42c8-4686-bb9d-217ea591acbc"), "New", 0, new Guid("4289d687-3f68-4079-9399-8dd6ba3b7d84") }
                });

            migrationBuilder.InsertData(
                table: "WorkItems",
                columns: new[] { "Id", "Title", "WorkItemStateId", "WorkItemTypeId" },
                values: new object[] { new Guid("a843d8fa-07f2-41ce-bf7b-95e2d832585a"), "Seed User Story in Database", new Guid("d0b1d039-42c8-4686-bb9d-217ea591acbc"), new Guid("4289d687-3f68-4079-9399-8dd6ba3b7d84") });

            migrationBuilder.CreateIndex(
                name: "IX_WorkItems_WorkItemStateId",
                table: "WorkItems",
                column: "WorkItemStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkItems_WorkItemStates_WorkItemStateId",
                table: "WorkItems",
                column: "WorkItemStateId",
                principalTable: "WorkItemStates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkItems_WorkItemStates_WorkItemStateId",
                table: "WorkItems");

            migrationBuilder.DropIndex(
                name: "IX_WorkItems_WorkItemStateId",
                table: "WorkItems");

            migrationBuilder.DeleteData(
                table: "WorkItemStates",
                keyColumn: "Id",
                keyValue: new Guid("250b3eb8-1100-454b-8ca5-dd840b45d354"));

            migrationBuilder.DeleteData(
                table: "WorkItemStates",
                keyColumn: "Id",
                keyValue: new Guid("5e77b602-d769-41e9-85e6-91da32284057"));

            migrationBuilder.DeleteData(
                table: "WorkItemStates",
                keyColumn: "Id",
                keyValue: new Guid("6ade6878-0311-4454-8cc8-4ab2afc1582b"));

            migrationBuilder.DeleteData(
                table: "WorkItemStates",
                keyColumn: "Id",
                keyValue: new Guid("72ad6b05-eebd-4f8d-8b51-34902a77e754"));

            migrationBuilder.DeleteData(
                table: "WorkItems",
                keyColumn: "Id",
                keyValue: new Guid("a843d8fa-07f2-41ce-bf7b-95e2d832585a"));

            migrationBuilder.DeleteData(
                table: "WorkItemStates",
                keyColumn: "Id",
                keyValue: new Guid("d0b1d039-42c8-4686-bb9d-217ea591acbc"));

            migrationBuilder.DeleteData(
                table: "WorkItemTypes",
                keyColumn: "Id",
                keyValue: new Guid("4289d687-3f68-4079-9399-8dd6ba3b7d84"));

            migrationBuilder.DropColumn(
                name: "WorkItemStateId",
                table: "WorkItems");

            migrationBuilder.InsertData(
                table: "WorkItemTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5fe4f257-f7a3-4996-9818-b72098dcb59c"), "User Story" });

            migrationBuilder.InsertData(
                table: "WorkItemStates",
                columns: new[] { "Id", "Name", "WorkItemBaseState", "WorkItemTypeId" },
                values: new object[,]
                {
                    { new Guid("2ea4afa0-b2cf-4cf1-bfa4-d8b975412ccb"), "Closed", 2, new Guid("5fe4f257-f7a3-4996-9818-b72098dcb59c") },
                    { new Guid("ac23df95-30a9-4bd9-bd8f-db1ee4024525"), "Active", 1, new Guid("5fe4f257-f7a3-4996-9818-b72098dcb59c") },
                    { new Guid("af304833-a099-4103-81c1-6701d3ce7f23"), "New", 0, new Guid("5fe4f257-f7a3-4996-9818-b72098dcb59c") },
                    { new Guid("c32f27c7-b77d-494b-a5e7-c5846537562f"), "Resolved", 1, new Guid("5fe4f257-f7a3-4996-9818-b72098dcb59c") },
                    { new Guid("e25ee486-41aa-44b3-8897-95528d5b7b9d"), "Removed", 3, new Guid("5fe4f257-f7a3-4996-9818-b72098dcb59c") }
                });

            migrationBuilder.InsertData(
                table: "WorkItems",
                columns: new[] { "Id", "Title", "WorkItemTypeId" },
                values: new object[] { new Guid("2e21d546-e35e-40da-878f-c99baeac247e"), "Seed User Story in Database", new Guid("5fe4f257-f7a3-4996-9818-b72098dcb59c") });
        }
    }
}
