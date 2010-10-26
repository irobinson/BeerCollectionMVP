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
        private IBeerRepository beerRepository;

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
            Messages.Subscribe<List<Beer>>(beers => SetModel(beers), () => SetModel(beerRepository.GetBeers().ToList()));
        }

        private void SetModel(List<Beer> beers)
        {
            View.Model.BeerCollection = beers.OrderBy(b => b.DrinkBy).Take(3).Where(b => !b.IsConsumed).ToList();
            View.Model.HasBeers = beers.Count > 0;
        }
    }
}