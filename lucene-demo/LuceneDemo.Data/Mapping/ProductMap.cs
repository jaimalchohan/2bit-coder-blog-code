using FluentNHibernate.Mapping;

namespace LuceneDemo.Data.Mapping
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);

            Map(x => x.Description);

            Map(x => x.Price);

            References(x => x.Brand);

            HasManyToMany(x => x.Colors);

            HasManyToMany(x => x.Categories);

            HasManyToMany(x => x.Sizes);
        }
    }
}