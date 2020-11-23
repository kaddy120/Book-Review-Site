using System;
using System.Linq;

namespace Books.BookServices.QueryObjects
{
    public enum SortBooksBy
    {

        SimpleSort = 0,
        Year,
        StarRating,
        //NumberOfReviewAscending,
        //NumberOfReviewDescinding,
    }

    public static class SortBookListDto
    {
        public static IQueryable<BookListDTO> SortBooks(
            this IQueryable<BookListDTO> books
            ,SortBooksBy sortOption)
        {
            switch (sortOption)
            {
                case SortBooksBy.SimpleSort:
                    return books;
                case SortBooksBy.Year:
                    return books.OrderByDescending(b => b.YearPublished);
                case SortBooksBy.StarRating:
                    return books.OrderByDescending(b => b.Star);
                default:
                    throw new ArgumentOutOfRangeException(nameof(sortOption),sortOption, null );
            }
        }    
    }
}
