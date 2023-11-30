using Customer.DataLayer.Repositories;
using Customer.Import.Contracts;
using Customer.Import.Services;
using CustomerApp.DataLayer.Contracts;
using CustomerApp.DataLayer.NHibernate;
using CustomerApp.DataLayer.Repositories;
using NHibernate;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace customerApp.WebClient
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterInstance(typeof(ISession), NHibernateHelper.OpenSession());

            // Register the repository
            container.RegisterType(typeof(IGenericRepositoryAsync<,>), typeof(GenericRepositoryAsync<,>));
            container.RegisterType<IOrderRepositoryAsync, OrderRepositoryAsync>();
            container.RegisterType<IOrderIDetailRepositoryAsync, OrderDetailRepositoryAsync>();
            container.RegisterType<ICustomerRepositoryAsync, CustomerRepositoryAsync>();
            container.RegisterType<ICustomerImport, CustomerImport>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}