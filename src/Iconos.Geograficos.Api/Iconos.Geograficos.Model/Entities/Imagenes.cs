using System.ComponentModel.DataAnnotations;

namespace Iconos.Geograficos.Model.Entities
{
    public class Imagenes
    {        
        [Display(Name = "Denominación")]
        public string Denominacion { get; set; }

        public string ImagenUrl { get; set; }
        public string ImagenThumbnailUrl { get; set; }
    }
}