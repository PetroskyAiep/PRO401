using PRO401.Entities;

namespace PRO401.Services
{
    public interface IAutoService
    {
        Task<bool> PatenteExiste(string patenteId);

        bool PrimeraLetraMayuscula(string color);

        Task Insert(Auto entity);


    }
}
