using BeerCollection.Components.Templating;
using DotNetNuke.Entities.Users;

namespace BeerCollection.Components.Presenters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using DotNetNuke.ComponentModel;
    using DotNetNuke.Web.Mvp;
    using Models;

    public class BeersToDrinkSoonPresenter : ModulePresenter<IViewBeersToDrinkSoon, BeerCollectionModel>
    {    
        private readonly IBeerRepository beerRepository;

        public BeersToDrinkSoonPresenter(IViewBeersToDrinkSoon view) : this(view, ComponentFactory.GetComponent<IBeerRepository>())
        {
        }

        public BeersToDrinkSoonPresenter (IViewBeersToDrinkSoon view, IBeerRepository repository) : base(view)
        {
            beerRepository = repository;
            this.View.Load += ViewLoad;
        }

        void ViewLoad(Object sender, EventArgs eventArgs)
        {
            Messages.Subscribe<List<Beer>>(SetModel, () => SetModel(beerRepository.GetBeers().ToList()));
        }

        private void SetModel(List<Beer> beers)
        {
            View.Model.BeerCollection = beers.OrderBy(b => b.DrinkBy).Take(3).Where(b => !b.IsConsumed).ToList();
            View.Model.HasBeers = View.Model.BeerCollection.Count > 0;
            View.Model.BeerCollectionHtml = this.GetTemplate();
        }

        private string GetTemplate()
        {
            var data = new Dictionary<string, object>
                           {
                               {"beers", View.Model.BeerCollection},
                               {"user", new UserController().GetUser(this.PortalId, this.UserId)}
                           };
            return Template.RenderTemplate("BeersToDrinkSoon", data);
        }
    }
}