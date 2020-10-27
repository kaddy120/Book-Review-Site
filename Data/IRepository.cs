﻿using Books.Database;
using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Data
{
    public interface IRepository
    {
        public Task<IEnumerable<Book>> GetBooks();
        public Task<Book> GetBook(string Isbn);
        //any of books property will do i think
        public Task<IEnumerable<ReviewViewModel>> GetReviewDTO(string Isbn);
        public Task AddReview(Review rivew);
        public Task<IEnumerable<Review>> GetReviews(string Isbn);
        public Task DeleteReview(int ReviewId);
        public Task EditReview(Review review);
    }
}
