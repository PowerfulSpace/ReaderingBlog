using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReaderingBlog.Migrations
{
    public partial class ConnctVkFacebok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4A536E31-EB55-4652-A7FF-297E7C692867",
                column: "ConcurrencyStamp",
                value: "f28ee478-cd90-47a1-8f41-6e7b80390022");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A3D5C97B-82CB-4ABD-8B76-98EB5C6FA83D",
                column: "ConcurrencyStamp",
                value: "60cef68a-d358-4eaa-b21e-2821acd870d0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0C7E2AC1-22D2-4356-84DA-80986AFE0B87",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3bc1e76e-462b-4c8e-b048-7e75f199473f", "AQAAAAEAACcQAAAAEOvau4hng/rM25OGDS4Jnk+46YdBwlZCApRKML/5/vQMU75YJL5/a8ZXC8IQyXnt0g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "79C11C37-7A5D-46CB-B491-851E5E82725D",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c8be2af4-2f8b-45f0-ac73-9d592dbd8671", "AQAAAAEAACcQAAAAEEWf5u60g174NB6I2y9Er729i5Z0EBbbVtFY3A1/3hGl5dOr0JIIaCE1B93Atc959Q==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("579ad3dc-4ca6-4799-b625-d7e67e02876a"),
                column: "DateAdded",
                value: new DateTime(2021, 12, 3, 14, 42, 36, 817, DateTimeKind.Utc).AddTicks(9885));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("d44378e7-3e17-4dc7-8ca5-13986cc4d3cf"),
                column: "DateAdded",
                value: new DateTime(2021, 12, 3, 14, 42, 36, 817, DateTimeKind.Utc).AddTicks(6773));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("ecc37f52-5903-4f80-9f61-2f795ece1897"),
                column: "DateAdded",
                value: new DateTime(2021, 12, 3, 14, 42, 36, 817, DateTimeKind.Utc).AddTicks(9774));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4A536E31-EB55-4652-A7FF-297E7C692867",
                column: "ConcurrencyStamp",
                value: "bab713d6-84e9-4d17-9107-9babf4696fc4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A3D5C97B-82CB-4ABD-8B76-98EB5C6FA83D",
                column: "ConcurrencyStamp",
                value: "c8934c21-2aec-43ba-b8ac-64314661e62c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0C7E2AC1-22D2-4356-84DA-80986AFE0B87",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c17a093c-6066-4d30-8dba-e35827eb27ee", "AQAAAAEAACcQAAAAEFT/5OHJNkTCyA2BHbNcRyvCS34s5X6pPqHOfXwzNAwEuit1QIcgFOvj7RZ/IcHWSg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "79C11C37-7A5D-46CB-B491-851E5E82725D",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2f330703-4f9d-4c42-8a41-d790ea379ac0", "AQAAAAEAACcQAAAAECIjE50bWmjr0C53ipixeFM9iW41y5eNUMeAbxGNtfXXxHnrRwafDN1HcpBA1ycEGA==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("579ad3dc-4ca6-4799-b625-d7e67e02876a"),
                column: "DateAdded",
                value: new DateTime(2021, 12, 3, 10, 10, 57, 879, DateTimeKind.Utc).AddTicks(7681));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("d44378e7-3e17-4dc7-8ca5-13986cc4d3cf"),
                column: "DateAdded",
                value: new DateTime(2021, 12, 3, 10, 10, 57, 879, DateTimeKind.Utc).AddTicks(4249));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("ecc37f52-5903-4f80-9f61-2f795ece1897"),
                column: "DateAdded",
                value: new DateTime(2021, 12, 3, 10, 10, 57, 879, DateTimeKind.Utc).AddTicks(7578));
        }
    }
}
