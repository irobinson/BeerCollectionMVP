namespace BeerCollection.HttpModules
{
    using System.Web;
    using Data;
    using DotNetNuke.ComponentModel;

    public class BeerCollectionModule : IHttpModule
    {
        private static volatile bool isBooted = false;
        private static readonly object padlock = new object();

        public void Init(HttpApplication context)
        {
            // Init is preferred over static constructor as it is called later (after ComponentFactory.Container is initialized)
            // but has the drawback that it may be called twice.
            // Use double-check locking to ensure the ComponentFactory is only intialized once.
            if (isBooted) return;
            lock (padlock)
            {
                if (isBooted) return;
                BootstrapComponentFactory();
                isBooted = true;
            }
        }

        public void Dispose() { }

        private static void BootstrapComponentFactory()
        {
            // Register components as 'Transient', so that a new instance is generated each time the type is requested.
            ComponentFactory.Container.RegisterComponent<IBeerRepository, BeerRepository>("BeerRepository", ComponentLifeStyleType.Transient);
        }
    }
}