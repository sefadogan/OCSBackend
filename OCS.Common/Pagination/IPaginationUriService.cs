namespace OCS.Common.Pagination
{
    public interface IPaginationUriService
    {
        string GeneratePageRequestUri(PaginationFilter paginationFilter);
    }
}
