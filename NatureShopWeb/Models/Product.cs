using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatureShopWeb.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductType { get; set; }

        public string Detail { get; set; }

        public bool InStock { get; set; }

        public double Price { get; set; }

        public double Discount { get; set; }

        public string Image { get; set; }

        public byte BestSeller { get; set; }


    }
}
