namespace BeerCollection.Components.Models
{
    using System.Collections.Generic;
    using Data;

    public class BeerCollectionModel
    {
        public List<Beer> BeerCollection { get; set; }
        public bool HasBeers { get; set; }
        public string BeerCollectionHtml { get; set; }
    }
}
