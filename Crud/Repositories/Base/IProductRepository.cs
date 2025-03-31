using Crud.Models;

namespace Crud.Repositories.Base;

public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts();
    Product GetProductById (int id);
    void InsertProduct(Product product);
    bool DeleteProduct(int id);
    bool UpdateProduct(int id,Product changedProduct);

}    
