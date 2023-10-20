using System.ComponentModel.DataAnnotations;

namespace PRO401.DTO.AutoDTO
{
    public class AutoCreateDTO
    {
        [Required(ErrorMessage ="Patente requerida")]
        [MaxLength(6)]
        public string Patente { get; set; }
        [Required(ErrorMessage = "Id de marca requerida")]
        public int MarcaId { get; set; }
        [Required(ErrorMessage = "Id de modelo Requerida")]
        public int ModeloId { get; set; }

        [MaxLength(50)]
        public string? Color { get; set; }
        [Required(ErrorMessage = "Numero de carroceria Requerida")]
        public int CarroceriaId { get; set; }
    }
}
