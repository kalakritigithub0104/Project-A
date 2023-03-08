using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaOrderSystem2.Data;
using PizzaOrderSystem2.Models;

namespace PizzaOrderSystem2.Controllers
{
    public class OrdersController : Controller
    {
        private readonly PizzaOrderSystem2Context _context;
        public const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=PizzaOrderSystem2Context-3ffb4c34-7333-465b-93c3-5bc9061c51b4;Trusted_Connection=True";
        protected void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connectionString);
        }
        public OrdersController(PizzaOrderSystem2Context context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var pizzaOrderSystem2Context = _context.Order.Include(o => o.Pizza);
            return View(await pizzaOrderSystem2Context.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Pizza)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["PizzaID"] = new SelectList(_context.Pizza, "PizzaID", "PizzaID");
            return View();
        }
        //public async Task<IActionResult> UpdateStatus(int a)
        //{
        //    var stat = _context.Status;
        //    using (var dbconnect = _context)
        //    {

        //        Status? l = dbconnect.Status..Find(a);

        //        l.OrderStatus = "Order Placed";
        //        dbconnect.SaveChangesAsync();
        //        return View(stat);

        //    }
        //}

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,Quantity,AddedFlavors,Contact_No,Address,Total,PizzaID")] Order order)
        {
            var a = order.OrderID;
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                //await UpdateStatus(a);
                return RedirectToAction(nameof(Index)); 
            }
            ViewData["PizzaID"] = new SelectList(_context.Pizza, "PizzaID", "PizzaID", order.PizzaID);
            return View(order);
        }
  //      public IActionResult Small()
  //      {
  //          return View();
  //      }
		//public IActionResult Medium()
		//{
		//	return View();
		//}
		//public IActionResult Large()
		//{
		//	return View();
		//}

		// GET: Orders/Edit/5
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["PizzaID"] = new SelectList(_context.Pizza, "PizzaID", "PizzaID", order.PizzaID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,Quantity,AddedFlavors,Contact_No,Address,Total,PizzaID")] Order order)
        {
            if (id != order.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderID))
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
            ViewData["PizzaID"] = new SelectList(_context.Pizza, "PizzaID", "PizzaID", order.PizzaID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Pizza)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Order == null)
            {
                return Problem("Entity set 'PizzaOrderSystem2Context.Order'  is null.");
            }
            var order = await _context.Order.FindAsync(id);
            if (order != null)
            {
                _context.Order.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return (_context.Order?.Any(e => e.OrderID == id)).GetValueOrDefault();
        }
    }
}
