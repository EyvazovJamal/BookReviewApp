using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace App.Services.Base;

public interface ITestService
{
   void NeverCrashes();
   void DontPutNull(string? text);

   void FindBook();
}
