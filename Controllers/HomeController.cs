using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using WebOliger.Models;

namespace WebOliger.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly List<ResumeModel> Resumes = new();
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new IndexModel
            {
                Name = "Oliger Shehi",
                Profession = "Software Developer",
                Description = "I'm Oliger Shehi, a passionate software developer with experience in web development.",
                Email = "oliger@example.com",
                Phone = "+1234567890",
                LinkedIn = "https://www.linkedin.com/in/oliger-shehi",
                Projects = new List<Project>
                {
                    new() { Title = "Portfolio Website", Description = "A personal portfolio website showcasing my skills and projects.", TechnologiesUsed = "HTML, CSS, ASP.NET Core", GitHubLink = "https://github.com/yourusername/portfolio-website" },
                    new() { Title = "E-commerce Website", Description = "Developed an e-commerce website using HTML, CSS, and JavaScript.", TechnologiesUsed = "HTML, CSS, JavaScript, ASP.NET Core", GitHubLink = "https://github.com/yourusername/ecommerce-website" }
                }
            };

            return View(model);
        }






        public IActionResult Resume(int page = 1)
        {
            int pageSize = 8;
            int totalResumes = _context.Resumes.Count();
            var resumes = _context.Resumes
                .OrderByDescending(r => r.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.TotalPages = (int)Math.Ceiling((double)totalResumes / pageSize);
            ViewBag.CurrentPage = page;

            return View(resumes);
        }


        [HttpPost]
        public IActionResult EditDeleteCV(int resumeId, string title, string description, string action,string category)
        {
            var resume = _context.Resumes.FirstOrDefault(r => r.Id == resumeId);
            if (resume != null)
            {
                if (action == "edit")
                {
                    resume.Title = title;
                    resume.Description = description;
                    _context.SaveChanges();
                }
                else if (action == "delete")
                {
                    resume.Title = title;
                    _context.Resumes.Remove(resume);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Resume");
        }




        private static ResumeModel LastAddedResume = null;
    

        [HttpPost]
        public IActionResult UploadDocument(IFormFile file, string description, string title, int Id, string category)
        {
            if (file != null && file.Length > 0)
            {
                var fileName = $"{DateTime.Now.Ticks}_{Path.GetFileName(file.FileName)}";
                var directoryPath = "C:\\Users\\user\\Desktop\\WebOliger\\uploads";
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
               
                var filePath = Path.Combine(directoryPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                
                var newResume = new ResumeModel
                {
                    Id = Id,
                    Title = title,
                    Category = category,
                    Description = description,
                    DownloadLink = filePath 
                };

               
                LastAddedResume = newResume;

                ViewBag.Message = "File-u u ngarkua me sukses.";

                _context.Resumes.Add(newResume);
                _context.SaveChanges();

               


                // Kthehuni në faqen Resume dhe paraqitni vetëm CV-në e fundit të ngarkuar
                return RedirectToAction("Resume");
            }

            return RedirectToAction("Index");
        }

        public IActionResult Download(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "application/octet-stream", Path.GetFileName(filePath));
            }
            return NotFound();
        }

        public IActionResult ResumeList()
        {
            var model = _context.Resumes.ToList(); 
            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }





        public IActionResult Admin()
        {
            var model = Resumes;
            return View(model);
        }

    }
}
