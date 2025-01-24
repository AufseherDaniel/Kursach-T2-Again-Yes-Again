using Ninject;
using System.Web.Mvc;

namespace Web.Containers
{
    public class NinjaDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjaDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        private void AddBindings() //привязки
        {

        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}
