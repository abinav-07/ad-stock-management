using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupCourseWork.Data;
using GroupCourseWork.Models;

namespace GroupCourseWork.Controllers
{
    public class SalesDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalesDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SalesDetail.Include(s => s.ProId).Include(s => s.SalId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SalesDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesDetail = await _context.SalesDetail
                .Include(s => s.ProId)
                .Include(s => s.SalId)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesDetail == null)
            {
                return NotFound();
            }

            return View(salesDetail);
        }

        // GET: SalesDetails/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName");
            ViewData["SalesId"] = new SelectList(_context.Sales, "Id", "Id");
            return View();
        }

        // POST: SalesDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SalesId,ProductId,Quantity,Price")] SalesDetail salesDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName", salesDetail.ProductId);
            ViewData["SalesId"] = new SelectList(_context.Sales, "Id", "Id", salesDetail.SalesId);
            return View(salesDetail);
        }

        // GET: SalesDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesDetail = await _context.SalesDetail.FindAsync(id);
            if (salesDetail == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName", salesDetail.ProductId);
            ViewData["SalesId"] = new SelectList(_context.Sales, "Id", "Id", salesDetail.SalesId);
            return View(salesDetail);
        }

        // POST: SalesDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SalesId,ProductId,Quantity,Price")] SalesDetail salesDetail)
        {
            if (id != salesDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesDetailExists(salesDetail.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName", salesDetail.ProductId);
            ViewData["SalesId"] = new SelectList(_context.Sales, "Id", "Id", salesDetail.SalesId);
            return View(salesDetail);
        }

        // GET: SalesDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesDetail = await _context.SalesDetail
                .Include(s => s.ProId)
                .Include(s => s.SalId)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesDetail == null)
            {
                return NotFound();
            }

            return View(salesDetail);
        }

        // POST: SalesDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesDetail = await _context.SalesDetail.FindAsync(id);
            _context.SalesDetail.Remove(salesDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesDetailExists(int id)
        {
            return _context.SalesDetail.Any(e => e.Id == id);
        }
    }
}
