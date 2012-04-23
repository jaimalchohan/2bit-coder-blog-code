namespace LuceneDemo
{
    using System.Collections.Generic;

    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Brand Brand { get; set; }

        public List<Category> Category { get; set; }

        public double Price { get; set; }

        public List<Color> Colors { get; set; }

        public List<Size> Sizes { get; set; }
    }
}
