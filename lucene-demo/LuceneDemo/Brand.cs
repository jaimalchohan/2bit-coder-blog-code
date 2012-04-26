namespace LuceneDemo
{
    using System.Collections.Generic;

    public class Brand
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
