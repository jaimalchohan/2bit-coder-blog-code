using System;

namespace LuceneDemo.Data
{
    using NHibernate;
    using FluentNHibernate.Cfg;
    using LuceneDemo.Data.Mapping;

    public class ProductDbSessionFactory
    {
        private static ISessionFactory _sessionFactory;

        private ProductDbSessionFactory()
        {
            // Private Initializer
        }

        public static ProductDbSessionFactory Configure()
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

            return new ProductDbSessionFactory();
        }

        public ISession Open()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
