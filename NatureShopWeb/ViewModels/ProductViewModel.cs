using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NatureShopWeb.Models;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Globalization;

namespace NatureShopWeb.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }

        public string CurrencySymbol { get; set; }
        public string IsInStock { get; set; }
        public double SalePrice { get; set; }


    }
}
