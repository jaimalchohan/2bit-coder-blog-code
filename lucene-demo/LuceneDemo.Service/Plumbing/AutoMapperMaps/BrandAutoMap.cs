namespace LuceneDemo.Service.Plumbing.AutoMapperMaps
{
    using AutoMapper;

    public class BrandAutoMap
    {
        public static void Configure()
        {
            Mapper.CreateMap<LuceneDemo.Brand, LuceneDemo.Service.Contracts.Brand>()
                 .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                 .ForMember(d => d.Name, o => o.MapFrom(s => s.Name));
        }
    }
}