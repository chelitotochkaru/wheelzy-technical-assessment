using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Wheelzy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseVersion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Brands_MakeId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Trackings_StatusId",
                table: "Trackings");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Submodel",
                table: "Cars");

            migrationBuilder.AddColumn<DateTime>(
                name: "PickedUpDate",
                table: "Sells",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubmodelId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Submodels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submodels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submodels_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Ford" },
                    { 2, "Chrevrolet" }
                });

            migrationBuilder.InsertData(
                table: "Buyers",
                columns: new[] { "Id", "Amount", "Name" },
                values: new object[,]
                {
                    { 1, 800m, "John" },
                    { 2, 300m, "George" },
                    { 3, 500m, "Sam" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Acceptance" },
                    { 3, "Accepted" },
                    { 4, "Picked Up" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "Description" },
                values: new object[,]
                {
                    { 1, 1, "EcoSport" },
                    { 2, 1, "Focus" },
                    { 3, 2, "Cruze" },
                    { 4, 2, "Spark" }
                });

            migrationBuilder.InsertData(
                table: "Submodels",
                columns: new[] { "Id", "Description", "ModelId" },
                values: new object[,]
                {
                    { 1, "Base", 1 },
                    { 2, "S", 1 },
                    { 3, "Base", 2 },
                    { 4, "Eco", 2 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "MakeId", "ModelId", "SubmodelId", "Year", "ZipCode" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 2018, 30033 },
                    { 2, 1, 2, 2, 2018, 20110 },
                    { 3, 2, 1, 1, 2018, 30315 },
                    { 4, 2, 2, 2, 2018, 22003 }
                });

            migrationBuilder.InsertData(
                table: "Sells",
                columns: new[] { "Id", "BuyerId", "CarId", "PickedUpDate", "StatusId" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, 2, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 }
                });

            migrationBuilder.InsertData(
                table: "Trackings",
                columns: new[] { "Id", "SellId", "StatusId", "Timestamp" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 1, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, 2, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, 3, new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trackings_StatusId",
                table: "Trackings",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_MakeId_ModelId_SubmodelId",
                table: "Cars",
                columns: new[] { "MakeId", "ModelId", "SubmodelId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelId",
                table: "Cars",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_SubmodelId",
                table: "Cars",
                column: "SubmodelId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Submodels_ModelId",
                table: "Submodels",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Brands_MakeId",
                table: "Cars",
                column: "MakeId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Models_ModelId",
                table: "Cars",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Submodels_SubmodelId",
                table: "Cars",
                column: "SubmodelId",
                principalTable: "Submodels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Brands_MakeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Models_ModelId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Submodels_SubmodelId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Submodels");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Trackings_StatusId",
                table: "Trackings");

            migrationBuilder.DropIndex(
                name: "IX_Cars_MakeId_ModelId_SubmodelId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ModelId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_SubmodelId",
                table: "Cars");

            migrationBuilder.DeleteData(
                table: "Buyers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trackings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trackings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trackings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trackings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sells",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sells",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Buyers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Buyers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "PickedUpDate",
                table: "Sells");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "SubmodelId",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Submodel",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Trackings_StatusId",
                table: "Trackings",
                column: "StatusId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Brands_MakeId",
                table: "Cars",
                column: "MakeId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
