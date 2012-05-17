namespace LuceneDemo.Service.Plumbing
{
    using AutoMapper;

    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<LuceneDemo.Product, LuceneDemo.Service.Contracts.Product>();

        }
    }
}