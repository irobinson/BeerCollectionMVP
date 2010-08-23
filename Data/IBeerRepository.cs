namespace BeerCollection.Data
{
    using System.Linq;

    public interface IBeerRepository
    {
        void AddBeer(Beer beer);
        Beer GetBeer(int id);
        IQueryable<Beer> GetBeers();
        void SubmitChanges();
    }
}