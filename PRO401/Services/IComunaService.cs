using Microsoft.EntityFrameworkCore;
using PRO401.DTO.ComunaDTO;

namespace PRO401.Services
{
    public interface IComunaService
    {
        Task<List<ComunaDTO>> getComunas();
    }
}
