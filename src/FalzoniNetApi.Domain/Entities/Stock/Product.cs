using FalzoniNetApi.Domain.Entities.Base;

namespace FalzoniNetApi.Domain.Entities.Stock
{
    public class Product : BaseEntity
    {
        public string? Name { get; private set; }
        public decimal Price { get; private set; }
        public decimal Discount { get; private set; }

        public Product() 
        {
        }

        public Product(Guid id, string name, decimal price, decimal discount, DateTime created) 
        {
            Id = id;
            Name = name;
            Price = price;
            Discount = discount;
            Created = created;
        }

        public void Update(string name, decimal price, decimal discount, DateTime? modified)
        {
            Name = name;
            Price = price;
            Discount = discount;
            Modified = modified;
        }
    }
}
