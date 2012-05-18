namespace LuceneDemo.Service.Plumbing.AutoMapperMaps
{
    using AutoMapper;

    public class ProductAutoMap
    {
        public static void Configure()
        {
            Mapper.CreateMap<LuceneDemo.Product, LuceneDemo.Service.Contracts.Product>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
                .ForMember(d => d.Price, o => o.MapFrom(s => s.Price));
        }
    }
}