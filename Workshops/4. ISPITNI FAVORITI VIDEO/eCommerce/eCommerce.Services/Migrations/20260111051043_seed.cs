using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eCommerce.Services.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6762));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6763));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6764));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6765));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6766));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6767));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6768));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6769));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6770));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6771));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6858));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6859));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6842));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6844));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6516));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6518));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6520));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6522));

            migrationBuilder.InsertData(
                table: "FavoritiIB180079",
                columns: new[] { "Id", "CreatedAt", "ProductId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6960), 4, 2 },
                    { 2, new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6961), 5, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6872));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6876));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6826));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6829));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6636));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6637));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6724));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6726));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6728));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6730));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6732));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6734));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6736));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6738));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6677));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6678));

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasure",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6655));

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasure",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6657));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAssigned",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6902));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAssigned",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6903));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6697));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 11, 5, 10, 42, 995, DateTimeKind.Utc).AddTicks(6698));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FavoritiIB180079",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FavoritiIB180079",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1815));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1816));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1817));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1818));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1819));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1820));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1821));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1823));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1823));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1906));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1907));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1892));

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1893));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1499));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1501));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1502));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1503));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1926));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1935));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1873));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1611));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1612));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1734));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1743));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1745));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1747));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1751));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1753));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1755));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1757));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1759));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1669));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1670));

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasure",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasure",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1641));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAssigned",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1978));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAssigned",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1981));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1700));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 10, 8, 20, 7, 73, DateTimeKind.Utc).AddTicks(1702));
        }
    }
}
