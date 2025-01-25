using Models.Abstract;
using Models.Context;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class PriemkaModeController : Controller
    {
        // GET: PriemkaMode
        private Iproduct products;

        public PriemkaModeController(Iproduct products)
        {
            this.products = products;
        }
        public ViewResult Priemka()
        {
            return View(products.Products);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                using (var context = new StoreDBContext())
                {
                    context.Products.Add(product);
                    context.SaveChanges();    
                }

                return RedirectToAction("Priemka");
            }
            return View(product);
        }
    }
}