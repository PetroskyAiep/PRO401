using Microsoft.EntityFrameworkCore;
using PRO401.Entities;

namespace PRO401.Services
{
    public class AutoService : IAutoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IBusinessService _bussinesService;

        public AutoService(ApplicationDbContext context, IBusinessService bussinesService)
        {
            _context = context;
            _bussinesService = bussinesService;
        } 

        public async Task<bool> PatenteExiste(string patente)
        {
            var patenteExiste = await _context.Autos.AnyAsync(x => x.Patente == patente);
            
            if (patenteExiste)
            {
                return true;
            }
            else{
                return false;
            }

        }

        public bool PrimeraLetraMayuscula(string color)
        {
            var result = _bussinesService.PrimeraLetraMayuscula(color);
            return result;
        }

        public async Task Insert(Auto entity)
        {
            _context.Autos.Add(entity);
            await _context.SaveChangesAsync();
        } 



    }
}
