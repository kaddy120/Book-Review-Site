using Books.Models;
using System.Linq;

namespace Books.BookServices.QueryObjects
{
    public static class BookListDtoSelect
    {
        public static IQueryable<BookListDTO> BooListDtoMap(this IQueryable<Book> books)
        {
            return books.Select(b => new BookListDTO
            {
                Isbn = b.Isbn,
                Title = b.Title,
                Authour = b.Authour,
                YearPublished = int.Parse(b.Year),
                ThumbnailUrl = b.ThumbnailUrl,
                Star = b.Reviews == null ? 0 : b.Reviews
                .Select(r => r.Rating)
                .ToList().Average(),
                NumberOfReviews = b.Reviews==null? 0: b.Reviews.Count
            }) ;
        }
    }
}
