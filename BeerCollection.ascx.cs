namespace BeerCollection
{
    using Components.Models;
    using Components.Presenters;
    using DotNetNuke.Web.Mvp;
    using WebFormsMvp;

    [PresenterBinding(typeof(BeerCollectionPresenter))]
    public partial class ViewBeerCollection : ModuleView<BeerCollectionModel>, IViewBeerCollection
    {
    }
}