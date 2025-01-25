using Models.Abstract;
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
        public ViewResult Storage(int page = 1)
        {
            StorageViewModel model = new StorageViewModel
            {
                Products = products.Products
                .OrderBy(product => product.Product_price)
                .Skip((page - 1) * max_products)
                .Take(max_products),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = max_products,
                    TotalItems = products.Products.Count()
                }
            };
            return View(model);
        }
    }
}