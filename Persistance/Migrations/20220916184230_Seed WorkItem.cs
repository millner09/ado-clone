using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class SeedWorkItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkItemStates",
                keyColumn: "Id",
                keyValue: new Guid("1cf9a860-6815-46ce-b5a2-400711a5c508"));

            migrationBuilder.DeleteData(
                table: "WorkItemStates",
                keyColumn: "Id",
                keyValue: new Guid("215c9008-5608-4c7d-a183-8bb8ccd179f6"));

            migrationBuilder.DeleteData(
                table: "WorkItemStates",
                keyColumn: "Id",
                keyValue: new Guid("53eba1e9-91ec-4332-bade-b428420919d0"));

            migrationBuilder.DeleteData(
                table: "WorkItemStates",
                keyColumn: "Id",
                keyValue: new Guid("6d68864c-366d-4d60-95b1-f1a8c52bcfbb"));

            migrationBuilder.DeleteData(
                table: "WorkItemStates",
                keyColumn: "Id",
                keyValue: new Guid("8c63c9ab-f57a-4395-b01b-429f72d7c39b"));

            migrationBuilder.DeleteData(
                table: "WorkItemTypes",
                keyColumn: "Id",
                keyValue: new Guid("cdb05cfd-d4ea-4931-adcd-5b57a65b9f33"));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "WorkItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Title",
                table: "WorkItems");

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
        }
    }
}
