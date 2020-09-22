using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_1.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "person",
                columns: new[] { "ID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { -1, "John", "Doe" },
                    { -2, "Jane", "Doe" },
                    { -3, "Todd", "Smith" },
                    { -4, "Sue", "Smith" },
                    { -5, "Joe", "Smithserson" }
                });

            migrationBuilder.InsertData(
                table: "phonenumber",
                columns: new[] { "ID", "Number", "PersonID" },
                values: new object[,]
                {
                    { -1, "800-234-4567", -1 },
                    { -2, "800-234-4567", -2 },
                    { -3, "800-345-5678", -2 },
                    { -4, "800-456-6789", -3 },
                    { -5, "800-987-7654", -4 },
                    { -6, "800-876-6543", -5 },
                    { -7, "800-765-5432", -5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "phonenumber",
                keyColumn: "ID",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "phonenumber",
                keyColumn: "ID",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "phonenumber",
                keyColumn: "ID",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "phonenumber",
                keyColumn: "ID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "phonenumber",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "phonenumber",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "phonenumber",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "ID",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "ID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "ID",
                keyValue: -1);
        }
    }
}
