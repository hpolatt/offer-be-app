using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using QuotationSystem.Domain.Common;

namespace QuotationSystem.Application.Repositories {

	public interface IReadRepository<T> where T : class, IEntityBase, new() {

		Task<IList<T>> GetAllSync (Expression<Func<T, bool>>? predicate = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>>? include=null,
			Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
			bool enableTracking = false
	    );

		Task<IList<T>> GetAllBySyncPaging (Expression<Func<T, bool>>? predicate = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
			Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
			bool enableTracking = false,
			int currentPage =1, int pageSize=3
		);

		Task<T> GetASync (Expression<Func<T, bool>> predicate,
			Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
			bool enableTracking = false
		);

		IQueryable<T> Find (Expression<Func<T, bool>> predicate, bool enableTracking = false);

		Task<int> CountAsync (Expression<Func<T, bool>>? predicate);
		}
	}

