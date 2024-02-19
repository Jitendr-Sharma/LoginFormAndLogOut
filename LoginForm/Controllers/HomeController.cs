using LoginForm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;

namespace LoginForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext context)
        {
            this.context = context;
        }
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ragister() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Ragister(User_tbl user)
        {
            if(ModelState.IsValid)
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
                TempData["Success"] = "Ragister Successfully";
                return RedirectToAction("Login");
                 
            }
            return View();
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(User_tbl user)
        {
            var use = context.Users.Where(x =>x.Email == user.Email && x.Password == user.Password).FirstOrDefault();

            if (use != null)
            {
                HttpContext.Session.SetString("UserSession",use.Email);
                return RedirectToAction("Dashboard");

            }
            else
            {
                ViewBag.Message = "Login Field";
            }
            return View();
        }

        public IActionResult Dashboard()
        {
           if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MyMessage = HttpContext.Session.GetString("UserSession").ToString();
            }
           else
            {
                return RedirectToAction("Login");
            }
           return View("Dashboard");
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Login");
            }
            return View();
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
    }
}
