using Antlr3.ST;

namespace BeerCollection.Components.Templating.DataRenderers
{
    public class BasicFormatRenderer : IAttributeRenderer
    {
        public string ToString(object o)
        {
            return o.ToString();
        }

        public string ToString(object o, string formatName)
        {
            if(formatName == "toUpper")
            {
                return o.ToString().ToUpperInvariant();
            }

            if (formatName == "toLower")
            {
                return o.ToString().ToLowerInvariant();
            }

            return o.ToString();
        }
    }
}