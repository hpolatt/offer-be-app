using System;
using Microsoft.EntityFrameworkCore;
using QuotationSystem.Application.Repositories;
using QuotationSystem.Domain.Common;

namespace QuotationSystem.Persistence.Repositories {
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext dBContext;
        

        public WriteRepository(DbContext dBContext)
        {
            this.dBContext = dBContext;
        }

        private DbSet<T> Table { get => this.dBContext.Set<T>(); }

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entites)
        {
           await Table.AddRangeAsync(entites);
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }
    }
}

