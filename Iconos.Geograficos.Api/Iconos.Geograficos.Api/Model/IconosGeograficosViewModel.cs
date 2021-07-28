﻿namespace Iconos.Geograficos.Api.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class IconosGeograficosViewModel
    {
       
        public int IdIcono { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; }

        public int Altura { get; set; }

        public string Historia { get; set; }

    }
}
