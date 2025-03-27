using FalzoniNetApi.Domain.Entities.Base;

namespace FalzoniNetApi.Domain.Entities.Register
{
    public class Customer : BaseEntity
    {
        public string? Name { get; private set; }
        public string? Document { get; private set; }

        public Customer()
        {
        }

        public Customer(Guid id, string name, string document, DateTime created)
        {
            Id = id;
            Name = name;
            Document = document;
            Created = created;
        }

        public void Update(string name, string document, DateTime? modified)
        {
            Name = name;
            Document = document;
            Modified = modified;
        }
    }
}
