using BeerCollection.Components.Templating;

namespace BeerCollection.Components.Presenters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Data;
    using DotNetNuke.Web.Mvp;
    using Models;

    public class BeersToDrinkSoonPresenter : ModulePresenter<IViewBeersToDrinkSoon, BeerCollectionModel>
    {    
        private readonly IBeerRepository beerRepository;
        private readonly ITemplateController templateController;
        private readonly IUserProvider userProvider;

        public BeersToDrinkSoonPresenter(IViewBeersToDrinkSoon view) : this(view, Util.GetRepository(), Util.GetTemplateController(), Util.GetUserProvider())
        {
        }

        public BeersToDrinkSoonPresenter(IViewBeersToDrinkSoon view, IBeerRepository repository, ITemplateController template, IUserProvider user) : base(view)
        {
            beerRepository = repository;
            templateController = template;
            userProvider = user;
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
                               {"user", userProvider.GetUser(this.PortalId, this.UserId)}
                           };
            return templateController.RenderTemplate("BeersToDrinkSoon", data);
        }
    }
}