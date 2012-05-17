namespace LuceneDemo.Data.Repository
{
    using NHibernate;

    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(ISession session)
            : base(session)
        {

        }

        public override Product Get(int id)
        {
            return base.Get(id);
            //NHibernateUtil.Initialize(p.Brand);

        }
    }
}
