namespace OCS.Common.Pagination;

public class PaginationFilter
{
    public PaginationFilter() : this(1, 20)
    { }

    public PaginationFilter(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber < 1 ? 1 : pageNumber;
        PageSize = pageSize > 100000 ? 100000 : pageSize;
    }

    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
