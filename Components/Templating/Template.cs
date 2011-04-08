namespace BeerCollection.Components.Templating
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using Antlr3.ST;
    using DataRenderers;

    public class TemplateController : ITemplateController
    {
        public string DefaultGroupName = "Default";
        public string DefaultTemplatePath = HttpContext.Current.Server.MapPath("/DesktopModules/BeerCollection/Templates/Default");

        public string RenderTemplate(string templateName, IEnumerable<KeyValuePair<string, object>> templateData)
        {
            return RenderTemplate(DefaultGroupName, DefaultTemplatePath, templateName, templateData);
        }

        public string RenderTemplate(string groupName, string groupPath, string templateName, IEnumerable<KeyValuePair<string, object>> templateData)
        {
            var templateGroup = new StringTemplateGroup(groupName, groupPath);
            var template = templateGroup.GetInstanceOf(templateName);

            foreach(var d in templateData)
            {
                template.SetAttribute(d.Key, d.Value);
            }

            template.RegisterRenderer(typeof(DateTime), new DateRenderer());
            template.RegisterRenderer(typeof(String), new BasicFormatRenderer());

            return template.ToString();
        }

        public string GetTemplate(string templateName)
        {
            return GetTemplate(DefaultGroupName, DefaultTemplatePath, templateName);
        }

        public string GetTemplate(string groupName, string groupPath, string templateName)
        {
            var templateGroup = new StringTemplateGroup(groupName, groupPath);
            return templateGroup.GetInstanceOf(templateName).Template;
        }
    }
}