using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookMarket;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookMarket.Controllers
{
    public class BooksController : Controller
    {
        private readonly DbbookMarketContext _context;

        public BooksController()
        {
            _context = new DbbookMarketContext();
        }

        public async Task<IActionResult> Show(int id)
        {
            var book = await _context.Books
                .Include(b => b.LegalEntity)
                .Include(b => b.Phouse)
                .FirstOrDefaultAsync(m => m.BookId == id);

            ViewBag.feedbacks = _context.Feedbacks.Where(f => f.BookId == id)
                .Include(f => f.Account)
                .ToList();

            Response.Cookies.Append("LastBook", book.BookId.ToString());
            return View(book);
        }

        public async Task<IActionResult> AddFavouriteBook()
        {
            int favouriteId = 0;
            if (Request.Cookies.ContainsKey("LastBook"))
            {
                favouriteId = Convert.ToInt32(Request.Cookies["LastBook"].ToString());
            }
            Response.Cookies.Append("FavouriteBook", favouriteId.ToString());
            var book = await _context.Books
                .Include(b => b.LegalEntity)
                .Include(b => b.Phouse)
                .FirstOrDefaultAsync(m => m.BookId == favouriteId);

            ViewBag.feedbacks = _context.Feedbacks.Where(f => f.BookId == favouriteId)
                .Include(f => f.Account)
                .ToList();
            return View("show", book);
        }

        public async Task<IActionResult> FavouriteBook()
        {
            int bookId = 0;
            if (Request.Cookies.ContainsKey("FavouriteBook"))
            {
                bookId = Convert.ToInt32(Request.Cookies["FavouriteBook"].ToString());
            }
            var book = await _context.Books
                .Include(b => b.LegalEntity)
                .Include(b => b.Phouse)
                .FirstOrDefaultAsync(m => m.BookId == bookId);

            ViewBag.feedbacks = _context.Feedbacks.Where(f => f.BookId == bookId)
                .Include(f => f.Account)
                .ToList();
            return View("show", book);
        }

        public async Task<IActionResult> LastBook()
        {
            int bookId = 0;
            if (Request.Cookies.ContainsKey("LastBook"))
            {
                bookId = Convert.ToInt32(Request.Cookies["LastBook"].ToString());
            }
            var book = await _context.Books
                .Include(b => b.LegalEntity)
                .Include(b => b.Phouse)
                .FirstOrDefaultAsync(m => m.BookId == bookId);

            ViewBag.feedbacks = _context.Feedbacks.Where(f => f.BookId == bookId)
                .Include(f => f.Account)
                .ToList();
            return View("show", book);
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var dbbookMarketContext = _context.Books.Include(b => b.LegalEntity).Include(b => b.Phouse);
            return View(await dbbookMarketContext.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.LegalEntity)
                .Include(b => b.Phouse)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["LegalEntityId"] = new SelectList(_context.LegalEntities, "LegalEntityId", "LegalEntityId");
            ViewData["PhouseId"] = new SelectList(_context.PublishingHouses, "PhouseId", "PhouseId");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,LegalEntityId,BookName,PhouseId,BookAmount,BookPrice,BookRating,BookDescription,BookImagePath")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LegalEntityId"] = new SelectList(_context.LegalEntities, "LegalEntityId", "LegalEntityId", book.LegalEntityId);
            ViewData["PhouseId"] = new SelectList(_context.PublishingHouses, "PhouseId", "PhouseId", book.PhouseId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["LegalEntityId"] = new SelectList(_context.LegalEntities, "LegalEntityId", "LegalEntityId", book.LegalEntityId);
            ViewData["PhouseId"] = new SelectList(_context.PublishingHouses, "PhouseId", "PhouseId", book.PhouseId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,LegalEntityId,BookName,PhouseId,BookAmount,BookPrice,BookRating,BookDescription,BookImagePath")] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LegalEntityId"] = new SelectList(_context.LegalEntities, "LegalEntityId", "LegalEntityId", book.LegalEntityId);
            ViewData["PhouseId"] = new SelectList(_context.PublishingHouses, "PhouseId", "PhouseId", book.PhouseId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.LegalEntity)
                .Include(b => b.Phouse)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'DbbookMarketContext.Books'  is null.");
            }
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
          return (_context.Books?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
