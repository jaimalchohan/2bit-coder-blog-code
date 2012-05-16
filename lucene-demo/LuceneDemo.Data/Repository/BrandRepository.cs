namespace LuceneDemo.Data.Repository
{
    using NHibernate;

    public class BrandRepository : Repository<Brand>
    {
        public BrandRepository(ISession session)
            : base(session)
        {

        }
    }
}
