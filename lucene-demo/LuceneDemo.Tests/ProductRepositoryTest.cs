namespace LuceneDemo.Tests
{
    using NUnit.Framework;
    using LuceneDemo.Data.Repository;
    using LuceneDemo.Data;

    [TestFixture]
    public class ProductRepositoryTest
    {
        private ProductDbSessionFactory _sessionFactory;

        [SetUp]
        public void setup()
        {
            _sessionFactory = ProductDbSessionFactory.Configure();
        }

        [Test]
        public void can_fetch_product()
        {
            Product product = null;

            using(var session = _sessionFactory.Open())
            {
                var repo = new ProductRepository(session);
                product = repo.Get(1);
            }

            Assert.NotNull(product);

            Assert.NotNull(product.Description);
            Assert.NotNull(product.Name);
            Assert.NotNull(product.Price);

            Assert.NotNull(product.Brand);
            Assert.NotNull(product.Categories);
            Assert.NotNull(product.Colors);
            Assert.NotNull(product.Sizes);
        }
    }
}
