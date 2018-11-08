using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hoteles.Models
{
    public class HabitacionCE
    {
        public int id { get; set; }

        [Required]
        [StringLength(10)]
        [Remote("codigoExistente", "Habitacion", AdditionalFields = "id", ErrorMessage = "Este codigo ya fue utilizado.")]
        [DisplayName("Código")]
        public string codigo { get; set; }

        [Required]
        [DisplayName("Clase")]
        public byte clase { get; set; }

        [Required]
        [DisplayName("Hotel")]
        public int hotel_id { get; set; }

        [Required]
        [DisplayName("Precio")]
        public int precio { get; set; }
    }
    [MetadataType(typeof(HabitacionCE))]
    public partial class habitacion
    {
        
    }

}