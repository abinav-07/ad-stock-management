using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupCourseWork.Data;
using GroupCourseWork.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace GroupCourseWork.Controllers
{
    public class PurchasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Purchases
        public async Task<IActionResult> Index()
        {
            return View(await _context.Purchase.ToListAsync());
        }

        // GET: Purchases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchase == null)
            {
                return NotFound();
            }
            //Adding Product Details
            List<PurchaseDetail> lstData = new List<PurchaseDetail>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {

                command.CommandText = "Select PurchaseId, ProductId,Quantity,Price FROM PurchaseDetail WHERE PurchaseId=" + id;

                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {

                    PurchaseDetail data;

                    while (result.Read())
                    {
                        data = new PurchaseDetail();
                        data.ProductId = result.GetInt32(0);
                        data.Quantity = result.GetInt32(2);
                        data.Price = result.GetInt32(2);
                        lstData.Add(data);
                    }
                }
            }

            ViewBag.ProductList = lstData;

            return View(purchase);
        }

        // GET: Purchases/Create
        public IActionResult Create()
        {
            ViewBag.ProductDetails = GetProductList();
            int lastBillId = _context.Purchase.Max(item => item.BillNo);
            ViewBag.LatestBillId = lastBillId + 1;
            return View();

        }

        public IEnumerable<SelectListItem> GetProductList()
        {
            return _context.Product.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.ProductName
            }).ToList();
        }

        // POST: Purchases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PurchaseDate,VendorName,BillNo,VendorAddress")]Purchase purchase,  List<PurchaseDetail> PurchaseDetailList)
        {           
            
            if (ModelState.IsValid)
            {
                int lastBillId = _context.Purchase.Max(item => item.BillNo);
                purchase.BillNo = lastBillId + 1;
                _context.Add(purchase);
                await _context.SaveChangesAsync();
                foreach(PurchaseDetail element in PurchaseDetailList)
                {
                    
                    element.PurchaseId = purchase.Id;
                    
                    element.ProductId = element.ProductId;
                    element.Price = element.Quantity * element.Price;

                    _context.Add(element);
                    await _context.SaveChangesAsync();
                    using (var command = _context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "UPDATE ProductStock SET Quantity=Quantity+"+element.Quantity+"WHERE ProductId="+element.ProductId;
                        _context.Database.OpenConnection();
                        command.ExecuteNonQuery();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            
            return View();
        }

        // GET: Purchases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PurchaseDate,VendorName,BillNo,VendorAddress")] Purchase purchase)
        {
            if (id != purchase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseExists(purchase.Id))
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
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchase
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchase = await _context.Purchase.FindAsync(id);
            _context.Purchase.Remove(purchase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseExists(int id)
        {
            return _context.Purchase.Any(e => e.Id == id);
        }
    }
}
