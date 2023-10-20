using PRO401.Entities;
using PRO401.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRO401Test.Moq
{
    internal class AutoServiceMoq : IAutoService
    {
        public Task Insert(Auto entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PatenteExiste(string patenteId)
        {
            throw new NotImplementedException();
        }

        public bool PrimeraLetraMayuscula(string color)
        {
            throw new NotImplementedException();
        }
    }
}
