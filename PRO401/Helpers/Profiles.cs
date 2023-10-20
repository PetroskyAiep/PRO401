using AutoMapper;
using PRO401.DTO.AccountDTO;
using PRO401.DTO.AutoDTO;
using PRO401.DTO.EncuestaDTO;
using PRO401.Entities;

namespace PRO401.Helpers
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<AutoCreateDTO, Auto>();
            CreateMap<EncuestaCreateDTO, Encuesta>();
            CreateMap<EncuestaDTO, Encuesta>();
            CreateMap<Encuesta, EncuestaDTO>();
            CreateMap<UsuarioCreateDTO, Usuario>();
        }
    }
}
