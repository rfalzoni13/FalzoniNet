namespace FalzoniNetApi.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public DateTime Created { get; protected set; }
        public DateTime? Modified { get; protected set; }
    }
}
