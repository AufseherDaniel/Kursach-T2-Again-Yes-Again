using Models.Abstract;
using Models.Context;
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
            kernel.Bind<Iproduct>().To<DBProducts>();
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