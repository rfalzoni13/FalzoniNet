using Microsoft.EntityFrameworkCore.Storage;

namespace FalzoniNetApi.Domain.Interfaces.Repositories.Base
{
    public interface IUnitOfWork
    {
        IDbContextTransaction GetTransaction();
    }
}
