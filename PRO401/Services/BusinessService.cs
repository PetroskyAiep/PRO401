namespace PRO401.Services
{
    public class BusinessService : IBusinessService
    {
        public bool PrimeraLetraMayuscula(string? texto)
        {
            if (char.IsUpper(texto[0]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
