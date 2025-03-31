using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud.Models;

namespace Crud.Repositories;

public class ProductRepository
{
    private List<Product> Products;

    public ProductRepository(){
        Products=new List<Product>();    
    }

    public void CreateProduct(Product user) {
        Products.Add(user);
    }
    public Product? GetProductById(int id) {
        return Products.FirstOrDefault(u => u.Id == id);
    }
    

}
