using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models
{
    public class Review
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string Isbn { get; set; }
        public string Id { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
    }
}
