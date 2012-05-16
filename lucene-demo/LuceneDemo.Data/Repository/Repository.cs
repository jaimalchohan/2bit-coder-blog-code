namespace LuceneDemo.Data.Repository
{
    using System.Collections.Generic;
    using NHibernate;

    public abstract class Repository<T> : IRepository<T>
    {
        private readonly ISession _session;

        protected Repository(ISession session)
        {
            _session = session;
        }

        public T Get(int id)
        {
            return _session.Get<T>(id);
        }

        public IEnumerable<T> All()
        {
            return _session.QueryOver<T>().List();
        }

        public void Commit()
        {
            _session.Flush();
        }
    }
}