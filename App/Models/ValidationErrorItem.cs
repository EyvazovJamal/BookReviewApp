using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models;

public class ValidationErrorItem
{
    public string? Message { get; set; }
    public string? Property { get; set; }
}
