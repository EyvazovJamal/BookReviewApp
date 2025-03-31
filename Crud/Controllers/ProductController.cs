using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Crud.Models;
using Crud.Repositories.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

namespace Crud.Controllers;

[Route("[controller]")]
public class ProductController : Controller
{
    private readonly IProductRepository productRepository;
    public ProductController(IProductRepository productRepository)
    {
        this.productRepository=productRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost("Create")]
    public IActionResult AddProduct([FromForm]Product product)
    {
        productRepository.InsertProduct(product);

        return base.RedirectToAction("Index");
    }
    

    [Route("{id:int}")]
    [HttpPut]
    public IActionResult UpdateProduct(int id,[FromBody]Product product)
    {
        var changedProduct=productRepository.UpdateProduct(id,product);

        return base.Ok();
    }

    [Route("{id:int}")]
    [HttpGet]
    public IActionResult GetProductById(int id)
    {
        var foundProduct=productRepository.GetProductById(id);

        if (foundProduct==null)
        {
            return base.View(viewName:"ProductInfo",model:null);
        }
        return base.View(viewName:"ProductInfo",model:foundProduct);

    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteProduct(int id){
        productRepository.DeleteProduct(id);
        return Ok();
    }
    


} 