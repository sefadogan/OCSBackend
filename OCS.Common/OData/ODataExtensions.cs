using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;

namespace OCS.Common.OData;

public static class ODataExtensions
{
    /// <summary>
    /// OData arama/filtreleme kriterlerini expression olarak döndürür.
    /// </summary>
    public static Expression<Func<T, bool>> GetFilter<T>(this ODataQueryOptions<T> options)
    {
        if (options.Filter == null)
            return null;

        IQueryable query = Enumerable.Empty<T>().AsQueryable();
        query = options.Filter.ApplyTo(query, new ODataQuerySettings());

        var call = query.Expression as MethodCallExpression;
        if (call != null && call.Method.Name == nameof(Queryable.Where) && call.Method.DeclaringType == typeof(Queryable))
        {
            var predicate = ((UnaryExpression)call.Arguments[1]).Operand;
            return (Expression<Func<T, bool>>)predicate;
        }

        return null;
    }

    /// <summary>
    /// OData propetry seçim tercihlerini verilen veri setine uygular.
    /// </summary>
    public static async Task<IEnumerable> ApplySelection(this ODataQueryOptions options, IQueryable set)
    {
        if (options == null || options.SelectExpand == null)
            return await set.Cast<dynamic>().ToArrayAsync();

        var result = options.SelectExpand
                        .ApplyTo(set, new ODataQuerySettings())
                        .Cast<dynamic>();

        return await result.ToArrayAsync();
    }

    /// <summary>
    /// OData sıralama tercihlerini verilen veri setine uygular.
    /// </summary>
    public static IQueryable<T> Sort<T>(this ODataQueryOptions options, IQueryable<T> set)
    {
        if (options == null || options.OrderBy == null)
            return set.OrderBy(x => EF.Property<object>(x, "Id"));

        var result = options.OrderBy.ApplyTo(set, new ODataQuerySettings());
        return result;
    }
}
