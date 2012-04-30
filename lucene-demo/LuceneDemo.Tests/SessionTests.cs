namespace LuceneDemo.Tests
{
    using NUnit.Framework;
    using LuceneDemo.Data;

    [TestFixture]
    public class SessionTests
    {
        [Test]
        public void can_open_session()
        {
            ProductDbSession.Configure();
            var session = ProductDbSession.Open();
            var brand = session.Get<Brand>(1);

        }
    }
}
