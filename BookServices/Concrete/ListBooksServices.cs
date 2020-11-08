using Books.BookServices.QueryObjects;
using Books.Database;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Books.BookServices.Concrete
{
    public class ListBooksServices
    {
        private readonly AppDbContext context;

        public ListBooksServices(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<BookListDTO> SortFilterPage(SortFilterPageOption options)
        {
            var books = context.Books.
                Include(b => b.Reviews)
                .BooListDtoMap()
                .FilterBookList(options.FilterBy, options.FilterValue)
                .SortBooks(options.OrderByOptions);
            
            options.SetupRestOfDto(books);
            
            return books
                .PageItems<BookListDTO>( options.PageNum, options.PageSize); 
        }
    }
}
