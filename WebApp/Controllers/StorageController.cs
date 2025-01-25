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
        public ActionResult Storage(string supplierName = "Все", string expirationFilter = "Все", int page = 1)
        {
            var query = products.Products.AsQueryable();

            // Фильтрация по поставщику
            if (supplierName != "Все")
            {
                query = query.Where(p => p.Supplier.Supplier_name == supplierName);
            }

            // Фильтрация по сроку годности
            if (expirationFilter == "Заканчивается через неделю")
            {
                var weekFromNow = DateTime.Now.AddDays(7);
                query = query.Where(p => p.Expiration_date <= weekFromNow && p.Expiration_date >= DateTime.Now);
            }

           
            var viewModel = new StorageViewModel
            {
                Products = query.OrderBy(p => p.Product_price)
                               .Skip((page - 1) * max_products)
                               .Take(max_products),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = max_products,
                    TotalItems = query.Count()
                },
                SupplierFilter = supplierName,
                ExpirationFilter = expirationFilter, // Добавляем новый фильтр
                Suppliers = products.Products
                                    .Select(p => p.Supplier)
                                    .Distinct()
                                    .ToList() // Инициализация списка поставщиков
            };

            return View(viewModel);
        }

    }



}