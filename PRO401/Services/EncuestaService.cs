using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PRO401.DTO.EncuestaDTO;
using PRO401.Entities;

namespace PRO401.Services
{
    public class EncuestaService: IEncuestaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<Usuario> _userManager;

        public EncuestaService(ApplicationDbContext context, IMapper mapper, UserManager<Usuario> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<EncuestaDTO> getEncuesta(string email)
        {   
            Encuesta encuestaDesdeBd = await _context.Encuesta.FirstAsync(a => a.UsuarioEmail == email);
            var respuesta = _mapper.Map<EncuestaDTO>(encuestaDesdeBd);
            return respuesta;

        }
    
        public async Task Insert(Encuesta entity)
        {
            _context.Encuesta.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}
