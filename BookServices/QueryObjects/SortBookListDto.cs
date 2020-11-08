using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.BookServices.QueryObjects
{
    public enum SortBy
    {
        SimpleSort = 0,
        YearAscending,
        YearDescending,
        StarRatingAscending,
        StarDescending,
        NumberOfReviewAscending,
        NumberOfReviewDescinding,
    }

    public class SortBookListDto
    {
      
    }
}
