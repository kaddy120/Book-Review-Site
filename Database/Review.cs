﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Database
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public string Isbn { get; set; }
        public int UserId { get; set; }
    }
}
