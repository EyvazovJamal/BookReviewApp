using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Crud.Controllers.Services.Base;
using Crud.Controllers.Services.Base.Repositories.Base;
using Crud.Models;



namespace Crud.Services;

public class ProductService:IProductService
{
    private readonly IProductRepository repository;

    public ProductService(IProductRepository repository)
    {
        this.repository=repository;

    }
    public void Add(Product product){
        
       var validationException = new ValidationException();

        if(string.IsNullOrWhiteSpace(product.Name)) {
            
        } 
    }


}

