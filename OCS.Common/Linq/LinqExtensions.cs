using Microsoft.EntityFrameworkCore;
using OCS.Common.Pagination;
using OCS.Common.Result.Concrete;
using System.Linq.Expressions;

namespace OCS.Common.Linq
{
    public static class LinqExtensions
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> query, Expression<Func<T, bool>> expression = null)
        {
            if (expression != null)
                query = query.Where(expression).AsQueryable();

            return query;
        }

        public static PagingResult<T> CreateListForPaging<T>(this IQueryable<T> query, PaginationFilter paginationFilter)
        {
            int totalCount = query.Count();

            query = query.Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize).Take(paginationFilter.PageSize);

            return new PagingResult<T>(query, totalCount);
        }

        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
        public static IEnumerable<T> Distinct<T, TKey>(this IEnumerable<T> source, Func<T, TKey> selector)
        {
            return source.GroupBy(selector).Select(x => x.First());
        }
    }
}