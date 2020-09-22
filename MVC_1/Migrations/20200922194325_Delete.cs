using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_1.Migrations
{
    public partial class Delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber_Person",
                table: "phonenumber");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumber_Person",
                table: "phonenumber",
                column: "PersonID",
                principalTable: "person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber_Person",
                table: "phonenumber");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumber_Person",
                table: "phonenumber",
                column: "PersonID",
                principalTable: "person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
