using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int  Price { get; set; }
}
