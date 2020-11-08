using Books.Database;
using Books.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Linq;

namespace Books.BookServices.Concrete
{
    public enum SearchBy 
    {
        Title = 0,
        Author,
        ISBN
    }

    public class SearchForBook
    {
        private readonly AppDbContext context;

        public SearchForBook(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Book> Search(SearchBy searchBy, string searchValue)
        {
            switch (searchBy)
            {
                case SearchBy.Title:
                   return context.Books.Include(b => b.Reviews)
                        .Where(b => EF.Functions.Like(b.Title, $"%{searchValue}%"));
                case SearchBy.Author:
                    return context.Books.Include(b => b.Reviews)
                        .Where(b => EF.Functions.Like(b.Authour, $"%{searchValue}%"));
                case SearchBy.ISBN:
                    return context.Books.Include(b => b.Reviews)
                        .Where(b => EF.Functions.Like(b.Isbn, $"%{searchValue}%"));
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }
}
