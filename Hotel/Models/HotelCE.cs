using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hoteles.Models
{
    public class HotelCE
    {
        [Required]
        [DisplayName("Nombre")]
        [StringLength(70)]
        public string nombre { get; set; }

        [Required]
        [StringLength(70)]
        [DisplayName("Dirección")]
        public string direccion { get; set; }

        [Required]
        [DisplayName("Teléfono")]
        public int telefono { get; set; }

        [Required]
        [DisplayName("Fecha de Construcción")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime fecha_construccion { get; set; }

        [Required]
        [DisplayName("Categoria")]
        public int categoria_id { get; set; }
        public virtual categoria categoria { get; set; }
        public virtual List<habitacion> habitacion { get; set; }
    }
    [MetadataType(typeof(HotelCE))]
    public partial class hotel
    {

    }
}