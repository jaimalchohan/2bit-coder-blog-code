namespace LuceneDemo.Service.Plumbing.AutoMapperMaps
{
    using AutoMapper;

    public class DepartmentAutoMap
    {
        public static void Configure()
        {
            Mapper.CreateMap<LuceneDemo.Department, LuceneDemo.Service.Contracts.Department>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name));
        }
    }
}