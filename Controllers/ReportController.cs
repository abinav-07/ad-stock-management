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

        public IActionResult InactiveCustomerReport()
        {
            List<InactiveCustomerViewModel> lstData = new List<InactiveCustomerViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT FORMAT(SalesDate, 'MM-dd') AS Date,CustomerName from Customer c join sales s on c.id = s.CustomerId where DATEDIFF(day,SalesDate,GETDATE()) > 31 Order by day(SalesDate);";


                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {

                    InactiveCustomerViewModel data;

                    while (result.Read())
                    {
                        data = new InactiveCustomerViewModel();
                        data.LastBoughtDate = result.GetDateTime(0);
                        data.CustomerName = result.GetString(1);
                        lstData.Add(data);
                    }
                }

                return View(lstData);
            }
        }

        public IActionResult InactiveProductReport()
        {
            List<InactiveProductViewModel> lstData = new List<InactiveProductViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT FORMAT(s.SalesDate, 'MM-dd') AS Date,p.ProductName from Product p join SalesDetail sd on p.id = sd.ProductId join Sales s on sd.SalesId = s.Id  where DATEDIFF(day,GETDATE(),SalesDate) > 31 Order by day(SalesDate)";


                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {

                    InactiveProductViewModel data;

                    while (result.Read())
                    {
                        data = new InactiveProductViewModel();
                        data.LastBoughtDate = result.GetDateTime(0);
                        data.ProductName = result.GetString(1);
                        data.Quantity = result.GetInt32(2);
                        lstData.Add(data);
                    }
                }

                return View(lstData);
            }
        }
        public IActionResult ProductOutOfList([FromQuery] string SortBy = "")
        {
            List<ProductOutOfStockViweModel> lstData = new List<ProductOutOfStockViweModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                if (SortBy == "Name")
                {
                    command.CommandText = "Select p.ProductName, pd.Quantity, pu.PurchaseDate From Product p join PurchaseDetail pd on p.Id = pd.ProductId join Purchase pu on pd.PurchaseId = pu.Id Where pd.Quantity <10 Order By ProductName";
                }
                else if(SortBy == "Quantity")
                {
                    command.CommandText = "Select p.ProductName, pd.Quantity, pu.PurchaseDate From Product p join PurchaseDetail pd on p.Id = pd.ProductId join Purchase pu on pd.PurchaseId = pu.Id Where pd.Quantity <10 Order By Quantity Desc";
                } else {
                    command.CommandText = "Select p.ProductName, pd.Quantity, pu.PurchaseDate From Product p join PurchaseDetail pd on p.Id = pd.ProductId join Purchase pu on pd.PurchaseId = pu.Id Where pd.Quantity <10 Order By PurchaseDate Desc";
                }

                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {

                    ProductOutOfStockViweModel data;

                    while (result.Read())
                    {
                        data = new ProductOutOfStockViweModel();
                        data.ProductName = result.GetString(0);
                        data.Quantity = result.GetInt32(1);
                        data.PurchaseDate= result.GetDateTime(2);
                        lstData.Add(data);
                    }
                }
            }
            return View(lstData);

        }
    }
}


