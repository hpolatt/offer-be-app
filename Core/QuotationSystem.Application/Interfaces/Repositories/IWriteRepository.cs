using System;
using QuotationSystem.Domain.Common;

namespace QuotationSystem.Application.Repositories
{
	public interface IWriteRepository<T> where T : class, IEntityBase, new()
	{
		Task AddAsync(T entity);

		Task AddRangeAsync(IList<T> entites);

		Task<T>  UpdateAsync(T entity);

		Task DeleteAsync(T entity);

	}
}

