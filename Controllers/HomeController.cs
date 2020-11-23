using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Books.Data;
using Books.Database;
using Books.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Books.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository Repo;
        private readonly UserManager<User> _userManager;

        public HomeController(
            IRepository repository,
            UserManager<User> userManager)
        {
            Repo = repository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var Books = await Repo.GetBooks();
            return View(Books);
        }

        public async Task<IActionResult> BookDetails(string Isbn)
        {
            //this is so wrong, i should have a 
            //function that maps BookDetaails using select and include reviews
            var model = new BookDetailsViewModel
            {
                Book = Repo.GetBook(Isbn).GetAwaiter().GetResult(),
                Reviews = Repo.GetReviewDTO(Isbn).GetAwaiter().GetResult()
            };
            //var Book = await Repo.GetBook(Isbn);
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Review(string Isbn)
        {
            var reviewDTO = new AddReviewViewModel { Isbn = Isbn };
            return View(reviewDTO);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Review(AddReviewViewModel review)
        {
            
            if (ModelState.IsValid)
            {
                var User = await _userManager.GetUserAsync(HttpContext.User);
                var NewReview = new Review
                {
                    Comment = review.Comment,
                    Rating = review.Rating,
                    Id = User.Id,
                    Isbn = review.Isbn
                    //,Book = Repo.GetBook(review.Isbn)
                };
                await Repo.AddReview(NewReview);
                var Url = "/Home/BookDetails?Isbn=" + review.Isbn;
                return Redirect(Url);
            }
            else
                return View("Review", review);
        }
    }
}