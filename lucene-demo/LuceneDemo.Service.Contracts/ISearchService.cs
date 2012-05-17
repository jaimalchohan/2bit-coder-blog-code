namespace LuceneDemo.Service.Contracts
{
    using System.ServiceModel;

    [ServiceContract]
    public interface ISearchService
    {
        [OperationContract]
        Product GetProduct(int id);
    }
}
