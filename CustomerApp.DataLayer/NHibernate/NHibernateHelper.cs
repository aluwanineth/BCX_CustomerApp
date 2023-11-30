using CustomerApp.DataLayer.Mappings;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using NHibernate;
using NHibernate.Cfg;
using System.Web;

namespace CustomerApp.DataLayer.NHibernate
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISession OpenSession()
        {
            if (_sessionFactory == null)
            {
                var configuration = new Configuration();
                var configurationPath = HttpContext.Current.Server.MapPath
                                    (@"~\NHibernateConfig\NHibernate.configuration.xml");
                configuration.Configure(configurationPath);
                var mapper = new ModelMapper();
                mapper.AddMapping(typeof(CustomerMapping));
                mapper.AddMapping<OrderMapping>();
                mapper.AddMapping<OrderDetailMapping>();
                HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
                configuration.AddMapping(domainMapping);

                _sessionFactory = configuration.BuildSessionFactory();
            }

            return _sessionFactory.OpenSession();
        }
    }
}