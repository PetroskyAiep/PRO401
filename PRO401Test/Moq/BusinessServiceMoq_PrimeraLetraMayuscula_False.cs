using PRO401.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRO401Test.Moq
{
    internal class BusinessServiceMoq_PrimeraLetraMayuscula_False : IBusinessService
    {
        public bool PrimeraLetraMayuscula(string? palabra)
        {
            return false;
        }
    }
}
