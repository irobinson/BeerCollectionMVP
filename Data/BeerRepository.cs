namespace BeerCollection
{
    using System.Linq;
    using Data;

    public class BeerRepository : IBeerRepository
    {
        public BeerRepository() : this(new DbDataContext())
        {
        }

        protected BeerRepository(DbDataContext context)
        {
            Context = context;
        }

        protected DbDataContext Context { get; set; }

        public void AddBeer(Beer beer)
        {
            this.Context.Beers.InsertOnSubmit(beer);
        }

        public Beer GetBeer(int id)
        {
            return this.Context.Beers.SingleOrDefault(beer => beer.BeerId == id);
        }

        public IQueryable<Beer> GetBeers()
        {
            return this.Context.Beers;
        }

        public void SubmitChanges()
        {
            this.Context.SubmitChanges();
        }
    }
}