using System.ComponentModel.DataAnnotations;

namespace PRO401.Entities
{
    public class Comuna
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre requerido")]
        public string Nombre { get; set; }
        public List<Usuario> UsuariosResidentes { get; set; }
        public List<Usuario> UsuariosTrabajadores { get; set; }
    }
}
