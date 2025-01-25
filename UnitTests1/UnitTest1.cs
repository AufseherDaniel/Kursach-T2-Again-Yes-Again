using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web;
using System.Collections.Generic;
using Moq;
using Models.Abstract;
using Models.Models;
using WebApp.Controllers;
using System.Linq;
using System.Web.Mvc;
using WebApp.HtmlHelpers;
using WebApp.Models;

namespace UnitTests1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1() //разбиение
        {
            Mock<Iproduct> mock = new Mock<Iproduct>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product{Product_id = 1, Product_name = "Test1" },
                new Product{Product_id = 2, Product_name = "Test2" },
                new Product{Product_id = 3, Product_name = "Test3" },
                new Product{Product_id = 4, Product_name = "Test4" },
                new Product{Product_id = 5, Product_name = "Test5" },
                new Product{Product_id = 6, Product_name = "Test6" }
            });

            StorageController controller = new StorageController(mock.Object);
            controller.max_products = 2;

            ActionResult actionResult = controller.Storage("Все", "Все", 2);

            ViewResult viewResult = actionResult as ViewResult;

            StorageViewModel result = (StorageViewModel)viewResult.Model;

            List<Product> products = result.Products.ToList();
            Assert.IsTrue(products.Count == 2);
            Assert.AreEqual(products[0].Product_name, "Test3");
            Assert.AreEqual(products[1].Product_name, "Test4");
        }

        [TestMethod]
        public void test_generating_pages()
        {
            HtmlHelper myHelper = null;
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                ItemsPerPage = 10,
                TotalItems = 28
            };
            Func<int, string> pageUrl = i => "Page" + i;
            MvcHtmlString result = PagingHelper.PageLinks(null, pagingInfo, pageUrl);
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
            + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
            + @"<a class=""btn btn-default"" href=""Page3"">3</a>", result.ToString());
        }

        [TestMethod]
        public void test_navigation() //проверяем достверность отправления информации контроллером на страницу
        {
            Mock<Iproduct> mock = new Mock<Iproduct>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product{Product_id = 1, Product_name = "Test1" },
                new Product{Product_id = 2, Product_name = "Test2" },
                new Product{Product_id = 3, Product_name = "Test3" },
                new Product{Product_id = 4, Product_name = "Test4" },
                new Product{Product_id = 5, Product_name = "Test5" },
                new Product{Product_id = 6, Product_name = "Test6" }
            });
            StorageController controller = new StorageController(mock.Object);
            controller.max_products = 2;
            ActionResult actionResult = controller.Storage("Все", "Все", 2);

            ViewResult viewResult = actionResult as ViewResult;

            StorageViewModel result = (StorageViewModel)viewResult.Model;
            PagingInfo pagingInfo = result.PagingInfo;
            Assert.AreEqual(pagingInfo.CurrentPage, 2);
            Assert.AreEqual(pagingInfo.ItemsPerPage, 2);
            Assert.AreEqual(pagingInfo.TotalItems, 6);
            Assert.AreEqual(pagingInfo.TotalPages, 3);
        }
    }
}

