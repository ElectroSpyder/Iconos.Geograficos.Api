namespace Iconos.Geograficos.Model.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class IconosReograficos : Imagenes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdIcono { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; }

        public decimal Altura { get; set; }

        public string Historia { get; set; }

        public Ciudad Ciudad { get; set; }
        public int IdCiudad { get; set; }
    }
}
