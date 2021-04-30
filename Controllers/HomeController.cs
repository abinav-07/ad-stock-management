using GroupCourseWork.Data;
using GroupCourseWork.Models;
using GroupCourseWork.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GroupCourseWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }



        [Authorize(Roles = "Admin,User")]
        public IActionResult Index()
        {

            List<ProductOutOfStockViweModel> lstData = new List<ProductOutOfStockViweModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {

                command.CommandText = "Select p.ProductName, pd.Quantity, pu.PurchaseDate From Product p join PurchaseDetail pd on p.Id = pd.ProductId join Purchase pu on pd.PurchaseId = pu.Id Where pd.Quantity <10 Order By PurchaseDate Desc";


                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {

                    ProductOutOfStockViweModel data;

                    while (result.Read())
                    {
                        data = new ProductOutOfStockViweModel();
                        data.ProductName = result.GetString(0);
                        data.Quantity = result.GetInt32(1);
                        data.PurchaseDate = result.GetDateTime(2);
                        lstData.Add(data);
                    }
                }
            }
            ViewBag.ProductList = lstData;
            return View();
        }
        [Authorize(Roles = "Admin,User")]
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
