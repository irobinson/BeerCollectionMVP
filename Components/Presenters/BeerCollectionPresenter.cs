﻿namespace BeerCollection.Components.Presenters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using DotNetNuke.ComponentModel;
    using DotNetNuke.Web.Mvp;
    using Models;

    public class BeerCollectionPresenter : ModulePresenter<IViewBeerCollection, BeerCollectionModel>
    {
        private IBeerRepository beerRepository;

        public BeerCollectionPresenter(IViewBeerCollection view) : this(view, ComponentFactory.GetComponent<IBeerRepository>())
        {
        }

        public BeerCollectionPresenter (IViewBeerCollection view, IBeerRepository repository) : base(view)
        {
            beerRepository = repository;
            this.View.Load += ViewLoad;
        }

        void ViewLoad(Object sender, EventArgs eventArgs)
        {
            List<Beer> beers = beerRepository.GetBeers().ToList();
            View.Model.HasBeers = beers.Count > 0;
            View.Model.BeerCollection = beers;
            Messages.Publish(beers);
            Messages.Subscribe<Beer>(b => beers.Add(b));
        }
    }
}