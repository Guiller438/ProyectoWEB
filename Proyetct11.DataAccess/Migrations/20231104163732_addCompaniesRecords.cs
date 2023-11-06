using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Proyetct11.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addCompaniesRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Quito", "GenApp", "2-324-0361", "170109", "Pichincha", " Edificio Lugano, Luis Cordero E12-114" },
                    { 2, "Quito", "Tecnologia EMUNAY", "+593 99 595 7889", "170310", "Pichincha", " C. 6" },
                    { 3, "Quito", "Chtt Tecnología 2.0", "2-227-9577", "170521", "Pichincha", "Granda Centeno Oe4-550 y Sancho de la Carrera" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
