using FalzoniNetApi.Domain.Entities.Register;

namespace FalzoniNetApi.Data.Seed.Register
{
    public class CustomerDataSeed
    {
        public static List<Customer> GetData()
        {
            return new List<Customer>
            {
                new Customer(Guid.Parse("ccad702d-f0dc-46e7-9327-b35a9097fd75"), "Marcus Aurélios", "654.456.778-99", new DateTime(2025, 3, 20, 16, 2, 41)),
                new Customer(Guid.Parse("aa07c32c-e651-486f-b61b-00075c294eb4"), "Palacius Maritimus", "541.778.441-10", new DateTime(2024, 10, 12, 10, 55, 22)),
                new Customer(Guid.Parse("49b403c3-d0e5-47cc-a794-bf3ba6337e00"), "Monkey D. Luffy", "111.222.333-44", new DateTime(2023, 5, 30, 10, 55, 22)),
                new Customer(Guid.Parse("d19223f3-ad4b-4c03-8bf7-fe660013631d"), "Sasuke Uchira", "421.763.121-00", new DateTime(2025, 1, 2, 07, 4, 0)),
                new Customer(Guid.Parse("82715ff4-89e3-48ac-a10c-d09c2aae4a97"), "Boa Hancock", "241.696.711-14", new DateTime(2020, 10, 1, 12, 1, 8)),
                new Customer(Guid.Parse("8d949c46-a7b4-4ddc-9bae-f7331c441948"), "Kazuma Kuwabara", "331.112.446-31", new DateTime(2023, 5, 30, 10, 55, 22)),
                new Customer(Guid.Parse("ac883bff-8895-4e78-bf0d-dd068f028cf7"), "Kenshin Himura", "321.122.464-70", new DateTime(2025, 1, 10, 15, 21, 2)),
                new Customer(Guid.Parse("ad018eff-dc47-4295-9f87-be35e5f7580c"), "Peter Parker", "444.555.777-00", new DateTime(2021, 4, 2, 17, 4, 31)),
                new Customer(Guid.Parse("2c3c536c-7ad4-4677-a5dd-f8dbb875f435"), "Saori Kido", "787.656.121-11", new DateTime(2020, 6, 2, 11, 0, 14)),
            };
        }
    }
}
