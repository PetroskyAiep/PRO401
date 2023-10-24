using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PRO401.DTO.ComunaDTO;
using PRO401.DTO.EncuestaDTO;
using PRO401.Entities;

namespace PRO401.Services
{
    public class ComunaService : IComunaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ComunaService(ApplicationDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ComunaDTO>> getComunas()
        {
            var comunasDesdeBD = await _context.Comuna.ToListAsync();
            var respuesta = _mapper.Map<List<ComunaDTO>>(comunasDesdeBD);
            return respuesta;
        }
    }
}
