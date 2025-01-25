using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class StorageViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
        public string SupplierFilter { get; set; }
        public string ExpirationFilter { get; set; }
    }
}