using Models.Abstract;
using Models.Models;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Infrastructure
{
    public class NinjaDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjaDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        private void AddBindings() //для привязок
        {
            Mock<Iproduct> mock = new Mock<Iproduct>();
            mock.Setup(m => m.Products).Returns(new List<Product> 
            { 
                new Product { Product_id = 0, Product_name = "Молоко", Product_price = 69.99m , Expiration_date = new DateTime(2025, 02, 13), Count_at_storage = 20, Supplier_id = 0},
                new Product { Product_id = 1, Product_name = "Сыр Страчетолли", Product_price = 143.00m , Expiration_date = new DateTime(2025, 03, 31), Count_at_storage = 12, Supplier_id = 0}
            }
            );
            kernel.Bind<Iproduct>().ToConstant(mock.Object);
        }

        public object GetService(Type serviceType)
        {
            return kernel.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}