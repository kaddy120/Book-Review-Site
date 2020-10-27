using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models
{
    public class AddReviewViewModel
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        [Required]
        public string Isbn { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
