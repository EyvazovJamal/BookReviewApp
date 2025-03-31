using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Models;

public class Product
{
    private static int counter = 1;
    public required int  Id { get; set; }
    public required string Name { get; set; }
    public int Price { get; set; }
    public int Count  { get; set; }

    public Product()
    {
        Id=counter++;
    }
}
