using PRO401.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRO401Test.UnitTest
{
    [TestClass]
    public class BussinesServiceTest
    {
        [TestMethod]
        public void PrimeraLetraMayuscula_ReturnTrue()
        {
            var service = new BusinessService();
            var palabra = "Cafe";

            var result = service.PrimeraLetraMayuscula(palabra);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PrimeraLetraMayuscula_ReturnFalse()
        {
            var service = new BusinessService();
            var palabra = "cafe";

            var result = service.PrimeraLetraMayuscula(palabra);

            Assert.IsFalse(result);
        }
    }
}
