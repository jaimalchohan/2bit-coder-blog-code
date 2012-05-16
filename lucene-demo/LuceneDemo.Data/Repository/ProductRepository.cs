namespace LuceneDemo.Data.Repository
{
    using NHibernate;

    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(ISession session)
            : base(session)
        {

        }
    }
}
