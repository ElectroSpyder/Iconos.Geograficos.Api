using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iconos.Geograficos.Model.Entities
{
    public class Imagenes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdImagen { get; set; }
        public byte[] Imagen { get; set; }
        [Display(Name = "Denominación")]
        public string Denominacion { get; set; }
    }
}