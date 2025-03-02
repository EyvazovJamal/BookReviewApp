using Crud.Models;
using Crud.Repositories.Base;

namespace Crud.Repositories;

public class ProductRamRepository : IProductRepository
{
    private List<Product> Products=new List<Product>();
    public bool DeleteProduct(int id)
    {
        var productToDelete=this.GetProductById(id);

        if (productToDelete==null)
        {
            return false;
        }
        Products.Remove(productToDelete);
        return true;
        
    }

    public IEnumerable<Product> GetAllProducts()
    {
       return Products;
    }

    public Product GetProductById(int id)
    {
        return Products.FirstOrDefault(u=>u.Id==id);
    }

    public void InsertProduct(Product product)
    {
        Products.Add(product);
    }

    public bool UpdateProduct(int id, Product changedProduct)
    {
        var foundProduct=GetProductById(id);

        if (foundProduct==null)
        {
            return false;
        }
        foundProduct.Name=changedProduct.Name;
        foundProduct.Price=changedProduct.Price;
        foundProduct.Count=changedProduct.Count;
        return true;
    }
}
