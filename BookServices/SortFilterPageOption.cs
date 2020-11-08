using Books.BookServices.QueryObjects;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.BookServices
{
    public struct DropDownFilterValues
    {
        string Value { get; set; }
        string Text { get; set; }
        public override string ToString()
        {
            return $"{nameof(Value)}: {Value}, {nameof(Text)}: {Text}";
        }
    }
    public class SortFilterPageOption
    {
        public const int DefaultPageSize = 10;   //default page size is 10

        private int _pageSize = DefaultPageSize;
        public SortBy SortBy { get; set; }
        public FilterBy FilterBy { get; set; }
        public string FilterValue { get; set; }
        public IEnumerable<DropDownFilterValues> DropDownFilterValues { get; private set; }
        public int PageNumber { get; set; }

        public void Options()
        {

        }
        

    }
}
