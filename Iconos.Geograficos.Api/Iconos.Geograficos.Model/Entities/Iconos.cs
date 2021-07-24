namespace Iconos.Geograficos.Model.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Iconos : Imagenes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdIcono { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; }

        public int Altura { get; set; }

        public string Historia { get; set; }

        public Ciudad IdCiudad { get; set; }
    }
}
