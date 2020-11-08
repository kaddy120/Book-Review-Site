using System.Linq;

namespace Books.BookServices.QueryObjects
{
    public static class GenericPagination
    {
        public static IQueryable<T> PageItems<T>(
            this IQueryable<T> query,
            int pageNum, int itemsPerPage)
        {
            query.Skip((pageNum - 1) * itemsPerPage);
            return query.Take(itemsPerPage);
        }
    }
}
