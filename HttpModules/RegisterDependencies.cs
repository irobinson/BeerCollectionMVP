namespace BeerCollection.HttpModules
{
    using System.Web;
    using Data;
    using DotNetNuke.ComponentModel;

    public class BeerCollectionModule : IHttpModule
    {
        public string ModuleName
        {
            get { return "BeerCollectionModule"; }
        }

        static BeerCollectionModule()
        {
            if(ComponentFactory.Container == null)
            {
                ComponentFactory.Container = new SimpleContainer();
            }
            ComponentFactory.Container.RegisterComponent<IBeerRepository, BeerRepository>();
        }

        public void Init(HttpApplication context)
        {
        }

        public void Dispose()
        {
        }
    }
}