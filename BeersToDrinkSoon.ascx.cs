namespace BeerCollection
{
    using Components.Models;
    using Components.Presenters;
    using DotNetNuke.Web.Mvp;
    using WebFormsMvp;

    [PresenterBinding(typeof(BeersToDrinkSoonPresenter))]
    public partial class ViewBeersToDrinkSoon : ModuleView<BeerCollectionModel>, IViewBeersToDrinkSoon
    {
    }
}