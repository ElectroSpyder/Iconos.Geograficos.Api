using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iconos.Geograficos.Model.Entities
{
    public class Ciudad : Imagenes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCiudad { get; set; }

        [Display(Name = "Cantidad de Habitantes")]
        public int CantidadHabitantes { get; set; }

        [Display(Name = "Superficie Total")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal SuperficieTotal { get; set; }

        public ICollection<IconosReograficos> IconosGeograficos { get; set; }

        public int IdContinente { get; set; }
        public Continente Continente { get; set; }
    }
}