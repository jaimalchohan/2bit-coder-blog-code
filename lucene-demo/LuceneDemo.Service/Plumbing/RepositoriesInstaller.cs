namespace LuceneDemo.Service.Plumbing
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Castle.MicroKernel.SubSystems.Configuration;
    using LuceneDemo.Data.Repository;
    using LuceneDemo.Data;
    using Castle.Facilities.WcfIntegration;

    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ProductDbSessionFactory>()
                                        .UsingFactoryMethod(ProductDbSessionFactory.Configure)
                                        .LifeStyle.Singleton);

            container.Register(Component.For<NHibernate.ISession>()
                                        .UsingFactoryMethod(() => container.Resolve<ProductDbSessionFactory>().Open())
                                        .LifeStyle.PerWcfSession());

            container.Register(Classes.FromAssemblyContaining<ProductRepository>()
                                      .Where(x => !x.IsAbstract)
                                      .LifestylePerWcfSession());
        }
    }
}