using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebOliger.Models;

namespace WebOliger.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitReview(int Id, string UserShowed, int Rating, string Comment)
        {
            var newReview = new ReviewModel()
            {
                Id = Id,
                UserShowed = UserShowed,
                Rating = Rating,
                Comment = Comment,
                Date = DateTimeOffset.UtcNow 
            };

            // Shtimi i review-n në bazën e të dhënave
            _context.Reviews.Add(newReview);
            await _context.SaveChangesAsync();

            // Kthej view-in ReviewSubmited pas shtimit të suksesshëm në bazën e të dhënave
            return RedirectToAction("Index", "Home");


        }

    }
}
