using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Database
{
    public class User : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
        //public List<Review> Review { get; set; }
    }
}
