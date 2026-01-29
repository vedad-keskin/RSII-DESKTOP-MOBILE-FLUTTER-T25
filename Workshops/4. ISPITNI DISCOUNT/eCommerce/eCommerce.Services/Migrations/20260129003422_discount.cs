using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eCommerce.Services.Migrations
{
    /// <inheritdoc />
    public partial class discount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductDiscounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDiscounts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 563, DateTimeKind.Utc).AddTicks(45));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 563, DateTimeKind.Utc).AddTicks(46));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 563, DateTimeKind.Utc).AddTicks(47));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 563, DateTimeKind.Utc).AddTicks(48));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 563, DateTimeKind.Utc).AddTicks(49));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 563, DateTimeKind.Utc).AddTicks(50));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 563, DateTimeKind.Utc).AddTicks(51));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 563, DateTimeKind.Utc).AddTicks(51));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 563, DateTimeKind.Utc).AddTicks(52));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 563, DateTimeKind.Utc).AddTicks(53));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 563, DateTimeKind.Utc).AddTicks(119));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 563, DateTimeKind.Utc).AddTicks(120));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 563, DateTimeKind.Utc).AddTicks(104));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 563, DateTimeKind.Utc).AddTicks(105));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2026, 1, 29, 0, 34, 22, 562, DateTimeKind.Utc).AddTicks(9788), "Elektronski ure?aji" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 562, DateTimeKind.Utc).AddTicks(9789));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 562, DateTimeKind.Utc).AddTicks(9791));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2026, 1, 29, 0, 34, 22, 562, DateTimeKind.Utc).AddTicks(9792), "Laptopi i desktop ra?unari", "Ra?unari" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OrderDate", "ShippingAddress" },
                values: new object[] { new DateTime(2026, 1, 29, 0, 34, 22, 563, DateTimeKind.Utc).AddTicks(132), "Mar?ala Tita 12" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 563, DateTimeKind.Utc).AddTicks(137));

            migrationBuilder.InsertData(
                table: "ProductDiscounts",
                columns: new[] { "Id", "DateFrom", "DateTo", "Discount", "ProductId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 29, 1, 34, 22, 563, DateTimeKind.Local).AddTicks(174), new DateTime(2026, 2, 23, 1, 34, 22, 563, DateTimeKind.Local).AddTicks(212), 15.00m, 1 },
                    { 2, new DateTime(2026, 1, 29, 1, 34, 22, 563, DateTimeKind.Local).AddTicks(216), new DateTime(2026, 2, 3, 1, 34, 22, 563, DateTimeKind.Local).AddTicks(217), 20.00m, 2 },
                    { 3, new DateTime(2026, 1, 29, 1, 34, 22, 563, DateTimeKind.Local).AddTicks(218), new DateTime(2026, 2, 8, 1, 34, 22, 563, DateTimeKind.Local).AddTicks(219), 10.00m, 3 }
                });

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Comment", "CreatedAt" },
                values: new object[] { "Odli?an telefon!", new DateTime(2026, 1, 29, 0, 34, 22, 563, DateTimeKind.Utc).AddTicks(91) });

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Comment", "CreatedAt" },
                values: new object[] { "Odli?na knjiga za po?etnike.", new DateTime(2026, 1, 29, 0, 34, 22, 563, DateTimeKind.Utc).AddTicks(92) });

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2026, 1, 29, 0, 34, 22, 562, DateTimeKind.Utc).AddTicks(9875), "Fizi?ka roba", "Fizi?ki" });

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 562, DateTimeKind.Utc).AddTicks(9876));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 562, DateTimeKind.Utc).AddTicks(9948));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 562, DateTimeKind.Utc).AddTicks(9953));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 562, DateTimeKind.Utc).AddTicks(9955));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 562, DateTimeKind.Utc).AddTicks(9957));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2026, 1, 29, 0, 34, 22, 562, DateTimeKind.Utc).AddTicks(9959), "Slu?alice sa poni?tavanjem buke." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 562, DateTimeKind.Utc).AddTicks(9961));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2026, 1, 29, 0, 34, 22, 562, DateTimeKind.Utc).AddTicks(9963), "Ure?aj za ?itanje e-knjiga." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2026, 1, 29, 0, 34, 22, 562, DateTimeKind.Utc).AddTicks(9965), "Nau?ite C# uz ovaj sveobuhvatni vodi?." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2026, 1, 29, 0, 34, 22, 562, DateTimeKind.Utc).AddTicks(9967), "Napredni be?i?ni mi?." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 562, DateTimeKind.Utc).AddTicks(9971));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 562, DateTimeKind.Utc).AddTicks(9908));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 562, DateTimeKind.Utc).AddTicks(9910));

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasure",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 562, DateTimeKind.Utc).AddTicks(9891));

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasure",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2026, 1, 29, 0, 34, 22, 562, DateTimeKind.Utc).AddTicks(9892), "Te?ina u kilogramima" });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAssigned",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 563, DateTimeKind.Utc).AddTicks(160));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAssigned",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 563, DateTimeKind.Utc).AddTicks(162));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 562, DateTimeKind.Utc).AddTicks(9926));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 29, 0, 34, 22, 562, DateTimeKind.Utc).AddTicks(9928));

            migrationBuilder.CreateIndex(
                name: "IX_ProductDiscounts_ProductId",
                table: "ProductDiscounts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDiscounts");

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6129));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6130));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6131));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6132));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6133));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6134));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6135));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6135));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6136));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6137));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6231));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6232));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6189));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(5911), "Elektronski ureðaji" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(5912));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(5914));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(5915), "Laptopi i desktop raèunari", "Raèunari" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OrderDate", "ShippingAddress" },
                values: new object[] { new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6245), "Maršala Tita 12" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Comment", "CreatedAt" },
                values: new object[] { "Odlièan telefon!", new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6174) });

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Comment", "CreatedAt" },
                values: new object[] { "Odlièna knjiga za poèetnike.", new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6177) });

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(5986), "Fizièka roba", "Fizièki" });

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(5987));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6090));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6094));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6096));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6098));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6100), "Slušalice sa poništavanjem buke." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6102));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6104), "Ureðaj za èitanje e-knjiga." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6106), "Nauèite C# uz ovaj sveobuhvatni vodiè." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6108), "Napredni bežièni miš." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6110));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasure",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6003));

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasure",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6004), "Težina u kilogramima" });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAssigned",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6274));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAssigned",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6276));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6071));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 23, 49, 40, 476, DateTimeKind.Utc).AddTicks(6073));
        }
    }
}
