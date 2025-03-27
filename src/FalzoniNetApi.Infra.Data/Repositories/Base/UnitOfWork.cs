using FalzoniNetApi.Domain.Interfaces.Repositories.Base;
using FalzoniNetApi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace FalzoniNetApi.Infra.Data.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FalzoniNetApiContext _context;

        public UnitOfWork(FalzoniNetApiContext context)
        {
            _context = context;
        }

        public IDbContextTransaction GetTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}
