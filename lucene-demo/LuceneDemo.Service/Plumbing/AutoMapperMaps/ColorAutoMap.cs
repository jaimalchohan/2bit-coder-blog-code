namespace LuceneDemo.Service.Plumbing.AutoMapperMaps
{
    using AutoMapper;

    public class ColorAutoMap
    {
        public static void Configure()
        {
            Mapper.CreateMap<LuceneDemo.Color, LuceneDemo.Service.Contracts.Color>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name));
        }
    }
}