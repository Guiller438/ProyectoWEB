using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyetct11.Models;

namespace Proyetct11.DataAccess.Data
{
    public class AplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Routers", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Planes", DisplayOrder = 2 },
                new Category { Id = 3, Name = "FibraOptica", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Router Innalabrico",
                    Seller = "Vianet",
                    Description = "Un router es un dispositivo que proporciona Wi-Fi y que generalmente está conectado a un módem. Envía información desde Internet a los dispositivos personales\r\n\r\n, como computadoras, teléfonos o tablets.",
                    Barcode = "SWD9999001",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    ImageUrl=""
                },
                new Product
                {
                    Id = 2,
                    Title = "Router Gamer",
                    Seller = "Vianet",
                    Description = "Version más sofisticadas de los modelos tradicionales. Están diseñados  \r\n\r\npara mejorar el rendimiento y optimizar la gestión de usuarios. ",
                    Barcode = "CAW777777701",
                    ListPrice = 40,
                    Price = 30,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 3,
                    Title = "Plan megas gamer",
                    Seller = "Vianet",
                    Description = "150 megas ilimitados, Velocidad simétrica, Trabaja, Estudia, Juegos en línea y Calidad 4K ",
                    Barcode = "PLANGAMER",
                    ListPrice = 55,
                    Price = 50,
                    Price50 = 40,
                    Price100 = 35,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 4,
                    Title = "Plan basico",
                    Seller = "Abby Muscles",
                    Description = "60 megas ilimitados,Velocidad simétrica, Trabaja y Estudia",
                    Barcode = "PLANBASICO",
                    ListPrice = 70,
                    Price = 65,
                    Price50 = 60,
                    Price100 = 55,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 5,
                    Title = "Fibra optica 50 metros",
                    Seller = "Vianet",
                    Description = "Guía de onda en forma de hilo de material altamente transparente diseñado para transmitir información a grandes distancias utilizando señales ópticas.\r\n\r\nfabricado a partir de sílice de muy alta pureza; con sólo 2 kg. de este material pueden fabricarse más de 40 kms. ",
                    Barcode = "SOTJ1111111101",
                    ListPrice = 30,
                    Price = 27,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 3,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 6,
                    Title = "Fibra optica 100 metros",
                    Seller = "Vianet",
                    Description = "Guía de onda en forma de hilo de material altamente transparente diseñado para transmitir información a grandes distancias utilizando señales ópticas.\r\n\r\nfabricado a partir de sílice de muy alta pureza; con sólo 2 kg. de este material pueden fabricarse más de 40 kms. ",
                    Barcode = "FOT000000001",
                    ListPrice = 25,
                    Price = 23,
                    Price50 = 22,
                    Price100 = 20,
                    CategoryId = 3,
                    ImageUrl = ""
                }

                );



            modelBuilder.Entity<Company>().HasData(
                new Company 
                { 
                            Id = 1, 
                    Name = "GenApp", 
                    StreetAddress= " Edificio Lugano, Luis Cordero E12-114", 
                    City = "Quito", 
                    PostalCode = "170109", 
                    State="Pichincha", 
                    PhoneNumber= "2-324-0361" 
                },
                new Company
                {
                     Id = 2,
                     Name = "Tecnologia EMUNAY",
                     StreetAddress = " C. 6",
                     City = "Quito",
                     PostalCode = "170310",
                     State = "Pichincha",
                     PhoneNumber = "+593 99 595 7889"
                },
                new Company
                {
                    Id = 3,
                    Name = "Chtt Tecnología 2.0",
                    StreetAddress = "Granda Centeno Oe4-550 y Sancho de la Carrera",
                    City = "Quito",
                    PostalCode = "170521",
                    State = "Pichincha",
                    PhoneNumber = "2-227-9577"
                }
                );
        }

    }
}
