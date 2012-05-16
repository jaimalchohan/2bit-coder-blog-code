namespace LuceneDemo.Service
{
    using System.ServiceModel;

    [ServiceContract]
    public interface ISearchService
    {
        [OperationContract]
        Product GetProduct(int id);
    }
}
