using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.BookServices.QueryObjects
{
    public enum FilterBy
    {
        NoFilter = 0,
        Year,
        StarRating,
        Genres,
    }

    public static class FilterBookListDto
    {
        public static IQueryable<BookListDTO> FilterBookList(
            this IQueryable<BookListDTO> books, FilterBy filterBy, string filterValue)
        {
            switch (filterBy)
            {
                case FilterBy.NoFilter:
                    return books;
                case FilterBy.Year:
                    return books.Where(b => b.YearPublished == int.Parse(filterValue));
                case FilterBy.StarRating:
                    return books.Where(b => b.Star >= int.Parse(filterValue));
                case FilterBy.Genres:
                    return books.Where(b => b.YearPublished == int.Parse(filterValue));
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
        
    }
}
