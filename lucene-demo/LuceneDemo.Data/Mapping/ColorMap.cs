using FluentNHibernate.Mapping;

namespace LuceneDemo.Data.Mapping
{
    public class ColorMap : ClassMap<Color>
    {
        public ColorMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);

            HasManyToMany(x => x.Products).Table("ColorProduct");
        }
    }
}