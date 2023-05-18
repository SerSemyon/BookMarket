using BookMarket.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbbookMarketContext dbContext;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            dbContext = new DbbookMarketContext();
        }

        public IActionResult Index(string? name)
        {
            if (name == null)
            {
                List<Book> books = dbContext.Books.ToList();
                return View("Index", books);
            }
            else
            {
                List<Book> books = dbContext.Books.Where(b => b.BookName.ToLower().Contains(name.ToLower())).ToList();
                return View("Index", books);
            }
        }

        [Route("\"{name}\"")]
        public IActionResult Search(string? name)
        {
            if (name == null)
            {
                List<Book> books = dbContext.Books.ToList();
                return View("Index", books);
            }
            else
            {
                List<Book> books = dbContext.Books.Where(b => b.BookName.ToLower().Contains(name.ToLower())).ToList();
                return View("Index",books);
            }
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