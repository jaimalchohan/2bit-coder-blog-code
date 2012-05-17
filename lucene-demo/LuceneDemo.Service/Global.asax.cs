namespace LuceneDemo.Service
{
    using System;
    using Castle.Windsor;
    using Castle.Windsor.Installer;
    using LuceneDemo.Service.Plumbing;

    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var container = new WindsorContainer();

            container.Install(FromAssembly.This());

            AutoMapperConfiguration.Configure();
        }
    }
}