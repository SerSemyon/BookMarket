using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookMarket;
using Microsoft.AspNetCore.Authorization;

namespace BookMarket.Controllers
{
    public class AccountsController : Controller
    {
        private readonly DbbookMarketContext _context;

        public AccountsController() // DbbookMarketContext context
        {
            _context = new DbbookMarketContext();
        }

        [Route("api/Accounts")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

        [Route("api/Accounts/{id?}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        [Route("api/Accounts/put/{id?}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, [FromBody]Account newData)
        {
            if (id != newData.Id)
            {
                return BadRequest();
            }

            Account account = _context.Accounts.FirstOrDefault(x => x.Id == id);
            if (account == null)
            {
                return BadRequest();
            }

            account.AccName = newData.AccName;
            account.AccLastName = newData.AccLastName;
            account.AccMiddleName = newData.AccMiddleName;
            account.AccGender = newData.AccGender;
            account.AccBirthday = newData.AccBirthday;
            account.AccEmail = newData.AccEmail;
            account.AccPhoneRegistration = newData.AccPhoneRegistration;
            account.AccHashPassword = newData.AccHashPassword;

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [Route("api/Accounts/post")]
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount([FromBody]Account account)
        {
            account.TypeId = 3;
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = account.Id }, account);
        }

        [Route("api/Accounts/delete/{id?}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }

        [Route("Accounts")]
        public async Task<IActionResult> Index()
        {
            var dbbookMarketContext = _context.Accounts.Include(a => a.Type);
            return View();
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            ViewData["TypeName"] = new SelectList(_context.AccountTypes.Where<AccountType>(x => x.TypeName != "Администратор"), "TypeName", "TypeName");
            return View();
        }

        public IActionResult Registration()
        {
            var roles = new List<SelectListItem>();
            roles.Add(new SelectListItem { Text = "Продавец", Value = "2" });
            roles.Add(new SelectListItem { Text = "Покупатель", Value = "3" });
            ViewData["TypeName"] = roles;

            ViewData["TypeName"] = new SelectList(_context.AccountTypes.Where<AccountType>(x => x.TypeName != "Администратор"), "TypeId", "TypeName");

            //ViewData["TypeName"] = new SelectList(_context.AccountTypes.Where<AccountType>(x => x.TypeName != "Администратор"), "TypeId", "TypeId");

            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId, TypeId,AccName,AccLastName,AccMiddleName,AccGender,AccBirthday,AccEmail,AccPhoneRegistration,AccHashPassword")] Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(account);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            ViewData["TypeName"] = new SelectList(_context.AccountTypes.Where<AccountType>(x => x.TypeName != "Администратор" ), "TypeName", "TypeName", account.Type.TypeName);
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountId,TypeName,AccName,AccLastName,AccMiddleName,AccGender,AccBirthday,AccEmail,AccPhoneRegistration,AccHashPassword")] Account account)
        {
            if (id != account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.Id))
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
            ViewData["TypeName"] = new SelectList(_context.AccountTypes, "TypeName", "TypeName", account.Type.TypeName);
            return View(account);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Accounts == null)
            {
                return Problem("Entity set 'DbbookMarketContext.Accounts'  is null.");
            }
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
