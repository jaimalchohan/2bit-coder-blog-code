namespace LuceneDemo.Service.Plumbing
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Facilities.WcfIntegration;
    using LuceneDemo.Service.Contracts;

    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<WcfFacility>();
            container.Register(Component.For<ISearchService>()
                                        .ImplementedBy<SearchService>()
                                        .LifeStyle.PerWcfSession());
        }
    }
}