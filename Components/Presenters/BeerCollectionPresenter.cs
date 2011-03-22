using System.IO;
using System.Text;
using Antlr3.ST;
using DotNetNuke.Services.Localization;

namespace BeerCollection.Components.Presenters
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
        private readonly IBeerRepository beerRepository;

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
            GetBeers();
            GetBeerCollectionHtml();
        }

        private void GetBeerCollectionHtml()
        {
            var template = new StringTemplate(Localization.GetString("BeerCollectionTemplate", LocalResourceFile));
            template.SetAttribute("beer", View.Model.BeerCollection);
            View.Model.BeerCollectionHtml = template.ToString();
        }

        private void GetBeers()
        {
            List<Beer> beers = beerRepository.GetBeers().ToList();
            View.Model.HasBeers = beers.Count > 0;
            View.Model.BeerCollection = beers;
            Messages.Publish(beers);
            Messages.Subscribe<Beer>(beers.Add);
        }
    }
}