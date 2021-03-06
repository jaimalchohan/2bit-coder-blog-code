﻿namespace LuceneDemo.Data.Mapping
{
    using FluentNHibernate.Mapping;

    public class BrandMap: ClassMap<Brand>
    {
        public BrandMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);

            HasMany(x => x.Products);
        }
    }
}
