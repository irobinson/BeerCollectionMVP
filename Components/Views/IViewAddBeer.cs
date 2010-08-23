namespace BeerCollection.Components.Views
{
    using System;
    using Data;
    using DotNetNuke.Web.Mvp;

    public interface IViewAddBeer : IModuleView<Beer>
    {
        event EventHandler Submit;
    }
}