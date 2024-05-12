using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labb4LibraryOnline.Data;
using Labb4LibraryOnline.Models;

namespace Labb4LibraryOnline.Controllers
{
    public class BookLoansController : Controller
    {
        private readonly LibraryOnlineDbContext _context;

        public BookLoansController(LibraryOnlineDbContext context)
        {
            _context = context;
        }

        // GET: BookLoans by CustomerName
        public async Task<IActionResult> Index(string customerName)
        {
            // Hämta alla kunder och sortera dem efter namn i dropdown-listan
            var customers = await _context.Customers.OrderBy(c => c.CustomerName).ToListAsync();
            var selectList = new SelectList(customers, nameof(Customer.CustomerName), nameof(Customer.CustomerName));
            ViewBag.Customers = selectList;

            // inkludera book och customer
            IQueryable<BookLoan> allLoans = _context.Loans.Include(b => b.Book).Include(b => b.Customer);

            // Om customerName är specificerat, filtrera lån baserat på kundnamn
            if (!string.IsNullOrEmpty(customerName))
            {
                allLoans = allLoans.Where(l => l.Customer.CustomerName == customerName);
            }

            // Returnera vyn med den filtrerade listan av lån
            return View(await allLoans.ToListAsync());
        }


        // GET: BookLoans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookLoan = await _context.Loans
                .Include(b => b.Book)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.BookLoanId == id);
            if (bookLoan == null)
            {
                return NotFound();
            }

            return View(bookLoan);
        }

        // GET: BookLoans/Create
        public IActionResult Create()
        {
            ViewData["FkBookId"] = new SelectList(_context.Books, "BookId", "BookTitle");
            ViewData["FkCustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            return View();
        }

        // POST: BookLoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookLoanId,FkCustomerId,FkBookId,BookLoanDate,BookReturnDate,Status")] BookLoan bookLoan)
        {
            // Sätter Status till NotReturned på alla lån som skapas
            if (bookLoan.Status != LoanStatus.NotReturned)
            {
                bookLoan.Status = LoanStatus.NotReturned;
            }

            // Kontrollera om modellen är giltig
            if (ModelState.IsValid)
            {
                // Om giltig, lägg till den i context och spara
                _context.Add(bookLoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["FkBookId"] = new SelectList(_context.Books, "BookId", "BookAuthor", bookLoan.FkBookId);
            ViewData["FkCustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", bookLoan.FkCustomerId);
            return View(bookLoan);
        }



        // GET: BookLoans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookLoan = await _context.Loans.FindAsync(id);
            if (bookLoan == null)
            {
                return NotFound();
            }
            ViewData["FkBookId"] = new SelectList(_context.Books, "BookId", "BookAuthor", bookLoan.FkBookId);
            ViewData["FkCustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", bookLoan.FkCustomerId);
            return View(bookLoan);
        }

        // POST: BookLoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookLoanId,FkCustomerId,FkBookId,BookLoanDate,BookReturnDate,Status")] BookLoan bookLoan)
        {
            if (id != bookLoan.BookLoanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookLoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookLoanExists(bookLoan.BookLoanId))
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
            ViewData["FkBookId"] = new SelectList(_context.Books, "BookId", "BookAuthor", bookLoan.FkBookId);
            ViewData["FkCustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", bookLoan.FkCustomerId);
            return View(bookLoan);
        }

        // GET: BookLoans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookLoan = await _context.Loans
                .Include(b => b.Book)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.BookLoanId == id);
            if (bookLoan == null)
            {
                return NotFound();
            }

            return View(bookLoan);
        }

        // POST: BookLoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookLoan = await _context.Loans.FindAsync(id);
            if (bookLoan != null)
            {
                _context.Loans.Remove(bookLoan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookLoanExists(int id)
        {
            return _context.Loans.Any(e => e.BookLoanId == id);
        }
    }
}
