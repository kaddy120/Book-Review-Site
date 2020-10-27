using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.Data;
using Books.Database;
using Books.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Books.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository Repo;
        public HomeController(IRepository repository)
        {
            Repo = repository;
        }

        public async Task<IActionResult> Index()
        {
            var Books = await Repo.GetBooks();
            return View(Books);
        }

        public async Task<IActionResult> BookDetails(string Isbn)
        {
            var model = new BookDetailsViewModel
            {
                Book = Repo.GetBook(Isbn).GetAwaiter().GetResult(),
                Reviews = Repo.GetReviewDTO(Isbn).GetAwaiter().GetResult()
            };
            //var Book = await Repo.GetBook(Isbn);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Review(string Isbn)
        {
            var reviewDTO = new AddReviewViewModel { Isbn = Isbn };
            return View(reviewDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Review(AddReviewViewModel review)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("BookDetails", review.Isbn);
            }
            else
                return View("Review", review);
        }
    }
}