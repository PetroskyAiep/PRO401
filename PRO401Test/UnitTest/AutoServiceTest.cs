using Microsoft.EntityFrameworkCore;
using PRO401.Entities;
using PRO401.Services;
using PRO401Test.Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRO401Test.UnitTest
{
    [TestClass]
    public class AutoServiceTest : BaseTest
    {
        [TestMethod]
        public async Task PatenteExiste_ReturnFalse()
        {
            var dbName = Guid.NewGuid().ToString();
            var context1 = BuildDatabaseContext(dbName);
            var bussinesMoq = new BusinessServiceMoq();
            var service = new AutoService(context1, bussinesMoq);
            var entity = new Auto { Patente = "NOE123", MarcaId = 1, ModeloId = 1, CarroceriaId = 25 };

            var result = await service.PatenteExiste(entity.Patente);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task PatenteExiste_ReturnTrue()
        {
            var dbName = Guid.NewGuid().ToString();
            var context1 = BuildDatabaseContext(dbName);
            var bussinesMoq = new BusinessServiceMoq();
            var service = new AutoService(context1, bussinesMoq);
            var entity = new Auto { Patente = "SIE223", MarcaId = 1, ModeloId = 1, CarroceriaId = 26 };
            context1.Autos.Add(new Auto { Patente = "SIE223", MarcaId = 1, ModeloId = 2, CarroceriaId = 28 });
            await context1.SaveChangesAsync();

            var result = await service.PatenteExiste(entity.Patente);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PrimeraLetraMayuscula_ReturnTrue()
        {
            var dbName = Guid.NewGuid().ToString();
            var context1 = BuildDatabaseContext(dbName);
            var bussinesMoq = new BusinessServiceMoq_PrimeraLetraMayuscula_True();
            var service = new AutoService(context1, bussinesMoq);
            var color = "Rojo";

            var reult = service.PrimeraLetraMayuscula(color);

            Assert.IsTrue(reult);
        }

        [TestMethod]
        public void PrimeraLetraMayuscula_ReturnFalse()
        {
            var dbName = Guid.NewGuid().ToString();
            var context1 = BuildDatabaseContext(dbName);
            var bussinesMoq = new BusinessServiceMoq_PrimeraLetraMayuscula_False();
            var service = new AutoService(context1, bussinesMoq);
            var color = "rojo";

            var reult = service.PrimeraLetraMayuscula(color);

            Assert.IsFalse(reult);
        }

        [TestMethod]
        public async Task Insert()
        {
            var dbName = Guid.NewGuid().ToString();
            var context1 = BuildDatabaseContext(dbName);
            var entity = new Auto { Patente = "NEW223", MarcaId = 1, ModeloId = 1, CarroceriaId = 26 };
            var bussinesMoq = new BusinessServiceMoq();
            var service = new AutoService(context1, bussinesMoq);


            await service.Insert(entity);
            var result = await context1.Autos.CountAsync();

            Assert.AreEqual(1, result);
        }
    }
}
