using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using QuotationSystem.Application.Repositories;
using QuotationSystem.Domain.Common;

namespace QuotationSystem.Persistence.Repositories
{

    public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext dbContext;

        public ReadRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> Table
        {
            get => dbContext.Set<T>();
        }

        public Task<int> CountAsync(Expression<Func<T, bool>>? predicate)
        {
            IQueryable<T> queryAble = Table;
            queryAble.AsNoTracking();
            if (predicate is not null) queryAble.Where(predicate);
            return queryAble.CountAsync();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
        {
            IQueryable<T> queryAble = Table;

            if (!enableTracking)
                queryAble = queryAble.AsNoTracking();

            return queryAble.Where(predicate);
        }


        public async Task<IList<T>> GetAllBySyncPaging(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
        {
            IQueryable<T> queryAble = Table;
            if (!enableTracking) queryAble = queryAble.AsNoTracking();
            if (include is not null) queryAble = include(queryAble);
            if (predicate is not null) queryAble = queryAble.Where(predicate);
            if (orderBy is not null)
                return await orderBy(queryAble).Skip((currentPage - 1) * pageSize).ToListAsync();

            return await queryAble.Skip((currentPage - 1) * pageSize).ToListAsync();
        }

        public async Task<IList<T>> GetAllSync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
        {
            IQueryable<T> queryAble = Table;
            if (!enableTracking) queryAble = queryAble.AsNoTracking();
            if (include is not null) queryAble = include(queryAble);
            if (predicate is not null) queryAble = queryAble.Where(predicate);
            if (orderBy is not null)
                return await orderBy(queryAble).ToListAsync();

            return await queryAble.ToListAsync();
        }

        public async Task<T> GetASync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
             bool enableTracking = false)
        {
            IQueryable<T> queryAble = Table;

            if (!enableTracking)
                queryAble = queryAble.AsNoTracking();

            if (include is not null)
                queryAble = include(queryAble);

            return await queryAble.FirstOrDefaultAsync(predicate);
        }

    }
}

