using FalzoniNetApi.Domain.Entities.Stock;

namespace FalzoniNetApi.Data.Seed.Stock
{
    public class ProductDataSeed
    {
        public static List<Product> GetData()
        {
            return new List<Product>
            {
                new Product(Guid.Parse("ebce33b1-8b7a-4d1b-bccf-e61c5d3a9086"), "Vídeo Game Nintendo Switch", 2999.99M, 0, new DateTime(2024, 10, 1, 14, 29, 14)),
                new Product(Guid.Parse("b2ec1e29-7c54-49d8-ad70-45e04cb3c90f"), "Placa mãe NVIDIA", 1999.99M, 10.0M, new DateTime(2023, 2, 15, 10, 5, 59)),
                new Product(Guid.Parse("285403e0-1ee6-4ef2-b58d-9fffe5be9aa3"), "Kit Teclado e Mouse Gamer", 299.99M, 15.0M, new DateTime(2025, 3, 13, 22, 11, 35)),
                new Product(Guid.Parse("4f4ba054-7867-4c1e-99dc-ea9dc01b3d68"), "Cadeira Gamer", 1599.99M, 0, new DateTime(2022, 6, 18, 12, 10, 48)),
                new Product(Guid.Parse("0d43a853-cf03-425a-822b-3a76abe640ab"), "Jogo PS5", 399.99M, 0, new DateTime(2024, 7, 2, 18, 2, 25)),
                new Product(Guid.Parse("ab9f476d-5311-4203-a134-33fea25ea055"), "Smartphone Samsung Galaxy", 1699.99M, 20.0M, new DateTime(2025, 2, 20, 11, 4, 13)),
                new Product(Guid.Parse("1899993e-6b5c-4272-b4d4-75a0ce3844a7"), "Tablet IPad", 5899.99M, 15.0M, new DateTime(2024, 5, 2, 13, 12, 18)),
                new Product(Guid.Parse("5fe6f7f2-d957-43fb-8222-2da3424103b5"), "Tapete de mouse", 9.99M, 0.0M, new DateTime(2024, 12, 21, 16, 35, 4)),
                new Product(Guid.Parse("0fda3264-bad3-460a-ace7-8a065405ce93"), "Suporte para notebook", 49.99M, 5.0M, new DateTime(2024, 9, 21, 9, 1, 59))
            };
        }
    }
}
