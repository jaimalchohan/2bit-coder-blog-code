using FluentNHibernate.Mapping;

namespace LuceneDemo.Data.Mapping
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);

            References(x => x.Department);

            HasManyToMany(x => x.Products);
        }
    }
}