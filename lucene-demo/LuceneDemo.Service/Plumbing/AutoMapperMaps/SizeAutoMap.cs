namespace LuceneDemo.Service.Plumbing.AutoMapperMaps
{
    using AutoMapper;

    public class SizeAutoMap
    {
        public static void Configure()
        {
            Mapper.CreateMap<LuceneDemo.Size, LuceneDemo.Service.Contracts.Size>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name));
        }
    }
}