using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud.Models;

namespace Crud.Controllers.Services.Base.Repositories.Base
{
    public interface IProductRepository
    {
        Product GetProductById (int id);
        void CreateProduct(Product product);
    }
}