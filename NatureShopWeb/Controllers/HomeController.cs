using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NatureShopWeb.Data;
using NatureShopWeb.Models;
using NatureShopWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Configuration;

namespace NatureShopWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            //return View();

            List<Product> products = _db.Product.ToList();
            List<ProductViewModel> productVM = new List<ProductViewModel>();

            foreach (var product in products)
            {
                ProductViewModel item = new ProductViewModel();
                item.Product = product;

                RegionInfo regioninfo = new RegionInfo("TH");
                item.CurrencySymbol = regioninfo.CurrencyNativeName;

                if (product.InStock == false)
                {
                    item.IsInStock = "Stock Out";
                }
                else
                {
                    item.IsInStock = "In Stock";
                }

                if (product.Discount > 0)
                {
                    double DiscountSale = (product.Discount * product.Price) / 100;

                    item.SalePrice = product.Price - DiscountSale;
                }
                else
                {
                    item.SalePrice = product.Price;
                }

                productVM.Add(item);
            }

            return View(productVM);
        }

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
