using FluentNHibernate.Mapping;

namespace LuceneDemo.Data.Mapping
{
    public class DepartmentMap : ClassMap<Department>
    {
        public DepartmentMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);

            HasMany(x => x.Categories);
        }
    }
}