namespace Iconos.Geograficos.Model.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Continente : Imagenes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdContinente { get; set; }

        public ICollection<Ciudad>  Ciudades { get; set; }
    }
}