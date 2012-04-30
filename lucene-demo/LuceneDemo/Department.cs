namespace LuceneDemo
{
    using System.Collections.Generic;

    public class Department
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual IList<Category> Categories { get; set; }
    }
}
