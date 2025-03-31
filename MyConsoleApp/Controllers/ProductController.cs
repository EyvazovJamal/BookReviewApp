using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyConsoleApp.Models;

namespace MyConsoleApp.Controllers;

[Route("/[controller]")]
public class ProductController : Controller
{
    [HttpGet]
    public Product GetProduct(int id){
        return new Product{
            Id=id,
            Name="Apple",
            Price =2
        };
    }
}
