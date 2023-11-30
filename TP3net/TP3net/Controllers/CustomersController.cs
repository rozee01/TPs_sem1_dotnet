using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP3net.Models;

namespace TP3net.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Customers.Include(c => c.Membership);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.Membership)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["MembershipTypeId"] = new SelectList(_context.MembershipTypes, "Id", "Id");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,MembershipTypeId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MembershipTypeId"] = new SelectList(_context.MembershipTypes, "Id", "Id", customer.MembershipTypeId);
            return View(customer);
        }
//        public IActionResult Create()
//        {
//            var members = _db.membershiptypes.ToList();
//            ViewBag.member = members.Select(members => new SelectListItem()
//            {
//                Text = members.Name,
//                Value = members.Id.ToString()
//            });
//            return View();
//        }
//        [HttpPost]
//        public IActionResult Create(Customer c)
//        {
//            if (!ModelState.IsValid)
//            {
//                var members = _db.membershiptypes.ToList();
//                ViewBag.member = members.Select(members => new SelectListItem()
//                {
//                    Text = members.Name,

//                    Value = members.Id.ToString()

//                });
//                return View();
//            }
//            c.CustomerId = new Guid();
//            _db.customers.Add(c);
//            _db.SaveChanges();
//            return RedirectToAction(nameof(Index));
//        }
////Pour la Vue
//<div class="form-group">
//<label asp-for="MembershiptypeID" class="control-label">Membership Name</label>

//<select asp-for="MembershiptypeID" class ="form-control" asp-
//items="@ViewBag.member"></select>

//<span asp-validation-for="MembershiptypeID" class="text-red"></span>
//</div>

        //le code ci-dessus est utilisé pour faire un dropmenu des memberships name valables en utilisant viewbag qui aide à transférer des données
        //du controleur vers la vue

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["MembershipTypeId"] = new SelectList(_context.MembershipTypes, "Id", "Id", customer.MembershipTypeId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,MembershipTypeId")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            ViewData["MembershipTypeId"] = new SelectList(_context.MembershipTypes, "Id", "Id", customer.MembershipTypeId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.Membership)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'AppDbContext.Customers'  is null.");
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
          return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
