using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PRO401.DTO.EncuestaDTO;
using PRO401.Entities;
using PRO401.Services;

namespace PRO401.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncuestaController : ControllerBase
    {
        private readonly IEncuestaService _encuestaService;
        private readonly IMapper _mapper;
        private readonly UserManager<Usuario> _userManager;

        public EncuestaController(IEncuestaService encuestaService, IMapper mapper, UserManager<Usuario> userManager)
        {
            _encuestaService = encuestaService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<EncuestaDTO> GetEncuesta()
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim != null ? emailClaim.Value : null;
            if (email != null)
            {
                EncuestaDTO respuesta = await _encuestaService.getEncuesta(email);
                return respuesta;
            }
            return null;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Post(EncuestaCreateDTO model)
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim != null ? emailClaim.Value : null;
            if (email != null)
            {
                model.UsuarioEmail = email;
                var entity = _mapper.Map<Encuesta>(model);
                await _encuestaService.Insert(entity);
                return Ok("Registro guardado");
            }
            return BadRequest("Error al guardar");

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
