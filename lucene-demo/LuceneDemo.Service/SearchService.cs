namespace LuceneDemo.Service
{
    using LuceneDemo.Data.Repository;
    using LuceneDemo.Service.Contracts;
    using AutoMapper;

    public class SearchService : ISearchService
    {
        private ProductRepository _productRepository;

        public SearchService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProduct(int id)
        {
            var pd = _productRepository.Get(id);
            var pc = Mapper.Map<LuceneDemo.Product, LuceneDemo.Service.Contracts.Product>(pd);
            return pc;
        }
    }
}