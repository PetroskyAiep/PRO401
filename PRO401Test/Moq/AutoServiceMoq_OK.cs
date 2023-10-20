using PRO401.Entities;
using PRO401.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRO401Test.Moq
{
    internal class AutoServiceMoq_OK : IAutoService
    {
        public Task Insert(Auto entity)
        {
            return Task.CompletedTask;
        }

        public async Task<bool> PatenteExiste(string patenteId)
        {
            return false;
        }

        public bool PrimeraLetraMayuscula(string color)
        {
            return true;
        }
    }
}
