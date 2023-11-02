using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Proyetct11.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addProductstoDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "Description", "ListPrice", "Price", "Price100", "Price50", "Seller", "Title" },
                values: new object[,]
                {
                    { 1, "SWD9999001", "Un router es un dispositivo que proporciona Wi-Fi y que generalmente está conectado a un módem. Envía información desde Internet a los dispositivos personales\r\n\r\n, como computadoras, teléfonos o tablets.", 99.0, 90.0, 80.0, 85.0, "Vianet", "Router Innalabrico" },
                    { 2, "CAW777777701", "Version más sofisticadas de los modelos tradicionales. Están diseñados  \r\n\r\npara mejorar el rendimiento y optimizar la gestión de usuarios. ", 40.0, 30.0, 20.0, 25.0, "Vianet", "Router Gamer" },
                    { 3, "PLANGAMER", "150 megas ilimitados, Velocidad simétrica, Trabaja, Estudia, Juegos en línea y Calidad 4K ", 55.0, 50.0, 35.0, 40.0, "Vianet", "Plan megas gamer" },
                    { 4, "PLANBASICO", "60 megas ilimitados,Velocidad simétrica, Trabaja y Estudia", 70.0, 65.0, 55.0, 60.0, "Abby Muscles", "Plan basico" },
                    { 5, "SOTJ1111111101", "Guía de onda en forma de hilo de material altamente transparente diseñado para transmitir información a grandes distancias utilizando señales ópticas.\r\n\r\nfabricado a partir de sílice de muy alta pureza; con sólo 2 kg. de este material pueden fabricarse más de 40 kms. ", 30.0, 27.0, 20.0, 25.0, "Vianet", "Fibra optica 50 metros" },
                    { 6, "FOT000000001", "Guía de onda en forma de hilo de material altamente transparente diseñado para transmitir información a grandes distancias utilizando señales ópticas.\r\n\r\nfabricado a partir de sílice de muy alta pureza; con sólo 2 kg. de este material pueden fabricarse más de 40 kms. ", 25.0, 23.0, 20.0, 22.0, "Vianet", "Fibra optica 100 metros" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
