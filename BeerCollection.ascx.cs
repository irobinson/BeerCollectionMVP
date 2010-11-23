namespace BeerCollection
{
    using Components.Models;
    using Components.Presenters;
    using DotNetNuke.Web.Mvp;
    using WebFormsMvp;
    using DotNetNuke.Entities.Modules.Actions;
    using DotNetNuke.Services.Localization;
    using DotNetNuke.Entities.Modules;

    [PresenterBinding(typeof(BeerCollectionPresenter))]
    public partial class ViewBeerCollection : ModuleView<BeerCollectionModel>, IViewBeerCollection, IActionable
    {
        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection();


                ModuleActionCollection Actions = new ModuleActionCollection();
                Actions.Add(ModuleContext.GetNextActionID(), "Add Beer",
                   ModuleActionType.AddContent, "", "add.gif", ModuleContext.EditUrl(), false, DotNetNuke.Security.SecurityAccessLevel.Edit,
                    true, false);
                return Actions;
            }
        }
    }
}