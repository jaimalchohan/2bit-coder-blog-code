namespace LuceneDemo.Service.Plumbing.AutoMapperMaps
{
    using AutoMapper;

    public class CategoryAutoMap
    {
        public static void Configure()
        {
            Mapper.CreateMap<LuceneDemo.Category, LuceneDemo.Service.Contracts.Category>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name));
        }
    }
}