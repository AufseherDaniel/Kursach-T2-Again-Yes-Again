using Models.Abstract;
using Models.Context;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StorageController : Controller
    {
        private Iproduct products;
        public int max_products = 2;

        public StorageController(Iproduct products)
        {
            this.products = products;
        }

        // GET: Storage
        public ViewResult Storage(string supplierName = null, int page = 1)
        {
            var query = products.Products.AsQueryable();

            // Применяем фильтр, если он есть, и если не выбран вариант "Все"
            if (!string.IsNullOrEmpty(supplierName) && supplierName != "Все")
            {
                query = query.Where(p => p.Supplier.Supplier_name.Contains(supplierName));
            }

            var model = new StorageViewModel
            {
                Products = query
                    .OrderBy(product => product.Product_price)
                    .Skip((page - 1) * max_products)
                    .Take(max_products),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = max_products,
                    TotalItems = query.Count()
                },
                SupplierFilter = supplierName,
                Suppliers = products.Suppliers.ToList() 
            };

            return View(model);
        }

    }



}