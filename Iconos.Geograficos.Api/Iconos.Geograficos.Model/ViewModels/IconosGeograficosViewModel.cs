namespace Iconos.Geograficos.Model.ViewModels
{
    using Iconos.Geograficos.Model.Entities;
    using System;
   
    public class IconosGeograficosViewModel : Imagenes
    {
        
        public int IdIcono { get; set; }
       
        public DateTime FechaCreacion { get; set; }

        public int Altura { get; set; }

        public string Historia { get; set; }

       /* public string CiudadDenominacion { get; set; }
        public int CiudadCantidadHabitantes { get; set; }

        public decimal CiudadSuperficieTotal { get; set; }*/

    }
}
