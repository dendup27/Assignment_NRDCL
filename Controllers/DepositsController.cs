using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment_NRDCL.Data;
using Assignment_NRDCL.Models;

namespace Assignment_NRDCL.Controllers
{
    public class DepositsController : Controller
    {
        private readonly NrdclDbContext _context;

        public DepositsController(NrdclDbContext context)
        {
            _context = context;
        }

        // GET: Deposits
        public async Task<IActionResult> Index()
        {
            return View(await _context.Deposits.ToListAsync());
        }

        // GET: Deposits/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deposit = await _context.Deposits
                .FirstOrDefaultAsync(m => m.CustomerID == id);
            if (deposit == null)
            {
                return NotFound();
            }

            return View(deposit);
        }

        // GET: Deposits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deposits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerID,LastAmount,Balance")] Deposit deposit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deposit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deposit);
        }

        // GET: Deposits/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deposit = await _context.Deposits.FindAsync(id);
            if (deposit == null)
            {
                return NotFound();
            }
            return View(deposit);
        }

        // POST: Deposits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CustomerID,LastAmount,Balance")] Deposit deposit)
        {
            if (id != deposit.CustomerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deposit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepositExists(deposit.CustomerID))
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
            return View(deposit);
        }

        // GET: Deposits/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deposit = await _context.Deposits
                .FirstOrDefaultAsync(m => m.CustomerID == id);
            if (deposit == null)
            {
                return NotFound();
            }

            return View(deposit);
        }

        // POST: Deposits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var deposit = await _context.Deposits.FindAsync(id);
            _context.Deposits.Remove(deposit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepositExists(string id)
        {
            return _context.Deposits.Any(e => e.CustomerID == id);
        }
    }
}
