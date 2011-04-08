namespace BeerCollection
{
    using System;
    using System.IO;
    using Components.Templating;
    using DotNetNuke.Entities.Modules;

    public partial class BeersToDrinkSoonSettings : ModuleSettingsBase
    {
        public override void LoadSettings()
        {
            base.LoadSettings();
            this.TemplateTextBox.Text = new TemplateController().GetTemplate("BeersToDrinkSoon");
        }

        public override void UpdateSettings()
        {
            base.UpdateSettings();
            File.WriteAllText(new TemplateController().DefaultTemplatePath + "\\BeersToDrinkSoon.st", this.TemplateTextBox.Text);
        }
    }
}