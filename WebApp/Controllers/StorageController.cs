using Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class StorageController : Controller
    {
        private Iproduct products;

        public StorageController(Iproduct products)
        {
            this.products = products;
        }


        // GET: Storage
        public ActionResult Storage()
        {
            return View(products.Products);
        }
    }
}