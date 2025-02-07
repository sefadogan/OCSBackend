using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OCS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreOrderExampleSeedings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "OrderTrackingNo", "ShipmentTrackingNo", "Status" },
                values: new object[] { new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OT-1001", "ST-2001", 0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "OrderTrackingNo", "ReleasedForDistribution", "ShipmentTrackingNo", "Status" },
                values: new object[] { new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "OT-1002", false, "ST-2002", 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedDate", "CustomerId", "DistrictId", "OrderTrackingNo", "ReleasedForDistribution", "ShipmentTrackingNo", "Status" },
                values: new object[,]
                {
                    { 3L, new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "OT-1003", true, "ST-2003", 2 },
                    { 4L, new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "OT-1004", false, "ST-2004", 3 },
                    { 5L, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "OT-1005", true, "ST-2005", 4 },
                    { 6L, new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "OT-1006", false, "ST-2006", 0 },
                    { 7L, new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "OT-1007", true, "ST-2007", 1 },
                    { 8L, new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "OT-1008", false, "ST-2008", 2 },
                    { 9L, new DateTime(2025, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "OT-1009", true, "ST-2009", 3 },
                    { 10L, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "OT-1010", false, "ST-2010", 4 },
                    { 11L, new DateTime(2025, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "OT-1011", true, "ST-2011", 0 },
                    { 12L, new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "OT-1012", false, "ST-2012", 1 },
                    { 13L, new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "OT-1013", true, "ST-2013", 2 },
                    { 14L, new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "OT-1014", false, "ST-2014", 3 },
                    { 15L, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "OT-1015", true, "ST-2015", 4 },
                    { 16L, new DateTime(2025, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "OT-1016", false, "ST-2016", 0 },
                    { 17L, new DateTime(2025, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "OT-1017", true, "ST-2017", 1 },
                    { 18L, new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "OT-1018", false, "ST-2018", 2 },
                    { 19L, new DateTime(2025, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "OT-1019", true, "ST-2019", 3 },
                    { 20L, new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "OT-1020", false, "ST-2020", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "OrderTrackingNo", "ShipmentTrackingNo", "Status" },
                values: new object[] { new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrderTrackingNo-1", "ShipmentTrackingNo-1", 2 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "OrderTrackingNo", "ReleasedForDistribution", "ShipmentTrackingNo", "Status" },
                values: new object[] { new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrderTrackingNo-2", true, "ShipmentTrackingNo-2", 3 });
        }
    }
}
