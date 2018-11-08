using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hoteles.Models
{
    public class ReservaCE
    {
        public int id { get; set; }
        [Required]
        [DisplayName("Habitación")]
        public int habitacion_id { get; set; }
        [Required]
        [MaxLength(70)]
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Dirección")]
        public string direccion { get; set; }
        [Required]
        [DisplayName("Teléfono")]
        public int telefono { get; set; }
        [Required]
        [MaxLength(70)]    
        [DisplayName("Nombre Agencia")]
        public string agencia_nombre { get; set; }
        [Required]
        [DisplayName("Fecha de Inicio")]
        public System.DateTime fechaInicio { get; set; }
        [Required]
        [DisplayName("Fecha de Termino")]
        public System.DateTime fechaTermino { get; set; }
    }
    [MetadataType(typeof(ReservaCE))]
    public partial class reserva
    {

    }
}