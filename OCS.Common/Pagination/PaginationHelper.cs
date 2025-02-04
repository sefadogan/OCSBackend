using OCS.Common.Result.Concrete;

namespace OCS.Common.Pagination;

public static class PaginationHelper
{
    public static PaginatedResult<T> CreatePaginatedResponse<T>(T data, PaginationFilter paginationFilter, int totalRecords, IPaginationUriService uriService)
    {
        var response = new PaginatedResult<T>(data, paginationFilter.PageNumber, paginationFilter.PageSize);

        if (totalRecords < 1 || data == null)
            return response;

        var totalPages = totalRecords / (double)paginationFilter.PageSize;

        int roundedTotalPages;
        if (paginationFilter.PageNumber <= 0 || paginationFilter.PageSize <= 0)
        {
            roundedTotalPages = 1;
            paginationFilter.PageNumber = 1;
            paginationFilter.PageSize = 1;
        }
        else
            roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

        response.NextPage = paginationFilter.PageNumber >= 1 && paginationFilter.PageNumber < roundedTotalPages
            ? uriService.GeneratePageRequestUri(new PaginationFilter(paginationFilter.PageNumber + 1, paginationFilter.PageSize))
            : null;

        response.PreviousPage = paginationFilter.PageNumber - 1 >= 1 && paginationFilter.PageNumber <= roundedTotalPages
                ? uriService.GeneratePageRequestUri(new PaginationFilter(paginationFilter.PageNumber - 1, paginationFilter.PageSize))
                : null;

        response.FirstPage = uriService.GeneratePageRequestUri(new PaginationFilter(1, paginationFilter.PageSize));
        response.LastPage = uriService.GeneratePageRequestUri(new PaginationFilter(roundedTotalPages, paginationFilter.PageSize));
        response.TotalPages = roundedTotalPages;
        response.TotalRecords = totalRecords;
        return response;
    }
}
