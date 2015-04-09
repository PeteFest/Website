using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using StructureMap;
using IDependencyResolver = System.Web.Mvc.IDependencyResolver;

namespace PeteFest.Web.IoC
{
    public class StructureMapDependencyResolver : IDependencyScope, IDependencyResolver
    {
        protected readonly IContainer Container;

        public StructureMapDependencyResolver(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.Container = container;
        }

        public void Dispose()
        {
            this.Container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
            {
                return null;
            }

            try
            {
                return serviceType.IsAbstract || serviceType.IsInterface
                    ? this.Container.TryGetInstance(serviceType)
                    : this.Container.GetInstance(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.Container.GetAllInstances(serviceType).Cast<object>();
        }

        protected IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return this.Container.GetAllInstances(serviceType).Cast<object>();
        }

        protected object DoGetInstance(Type serviceType, string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return serviceType.IsAbstract || serviceType.IsInterface
                    ? this.Container.TryGetInstance(serviceType)
                    : this.Container.GetInstance(serviceType);
            }

            return this.Container.GetInstance(serviceType, key);
        }
    }
}