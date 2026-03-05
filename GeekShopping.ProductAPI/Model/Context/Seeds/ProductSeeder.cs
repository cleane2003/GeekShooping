using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Model.Context.Seeds
{
    public static class ProductSeeder
    {
        public static void SeedProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Camiseta Geek Code",
                    Price = 69.90m,
                    Description = "Camiseta 100% algodão com estampa de código de programação",
                    CategoryName = "Vestuário",
                    ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/2_no_internet.jpg?raw=true"
                },
                new Product
                {
                    Id = 2,
                    Name = "Caneca Star Wars Darth Vader",
                    Price = 39.90m,
                    Description = "Caneca de porcelana com capacidade de 350ml tema Star Wars",
                    CategoryName = "Acessórios",
                    ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/3_vader.jpg?raw=true"
                },
                new Product
                {
                    Id = 3,
                    Name = "Action Figure Baby Yoda",
                    Price = 189.90m,
                    Description = "Action figure colecionável do personagem Grogu (Baby Yoda) 15cm",
                    CategoryName = "Colecionáveis",
                    ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/5_100_doctor.jpg?raw=true"
                },
                new Product
                {
                    Id = 4,
                    Name = "Mouse Gamer RGB",
                    Price = 149.90m,
                    Description = "Mouse gamer com iluminação RGB, 7 botões programáveis e 16000 DPI",
                    CategoryName = "Periféricos",
                    ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/6_spaceship.jpg?raw=true"
                },
                new Product
                {
                    Id = 5,
                    Name = "Teclado Mecânico RGB",
                    Price = 299.90m,
                    Description = "Teclado mecânico com switches blue, iluminação RGB personalizável",
                    CategoryName = "Periféricos",
                    ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/7_robot.jpg?raw=true"
                },
                new Product
                {
                    Id = 6,
                    Name = "Headset Gamer 7.1",
                    Price = 249.90m,
                    Description = "Headset gamer com som surround 7.1, microfone removível e LED RGB",
                    CategoryName = "Periféricos",
                    ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/8_chess.jpg?raw=true"
                },
                new Product
                {
                    Id = 7,
                    Name = "Funko Pop Batman",
                    Price = 89.90m,
                    Description = "Boneco colecionável Funko Pop do Batman da DC Comics",
                    CategoryName = "Colecionáveis",
                    ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/9_comic_book.jpg?raw=true"
                },
                new Product
                {
                    Id = 8,
                    Name = "Mochila Laptop Gamer",
                    Price = 179.90m,
                    Description = "Mochila para laptop até 17 polegadas com compartimentos para periféricos",
                    CategoryName = "Acessórios",
                    ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/10_shirt.jpg?raw=true"
                },
                new Product
                {
                    Id = 9,
                    Name = "Livro Clean Code",
                    Price = 79.90m,
                    Description = "Livro Clean Code de Robert C. Martin - Guia para código limpo",
                    CategoryName = "Livros",
                    ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/11_book.jpg?raw=true"
                },
                new Product
                {
                    Id = 10,
                    Name = "Webcam Full HD 1080p",
                    Price = 199.90m,
                    Description = "Webcam com resolução Full HD 1080p, microfone embutido e foco automático",
                    CategoryName = "Periféricos",
                    ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/12_space_suit.jpg?raw=true"
                }
            );
        }
    }
}
