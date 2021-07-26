using Iconos.Geograficos.Model.Entities;
using System.Collections.Generic;

namespace Iconos.Geograficos.Model.ViewModels
{
    public class CiudadViewModel : Imagenes
    {
        /*public string ImagenUrl { get; set; }
        public string Denominacion { get; set; }*/
        public int CantidadHabitantes { get; set; }
       
        public decimal SuperficieTotal { get; set; }
        public ICollection<IconosGeograficosViewModel> IconosGeograficos { get; set; }

    }
}
