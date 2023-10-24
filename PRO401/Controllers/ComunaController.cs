using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PRO401.DTO.ComunaDTO;
using PRO401.Entities;
using PRO401.Services;

namespace PRO401.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComunaController : ControllerBase
    {
        private readonly IComunaService _comunaService;

        public ComunaController(IComunaService comunaService)
        {
            _comunaService = comunaService;
        }

        [HttpGet]
        public async Task<ActionResult> getComunas()
        {
                var lista = await _comunaService.getComunas();
                return Ok(lista);
        }
    }
}
