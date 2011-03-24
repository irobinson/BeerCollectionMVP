using System;
using Antlr3.ST;

namespace BeerCollection.Components.Templating.DataRenderers
{
    public class DateRenderer :IAttributeRenderer
    {
        public string ToString(object o)
        {
            return ToString(o, "yyyy.MM.dd");
        }

        public string ToString(object o, string format)
        {
            var dt = (DateTime)o;
            return dt.ToString(format);
        }
    }
}