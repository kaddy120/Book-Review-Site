using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.BookServices
{
    public class BookListDTO
    {
        public string Isbn { get; set; }
        public string Title { get; set; } 
        public string Authour { get; set; } 
        public string ThumbnailUrl { get; set; }
        public double Star { get; set; }
        public int YearPublished { get; set; }
        public int NumberOfReviews { get; set; }
    }
}
