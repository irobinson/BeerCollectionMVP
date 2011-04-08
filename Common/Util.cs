namespace BeerCollection.Common
{
    using System;
    using Components.Templating;
    using Data;
    using DotNetNuke.ComponentModel;
    
    public class Util
    {
        public static IBeerRepository GetRepository()
        {
            var ctl = ComponentFactory.GetComponent<IBeerRepository>();

            if (ctl == null)
            {
                ctl = new BeerRepository();
                ComponentFactory.RegisterComponentInstance<IBeerRepository>(ctl);
            }
            return ctl;
        }

        public static ITemplateController GetTemplateController()
        {
            var ctl = ComponentFactory.GetComponent<ITemplateController>();

            if (ctl == null)
            {
                ctl = new TemplateController();
                ComponentFactory.RegisterComponentInstance<ITemplateController>(ctl);
            }
            return ctl;
        }

        public static IUserProvider GetUserProvider()
        {
            return new UserProvider();
        }
    }
}