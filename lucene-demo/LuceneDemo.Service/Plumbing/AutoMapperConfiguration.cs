namespace LuceneDemo.Service.Plumbing
{
    using LuceneDemo.Service.Plumbing.AutoMapperMaps;

    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            BrandAutoMap.Configure();
            CategoryAutoMap.Configure();
            ColorAutoMap.Configure();
            DepartmentAutoMap.Configure();
            ProductAutoMap.Configure();
            SizeAutoMap.Configure();
        }
    }
}