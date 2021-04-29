using GroupCourseWork.Data;
using GroupCourseWork.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupCourseWork.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StockListReport([FromQuery] string SelectedProduct="")
        {
            List<ProductStockViewModel> lstData = new List<ProductStockViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                if (SelectedProduct=="")
                {
                    command.CommandText = "SELECT p.Id as ProductId,p.ProductName as ProductName,ps.Quantity from Product p inner join ProductStock ps on p.Id=ps.ProductId";
                }
                else
                {
                    command.CommandText = "SELECT p.Id as ProductId,p.ProductName as ProductName,ps.Quantity from Product p inner join ProductStock ps on p.Id=ps.ProductId WHERE p.Id="+SelectedProduct;
                }
                
                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    
                    ProductStockViewModel data;

                    while (result.Read())
                    {
                        data = new ProductStockViewModel();
                        data.ProductId = result.GetInt32(0);
                        data.ProductName = result.GetString(1);
                        data.Quantity = result.GetInt32(2);
                        lstData.Add(data);
                    }
                }
            }
            return View(lstData);

        }
        public IActionResult CustomerProductDetailsReport([FromQuery] string SelectedProduct = "")
        {    

            List<CustomerProductsViewModel> lstData = new List<CustomerProductsViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                if (SelectedProduct == "")
                {
                    command.CommandText = "SELECT p.Id as ProductId,p.ProductName as ProductName,ps.Quantity from Product p inner join ProductStock ps on p.Id=ps.ProductId";
                }
                else
                {
                    command.CommandText = "SELECT p.Id as ProductId,p.ProductName as ProductName,ps.Quantity from Product p inner join ProductStock ps on p.Id=ps.ProductId WHERE p.Id=" + SelectedProduct;
                }

                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {

                    CustomerProductsViewModel data;

                    while (result.Read())
                    {
                        data = new CustomerProductsViewModel();
                        data.ProductId = result.GetInt32(0);
                        data.ProductName = result.GetString(1);
                        data.Quantity = result.GetInt32(2);
                        lstData.Add(data);
                    }
                }
            }
            return View(lstData);

        }
    }
}


