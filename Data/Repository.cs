using Books.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Books.Data
{
    public class Repository : IRepository
    {
        private readonly AppDbContext Context;
        
        public Repository(AppDbContext context)
        {
            Context = context;
        }

        public Task AddComment()
        {
            throw new NotImplementedException();
        }

        public Task DeleteReview(int ReviewId)
        {
            throw new NotImplementedException();
        }

        public Task EditReview(Review review)
        {
            throw new NotImplementedException();
        }

        public async Task<Book> GetBook(string Isbn)
        {
            return await Context.Books.FindAsync(Isbn);
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await Context.Books.ToListAsync<Book>();
        }

        public Task<IEnumerable<Review>> GetReviews(string Isbn)
        {
            throw new NotImplementedException();
        }
    }
}
