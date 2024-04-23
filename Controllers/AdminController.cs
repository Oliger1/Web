using Microsoft.AspNetCore.Mvc;
using WebOliger.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;

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

        [Authorize(Policy = "AdminRole")]
        public IActionResult ManageResumes()
        {
            List<ResumeModel> resumes = _context.Resumes.ToList();
            return View(resumes);
        }

        [HttpGet]
        [Authorize(Policy = "AdminRole")]
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
        [Authorize(Policy = "AdminRole")]
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
        [Authorize(Policy = "AdminRole")]
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

        // Faqja e hyrjes së përdoruesit për autentifikim
        public IActionResult Login()
        {
            return View();
        }

        // Veprimi për autentifikim
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Këtu mund të implementoni logjikën për autentifikimin
            // Për shembull, mund të kontrolloni nëse username dhe password janë korrekte dhe të ktheni një rezultat bazuar në këtë
            // Nëse autentifikimi është i suksesshëm, mund të përdoroni një skemë të caktuar për autentifikimin për të autorizuar përdoruesin për AdminRole
            // Për shembull, mund të përdorni: HttpContext.SignInAsync()
            return RedirectToAction(nameof(Index));
        }

        // Veprimi për çlirimin e sesionit (logout)
        public IActionResult Logout()
        {
            // Këtu mund të implementoni logjikën për çlirimin e sesionit
            // Për shembull, mund të përdorni: HttpContext.SignOutAsync()
            return RedirectToAction(nameof(Index));
        }
    }
}
