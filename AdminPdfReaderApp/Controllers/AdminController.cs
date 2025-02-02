using AdminPdfReaderApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AdminPdfReaderApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Admin Login GET
        public IActionResult Login()
        {
            return View();
        }

        // Admin Login POST
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.AdminUsers
                             .Where(u => u.Username == username)
                             .FirstOrDefault();

            if (user != null && user.PasswordHash == password)  // In production, use password hashing & comparison
            {
                // Redirect to PDF Reader
                return RedirectToAction("PdfReader");
            }

            ViewBag.ErrorMessage = "Invalid username or password";
            return View();
        }

        // PDF Reader Page
        public IActionResult PdfReader()
        {
            string pdfFilePath = "/files/abc.pdf";  // The relative path from the wwwroot folder

            if (string.IsNullOrEmpty(pdfFilePath))
            {
                ViewBag.ErrorMessage = "PDF file not found.";
                return View();
            }

            return View("PdfReader", pdfFilePath);
        }


    }
}
