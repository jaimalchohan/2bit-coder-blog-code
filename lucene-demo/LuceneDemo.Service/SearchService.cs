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
            var product = _productRepository.Get(id);
            return Mapper.Map<LuceneDemo.Product, Product>(product);
        }
    }
}