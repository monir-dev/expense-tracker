using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ExpenseContext _context;

        public HomeController(ExpenseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Expenses.Include(x => x.Category).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);

            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_context.Categories.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("CategoryId,ExpanseDate,Amount")] Expense expense)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(expense);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                throw;
            }

            ViewBag.CategoryId = new SelectList(_context.Categories.ToList(), "Id", "Name", expense.CategoryId);
            return View(expense);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = _context.Expenses.Find(id);
            if (expense == null)
            {
                return NotFound();
            }

            ViewBag.CategoryId = new SelectList(_context.Categories.ToList(), "Id", "Name", expense.CategoryId);
            return View(expense);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("Id,CategoryId,ExpanseDate,Amount")] Expense expense)
        {
            if (id != expense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseExists(expense.Id))
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

            ViewBag.CategoryId = new SelectList(_context.Categories.ToList(), "Id", "Name", expense.CategoryId);
            return View("Edit", expense);
        }

        // GET: Categories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            try
            {
                var expense = await _context.Expenses.FindAsync(id);
                _context.Expenses.Remove(expense);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseExists(id))
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


        private bool ExpenseExists(int id) => _context.Expenses.Any(e => e.Id == id);

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
