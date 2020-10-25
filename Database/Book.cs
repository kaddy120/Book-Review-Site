using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Database
{
    public class Book
    {
        //isbn,title,author,year
        [Key]
        public string Isbn { get; set; }
        public string Title { get; set; } = "";
        public string Authour { get; set; } = "";
        public string Year { get; set; } = "";
        public string? ThumbnailUrl { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        //public string[]? Category { get; set; } = { "" };

    }
}
