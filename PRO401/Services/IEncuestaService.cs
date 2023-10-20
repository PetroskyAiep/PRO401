using PRO401.DTO.EncuestaDTO;
using PRO401.Entities;

namespace PRO401.Services
{
    public interface IEncuestaService
    {
        Task<EncuestaDTO> getEncuesta(string email);


        Task Insert(Encuesta entity);
    }
}
