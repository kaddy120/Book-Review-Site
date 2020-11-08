using Books.BookServices.QueryObjects;
using Books.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .FilterBookList(options.FilterBy, options.FilterValue);
            //I still need to add sorting
            options.SetupRestOfDto(books);
            
            return books
                .PageItems<BookListDTO>( options.PageNum, options.PageSize); 
        }
    }
}
