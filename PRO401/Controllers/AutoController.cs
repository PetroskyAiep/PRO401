using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PRO401.DTO.AutoDTO;
using PRO401.Entities;
using PRO401.Services;

namespace PRO401.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoController : ControllerBase
    {
        private readonly IAutoService _autoService;
        private readonly IMapper _mapper;
        private readonly UserManager<Usuario> _userManager;

        public AutoController(IAutoService autoService, IMapper mapper, UserManager<Usuario> userManager)
        {
            _autoService = autoService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Get()
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim != null ? emailClaim.Value : null;
            if (email != null)
            {
                var user = await _userManager.FindByEmailAsync(email);
            }
            return Ok("HTTP GET");
        }

        [HttpPost]
        public async Task<ActionResult> Post(AutoCreateDTO model)
        {
            //verificar si patente existe en DB
            var patenteExiste = await _autoService.PatenteExiste(model.Patente);

            //Si existe retornar un error
            if (patenteExiste)
            {
                return BadRequest("La patente ya fue ingresada");
            }

            //Patente debe tener la primera letra mayuscula
            if (!_autoService.PrimeraLetraMayuscula(model.Color))
            {
                return BadRequest("La primera letra debe ser MAYUSCULA");
            }

            //insertar registro en la base de datos
            var entity = _mapper.Map<Auto>(model); //no instanciar,  mapeo
            await _autoService.Insert(entity);
            return Ok("Registro guardado");
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult Put()
        {
            return Ok("HTTP PUT");
        }

        [HttpPatch]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult Patch()
        {
            return Ok("HTTP PATCH");
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "isAdminClaim")]

        public ActionResult Delete()
        {
            return Ok("HTTP Delate");
        }
    }
}