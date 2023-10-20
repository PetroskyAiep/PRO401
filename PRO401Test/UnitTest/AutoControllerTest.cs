using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PRO401.Controllers;
using PRO401.DTO.AutoDTO;
using PRO401.Entities;
using PRO401Test.Moq;


namespace PRO401Test.UnitTest
{
    [TestClass]
    public class AutoControllerTest : BaseTest
    {
        [TestMethod]
        public void Get()
        {
            var mapper = new MapperMoq();
            var autoService = new AutoServiceMoq();
            var store = new Mock<IUserStore<Usuario>>();
            var userManager = new UserManager<Usuario>(store.Object, null, null, null, null, null, null, null, null);
            var controller = new AutoController(autoService, mapper, userManager);

            var result = controller.Get();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Post_ReturnOk()
        {
            var mapper = BuildMapper();
            var autoService = new AutoServiceMoq_OK();
            //var autoService = new Mock<IAutoService>();
            //.Setup()
            var store = new Mock<IUserStore<Usuario>>();
            var userManager = new UserManager<Usuario>(store.Object, null, null, null, null, null, null, null, null);
            var controller = new AutoController(autoService, mapper, userManager);
            var autoCreateDTO = new AutoCreateDTO { Patente = "NOE678", MarcaId = 1, ModeloId = 1, CarroceriaId = 25 };

            var result = await controller.Post(autoCreateDTO);


            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Post_ReturnBadRequest()
        {
            var mapper = BuildMapper();
            var autoService = new AutoServiceMoq_BadRequest();
            var store = new Mock<IUserStore<Usuario>>();
            var userManager = new UserManager<Usuario>(store.Object, null, null, null, null, null, null, null, null);
            var controller = new AutoController(autoService, mapper, userManager);
            var autoCreateDTO = new AutoCreateDTO { Patente = "NOE678", MarcaId = 1, ModeloId = 1, CarroceriaId = 25 };

            var result = await controller.Post(autoCreateDTO);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

        }

    }
}
