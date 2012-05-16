namespace LuceneDemo.Data.Repository
{
    using System.Collections.Generic;

    public interface IRepository<T> where T:class 
    {
        T Get(int id);
        
        IEnumerable<T> All();

        void Commit();
    }
}