namespace LuceneDemo
{
    using System.Collections.Generic;

    public class Product
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual List<Category> Category { get; set; }

        public virtual double Price { get; set; }

        public virtual List<Color> Colors { get; set; }

        public virtual List<Size> Sizes { get; set; }
    }
}
