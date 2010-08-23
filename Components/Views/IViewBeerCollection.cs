using System;
using System.Collections.Generic;
using System.Web;
using BeerCollection.Components.Models;
using BeerCollection.Data;
using DotNetNuke;
using DotNetNuke.Web.Mvp;

namespace BeerCollection
{
    using Components.Models;

    public interface IViewBeerCollection : IModuleView<BeerCollectionModel>
    {
    }
}