using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud.Models;

namespace Crud.Controllers.Services.Base
{
    public interface IProductService
    {
        void Add(Product product);
    }
}
