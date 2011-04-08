namespace BeerCollection.Components.Templating
{
    using System.Collections.Generic;

    public interface ITemplateController
    {
        string RenderTemplate(string templateName, IEnumerable<KeyValuePair<string, object>> templateData);
        string RenderTemplate(string groupName, string groupPath, string templateName, IEnumerable<KeyValuePair<string, object>> templateData);
        string GetTemplate(string templateName);
        string GetTemplate(string groupName, string groupPath, string templateName);
    }
}