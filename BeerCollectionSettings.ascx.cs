namespace BeerCollection
{
    using System.IO;
    using Components.Templating;
    using DotNetNuke.Entities.Modules;

    public partial class BeerCollectionSettings : ModuleSettingsBase
    {
        public override void LoadSettings()
        {
            base.LoadSettings();
            this.TemplateTextBox.Text = Template.GetTemplate("BeerCollection");
        }

        public override void UpdateSettings()
        {
            base.UpdateSettings();
            File.WriteAllText(Template.DefaultTemplatePath + "\\BeerCollection.st", this.TemplateTextBox.Text);
        }
    }
}