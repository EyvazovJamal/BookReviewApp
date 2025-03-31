using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Crud.Models;

namespace Crud.Exceptions
{
    public class ValidationException: Exception
    {
        public readonly List<ValidationResponse> validationResponseItems ;
        

        public  ValidationException() 
        {
            validationResponseItems  =new List<ValidationResponse>();
        }
        


    }
}