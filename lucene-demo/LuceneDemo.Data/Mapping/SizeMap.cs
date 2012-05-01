using FluentNHibernate.Mapping;

namespace LuceneDemo.Data.Mapping
{
    public class SizeMap : ClassMap<Size>
    {
        public SizeMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);

            HasManyToMany(x => x.Products).Table("SizeProduct");
        }
    }
}