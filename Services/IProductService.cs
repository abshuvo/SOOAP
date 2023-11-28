using SoapTrail.Models;
using System.ServiceModel;

namespace SoapTrail.Services
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        List<Product> GetProducts();
        [OperationContract]
        Product GetProductById(int id);

        [OperationContract]
        void AddProduct(Product product);

        [OperationContract]
        void UpdateProduct(Product product);

        [OperationContract]
        void DeleteProduct(int id);
    }
}
