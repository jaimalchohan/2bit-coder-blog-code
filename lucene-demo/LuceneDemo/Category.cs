namespace LuceneDemo
{
    using System.Collections.Generic;

    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Department Department { get; set; }

        public List<Product> Products { get; set; }
    }
}
