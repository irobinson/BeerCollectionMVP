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
            SubmitButton.Click += SubmitButton_Click;
        }

        public event EventHandler Submit;

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            decimal abv;
            Decimal.TryParse(BeerAbvTextBox.Text, out abv);

            Model = new Beer()
                        {
                            AlcoholPercentageByVolume = abv,
                            Description = BeerDescriptionTextBox.Text,
                            DrinkBy = DateTime.Now.AddMonths(6),
                            IsConsumed = false,
                            Name = BeerNameTextBox.Text
                        };

            if (Submit != null)
            {
                Submit(this, e);
            }
        }
    }
}