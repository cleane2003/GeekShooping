using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GeekShopping.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "product",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_name", "description", "image_url", "name", "price" },
                values: new object[,]
                {
                    { 1L, "Vestuário", "Camiseta 100% algodão com estampa de código de programação", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/2_no_internet.jpg?raw=true", "Camiseta Geek Code", 69.90m },
                    { 2L, "Acessórios", "Caneca de porcelana com capacidade de 350ml tema Star Wars", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/3_vader.jpg?raw=true", "Caneca Star Wars Darth Vader", 39.90m },
                    { 3L, "Colecionáveis", "Action figure colecionável do personagem Grogu (Baby Yoda) 15cm", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/5_100_doctor.jpg?raw=true", "Action Figure Baby Yoda", 189.90m },
                    { 4L, "Periféricos", "Mouse gamer com iluminação RGB, 7 botões programáveis e 16000 DPI", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/6_spaceship.jpg?raw=true", "Mouse Gamer RGB", 149.90m },
                    { 5L, "Periféricos", "Teclado mecânico com switches blue, iluminação RGB personalizável", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/7_robot.jpg?raw=true", "Teclado Mecânico RGB", 299.90m },
                    { 6L, "Periféricos", "Headset gamer com som surround 7.1, microfone removível e LED RGB", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/8_chess.jpg?raw=true", "Headset Gamer 7.1", 249.90m },
                    { 7L, "Colecionáveis", "Boneco colecionável Funko Pop do Batman da DC Comics", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/9_comic_book.jpg?raw=true", "Funko Pop Batman", 89.90m },
                    { 8L, "Acessórios", "Mochila para laptop até 17 polegadas com compartimentos para periféricos", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/10_shirt.jpg?raw=true", "Mochila Laptop Gamer", 179.90m },
                    { 9L, "Livros", "Livro Clean Code de Robert C. Martin - Guia para código limpo", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/11_book.jpg?raw=true", "Livro Clean Code", 79.90m },
                    { 10L, "Periféricos", "Webcam com resolução Full HD 1080p, microfone embutido e foco automático", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/12_space_suit.jpg?raw=true", "Webcam Full HD 1080p", 199.90m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 10L);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "product",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);
        }
    }
}
