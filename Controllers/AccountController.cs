using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Controllers
{
    public class AccountController: Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        //[HttpPost]
        //public async Task<IActionResult> Login()
        //{

        //}

        //public async Task<IActionResult> AccessDenied()
        //{

        //}
    }
}
