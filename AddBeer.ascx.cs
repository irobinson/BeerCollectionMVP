namespace BeerCollection
{
    using System;
    using Components.Presenters;
    using Components.Views;
    using Data;
    using DotNetNuke.Web.Mvp;
    using WebFormsMvp;

    [PresenterBinding(typeof(AddBeerPresenter))]
    public partial class AddBeer : ModuleView<Beer>, IViewAddBeer
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SubmitButton.Click += SubmitButtonClick;
            DotNetNuke.Framework.jQuery.RequestRegistration();
        }

        public event EventHandler Submit;

        private void SubmitButtonClick(object sender, EventArgs e)
        {
            decimal abv;
            Decimal.TryParse(BeerAbvTextBox.Text, out abv);
            DateTime drinkBy;
            DateTime.TryParse(DrinkByDateTextBox.Text, out drinkBy);

            Model = new Beer()
                        {
                            AlcoholPercentageByVolume = abv,
                            Description = BeerDescriptionTextBox.Text,
                            DrinkBy = drinkBy,
                            IsConsumed = ConsumedCheckBox.Checked,
                            Name = BeerNameTextBox.Text
                        };

            if (Submit != null)
            {
                Submit(this, e);
            }
        }
    }
}