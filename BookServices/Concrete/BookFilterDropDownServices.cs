using Books.BookServices.QueryObjects;
using Books.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.BookServices.Concrete
{
    public class BookFilterDropDownServices
    {
        private readonly AppDbContext context;

        public BookFilterDropDownServices(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DropDownFilterValues> GetDropDownFilterValues(FilterBy option)
        {
            switch (option)
            {
                case QueryObjects.FilterBy.NoFilter:
                    return new List<DropDownFilterValues>();
                case QueryObjects.FilterBy.Year:
                    return context.Books
                        .Select(b => new DropDownFilterValues
                        {
                            Value = b.Year,
                            Text = b.Year
                        }).Distinct().ToList();

                case QueryObjects.FilterBy.StarRating:
                    return FormVotesDropDown();
                default:
                    throw new ArgumentOutOfRangeException(nameof(option), option, null);
            }
        }

        private static IEnumerable<DropDownFilterValues> FormVotesDropDown()
        {
            return new[]
            {
                new DropDownFilterValues {Value = "4", Text = "4 stars and up"},
                new DropDownFilterValues {Value = "3", Text = "3 stars and up"},
                new DropDownFilterValues {Value = "2", Text = "2 stars and up"},
                new DropDownFilterValues {Value = "1", Text = "1 star and up"},
            };
        }
    }
}
