using System;
using QuotationSystem.Application.Repositories;
using QuotationSystem.Domain.Common;

namespace QuotationSystem.Application.UnitOfWorks
{
    public interface  IUnitOfWork : IAsyncDisposable
    {

        IReadRepository<T> GetReadRepository<T>() where  T:  class, IEntityBase, new();

        IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();

        Task<int> SaveAsync();

        int Save();
    }
}

