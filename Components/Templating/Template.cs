namespace BeerCollection.Components.Templating
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using Antlr3.ST;
    using DataRenderers;

    public static class Template
    {
        public static string DefaultGroupName = "Default";
        public static string DefaultTemplatePath = HttpContext.Current.Server.MapPath("/DesktopModules/BeerCollection/Templates/Default");

        public static string RenderTemplate(string templateName, IEnumerable<KeyValuePair<string, object>> templateData)
        {
            return RenderTemplate(DefaultGroupName, DefaultTemplatePath, templateName, templateData);
        }

        public static string RenderTemplate(string groupName, string groupPath, string templateName, IEnumerable<KeyValuePair<string, object>> templateData)
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

        public static string GetTemplate(string templateName)
        {
            return GetTemplate(DefaultGroupName, DefaultTemplatePath, templateName);
        }

        public static string GetTemplate(string groupName, string groupPath, string templateName)
        {
            var templateGroup = new StringTemplateGroup(groupName, groupPath);
            return templateGroup.GetInstanceOf(templateName).Template;
        }
    }
}