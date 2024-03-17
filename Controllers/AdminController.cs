using Microsoft.AspNetCore.Mvc;
using WebOliger.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebOliger.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ManageResumes()
        {
            List<ResumeModel> resumes = _context.Resumes.ToList();
            return View(resumes);
        }

        [HttpGet]
        public IActionResult EditResume(int id)
        {
            ResumeModel resume = _context.Resumes.Find(id);
            if (resume == null)
            {
                return NotFound();
            }
            return View(resume);
        }

        [HttpPost]
        public IActionResult EditResume(ResumeModel resume)
        {
            if (ModelState.IsValid)
            {
                _context.Update(resume);
                _context.SaveChanges();
                return RedirectToAction(nameof(ManageResumes));
            }
            return View(resume);
        }

        [HttpPost]
        public IActionResult DeleteResume(int id)
        {
            ResumeModel resume = _context.Resumes.Find(id);
            if (resume == null)
            {
                return NotFound();
            }
            _context.Resumes.Remove(resume);
            _context.SaveChanges();
            return RedirectToAction(nameof(ManageResumes));
        }
    }
}
