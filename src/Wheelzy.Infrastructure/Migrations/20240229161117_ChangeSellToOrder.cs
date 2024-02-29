using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Wheelzy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSellToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trackings_Sells_SellId",
                table: "Trackings");

            migrationBuilder.DropTable(
                name: "Sells");

            migrationBuilder.RenameColumn(
                name: "SellId",
                table: "Trackings",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Trackings_SellId",
                table: "Trackings",
                newName: "IX_Trackings_OrderId");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    PickedUpDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Buyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BuyerId", "CarId", "PickedUpDate", "StatusId" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, 2, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuyerId",
                table: "Orders",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarId",
                table: "Orders",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusId",
                table: "Orders",
                column: "StatusId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trackings_Orders_OrderId",
                table: "Trackings",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trackings_Orders_OrderId",
                table: "Trackings");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Trackings",
                newName: "SellId");

            migrationBuilder.RenameIndex(
                name: "IX_Trackings_OrderId",
                table: "Trackings",
                newName: "IX_Trackings_SellId");

            migrationBuilder.CreateTable(
                name: "Sells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    PickedUpDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sells_Buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Buyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sells_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sells_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Sells",
                columns: new[] { "Id", "BuyerId", "CarId", "PickedUpDate", "StatusId" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, 2, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sells_BuyerId",
                table: "Sells",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sells_CarId",
                table: "Sells",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Sells_StatusId",
                table: "Sells",
                column: "StatusId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trackings_Sells_SellId",
                table: "Trackings",
                column: "SellId",
                principalTable: "Sells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
