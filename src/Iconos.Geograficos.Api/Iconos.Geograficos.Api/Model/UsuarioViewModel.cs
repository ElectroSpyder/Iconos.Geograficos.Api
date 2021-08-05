using System.ComponentModel.DataAnnotations;

namespace Iconos.Geograficos.Api.Model
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage ="Debe ingresar Usuario")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Debe ingresa Contraseña")]
        public string Password { get; set; }
    }
}
