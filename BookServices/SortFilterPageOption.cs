using Books.BookServices.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.BookServices
{
    public class SortFilterPageOption
    {
        public SortBy SortBy { get; set; }
        public FilterBy FilterBy { get; set; }

    }
}
