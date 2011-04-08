namespace BeerCollection.Components.Presenters
{
    using System;
    using Common;
    using Data;
    using DotNetNuke.Web.Mvp;
    using Views;
    
    public class AddBeerPresenter : ModulePresenter<IViewAddBeer, Beer>
    {
        private readonly IBeerRepository beerRepository;

        public AddBeerPresenter(IViewAddBeer view) : this(view, Util.GetRepository())
        {
        }

        public AddBeerPresenter(IViewAddBeer view, IBeerRepository repository) : base(view)
        {
            beerRepository = repository;
            View.Submit += Submit;
        }

        public void Submit(object sender, EventArgs e)
        {
            beerRepository.AddBeer(View.Model);
            beerRepository.SubmitChanges();
            Messages.Publish(View.Model);
        }
    }
}