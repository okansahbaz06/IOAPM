using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APM.Repository.Migrations
{
    public partial class Publ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "APM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 4, 3, 13, 39, 20, 822, DateTimeKind.Local).AddTicks(191), new TimeSpan(491608220200) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 4, 3, 13, 39, 20, 822, DateTimeKind.Local).AddTicks(4391), new TimeSpan(491608224397) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 4, 3, 13, 39, 20, 820, DateTimeKind.Local).AddTicks(8897), new TimeSpan(491608208905) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 4, 3, 13, 39, 20, 821, DateTimeKind.Local).AddTicks(2092), new TimeSpan(491608212102) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 4, 3, 13, 39, 20, 821, DateTimeKind.Local).AddTicks(2226), new TimeSpan(491608212228) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 4, 3, 13, 39, 20, 818, DateTimeKind.Local).AddTicks(9256), new TimeSpan(491608201735) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 4, 3, 13, 39, 20, 820, DateTimeKind.Local).AddTicks(6547), new TimeSpan(491608206557) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 4, 3, 13, 39, 20, 820, DateTimeKind.Local).AddTicks(6692), new TimeSpan(491608206694) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 4, 3, 13, 39, 20, 821, DateTimeKind.Local).AddTicks(4106), new TimeSpan(491608214115) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 4, 3, 13, 39, 20, 821, DateTimeKind.Local).AddTicks(8382), new TimeSpan(491608218391) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "APM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 1, 13, 19, 37, 34, 291, DateTimeKind.Local).AddTicks(8419), new TimeSpan(706542918442) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 1, 13, 19, 37, 34, 292, DateTimeKind.Local).AddTicks(5726), new TimeSpan(706542925746) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 1, 13, 19, 37, 34, 289, DateTimeKind.Local).AddTicks(5236), new TimeSpan(706542895259) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 1, 13, 19, 37, 34, 290, DateTimeKind.Local).AddTicks(951), new TimeSpan(706542900981) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 1, 13, 19, 37, 34, 290, DateTimeKind.Local).AddTicks(1125), new TimeSpan(706542901128) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 1, 13, 19, 37, 34, 286, DateTimeKind.Local).AddTicks(2561), new TimeSpan(706542880992) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 1, 13, 19, 37, 34, 289, DateTimeKind.Local).AddTicks(200), new TimeSpan(706542890237) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 1, 13, 19, 37, 34, 289, DateTimeKind.Local).AddTicks(977), new TimeSpan(706542891009) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 1, 13, 19, 37, 34, 290, DateTimeKind.Local).AddTicks(6332), new TimeSpan(706542906365) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 1, 13, 19, 37, 34, 291, DateTimeKind.Local).AddTicks(4197), new TimeSpan(706542914225) });
        }
    }
}
