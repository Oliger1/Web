using Microsoft.AspNetCore.Mvc;
using WebOliger.Models;

namespace WebOliger.Controllers
{
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminRole
        public IActionResult Role()
        {
            var roles = _context.AdminRoles.ToList();
            return View(roles);
        }

        // GET: AdminRole/Create
        public IActionResult CreateRole()
        {
            return View();
        }

        // POST: AdminRole/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateRole(AdminRole adminRole)
        {
            if (ModelState.IsValid)
            {
                _context.AdminRoles.Add(adminRole);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(adminRole);
        }

        // GET: AdminRole/Edit/5
        public IActionResult EditRole(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminRole = _context.AdminRoles.Find(id);
            if (adminRole == null)
            {
                return NotFound();
            }
            return View(adminRole);
        }

        // POST: AdminRole/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRole(int id, AdminRole adminRole)
        {
            if (id != adminRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(adminRole);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(adminRole);
        }

        // GET: AdminRole/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminRole = _context.AdminRoles.Find(id);
            if (adminRole == null)
            {
                return NotFound();
            }

            return View(adminRole);
        }

        // POST: AdminRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var adminRole = _context.AdminRoles.Find(id);
            _context.AdminRoles.Remove(adminRole);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
