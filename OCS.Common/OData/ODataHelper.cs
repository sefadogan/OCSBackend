using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Query.Validator;
using OCS.Common.Linq;
using OCS.Common.Pagination;
using OCS.Common.Result.Abstract;
using System.Collections;

namespace OCS.Common.OData;

public static class ODataHelper
{
    /// <summary>
    /// OData özelliklerinden yalnızca arama, filtreleme ve seçim yapılabilmesini sağlayacak konfigürasyonu döndürür.
    /// </summary>
    public static ODataValidationSettings GetDefaultSettings() => new()
    {
        AllowedFunctions = AllowedFunctions.AllFunctions,
        AllowedQueryOptions = AllowedQueryOptions.Select | AllowedQueryOptions.Filter | AllowedQueryOptions.Expand | AllowedQueryOptions.Search | AllowedQueryOptions.OrderBy,
        AllowedLogicalOperators = AllowedLogicalOperators.All,
        MaxExpansionDepth = 1,
        MaxSkip = 0,
    };

    /// <summary>
    /// Verilen sayfalanmış veri setine OData filtrelerininin uygulanmasını sağlar.
    /// </summary>
    public static async Task<IDataResult<IEnumerable>> ApplyODataToPaginatedResult<TDto>
    (
        PaginationFilter paginationFilter,
        ODataQueryOptions<TDto> queryOptions,
        IQueryable<TDto> query,
        IPaginationUriService uriService,
        ODataValidationSettings validationSettings
    )
    {
        if (queryOptions != null)
        {
            queryOptions.Validate(validationSettings);

            var condition = queryOptions.GetFilter();
            query = query.Filter(condition);

            query = queryOptions.Sort(query);
        }

        var pagingResult = query.CreateListForPaging(paginationFilter);

        var result = queryOptions != null
            ? await queryOptions.ApplySelection(pagingResult.Data)
            : pagingResult.Data;

        return PaginationHelper.CreatePaginatedResponse(result, paginationFilter, pagingResult.TotalItemCount, uriService);
    }
}
