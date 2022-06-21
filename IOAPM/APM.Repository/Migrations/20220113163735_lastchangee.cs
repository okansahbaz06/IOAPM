using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APM.Repository.Migrations
{
    public partial class lastchangee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "APM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 1, 13, 19, 29, 6, 144, DateTimeKind.Local).AddTicks(722), new TimeSpan(701461440732) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "ACTIVITIES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 1, 13, 19, 29, 6, 144, DateTimeKind.Local).AddTicks(7074), new TimeSpan(701461447085) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 1, 13, 19, 29, 6, 142, DateTimeKind.Local).AddTicks(5854), new TimeSpan(701461425865) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 1, 13, 19, 29, 6, 142, DateTimeKind.Local).AddTicks(9681), new TimeSpan(701461429690) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "CUSTOMERS",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 1, 13, 19, 29, 6, 142, DateTimeKind.Local).AddTicks(9822), new TimeSpan(701461429825) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 1, 13, 19, 29, 6, 140, DateTimeKind.Local).AddTicks(2508), new TimeSpan(701461416608) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 1, 13, 19, 29, 6, 142, DateTimeKind.Local).AddTicks(2716), new TimeSpan(701461422729) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "EMPLOYEES",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 1, 13, 19, 29, 6, 142, DateTimeKind.Local).AddTicks(3013), new TimeSpan(701461423017) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 1, 13, 19, 29, 6, 143, DateTimeKind.Local).AddTicks(2237), new TimeSpan(701461432247) });

            migrationBuilder.UpdateData(
                schema: "APM",
                table: "PROJECTS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATED_DATE", "CREATED_TIME" },
                values: new object[] { new DateTime(2022, 1, 13, 19, 29, 6, 143, DateTimeKind.Local).AddTicks(8123), new TimeSpan(701461438133) });
        }
    }
}
