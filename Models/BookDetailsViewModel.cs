using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models
{
    public class BookDetailsViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<ReviewViewModel> Reviews { get; set; }
    }
}
