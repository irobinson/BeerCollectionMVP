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
    
    public class BeerCollectionPresenter : ModulePresenter<IViewBeerCollection, BeerCollectionModel>
    {
        private readonly IBeerRepository beerRepository;
        private readonly ITemplateController templateController;
        private readonly IUserProvider userProvider;
        
        public BeerCollectionPresenter(IViewBeerCollection view) : this(view, Util.GetRepository(), Util.GetTemplateController(), Util.GetUserProvider())
        {
        }

        public BeerCollectionPresenter (IViewBeerCollection view, IBeerRepository repository, ITemplateController template, IUserProvider user) : base(view)
        {
            beerRepository = repository;
            templateController = template;
            userProvider = user;
            this.View.Load += ViewLoad;
        }

        void ViewLoad(Object sender, EventArgs eventArgs)
        {
            List<Beer> beers = beerRepository.GetBeers().ToList();
            View.Model.HasBeers = beers.Count > 0;
            View.Model.BeerCollection = beers;

            Messages.Publish(beers);
            Messages.Subscribe<Beer>(AddBeer);

            View.Model.BeerCollectionHtml = this.GetTemplate();
        }

        private void AddBeer(Beer beer)
        {
            View.Model.BeerCollection.Add(beer);
            View.Model.BeerCollectionHtml = this.GetTemplate();
        }
        
        private string GetTemplate()
        {
            var data = new Dictionary<string, object>
                           {
                               {"beer", View.Model.BeerCollection},
                               {"user", userProvider.GetUser(this.PortalId, this.UserId)}
                           };
            return templateController.RenderTemplate("BeerCollection", data);
        }
    }
}