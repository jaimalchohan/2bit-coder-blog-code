using System;

namespace LuceneDemo.Data
{
    using NHibernate;
    using FluentNHibernate.Cfg;
    using LuceneDemo.Data.Mapping;

    public class ProductDbSession
    {
        private static ISessionFactory _sessionFactory;

        private ProductDbSession()
        {
            // Static Initializer
        }

        public static void Configure()
        {
            if(_sessionFactory == null)
            {
                var cfg = new NHibernate.Cfg.Configuration().Configure();
                _sessionFactory = Fluently.Configure(cfg)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BrandMap>())
                    .BuildSessionFactory();
            }
            else
            {
                throw new InvalidOperationException("Object has already ben initalised.");
            }
        }

        public static ISession Open()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
