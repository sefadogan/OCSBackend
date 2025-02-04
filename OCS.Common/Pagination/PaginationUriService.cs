using Microsoft.AspNetCore.WebUtilities;

namespace OCS.Common.Pagination
{
    public class PaginationUriService : IPaginationUriService
    {
        private readonly string _uri;

        public PaginationUriService(string uri)
        {
            _uri = uri;
        }

        public string GeneratePageRequestUri(PaginationFilter paginationFilter)
        {
            Dictionary<string, string> parameters = new()
            {
                { "pageNumber", paginationFilter.PageNumber.ToString() },
                { "pageSize", paginationFilter.PageSize.ToString() },
            };

            return QueryHelpers.AddQueryString(_uri, parameters);
        }
    }
}
