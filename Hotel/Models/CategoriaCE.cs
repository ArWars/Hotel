using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hoteles.Models
{
    public class CategoriaCE
    {
        [Required]
        [MaxLength(70)]
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [Required]
        [MaxLength(255)]
        [DisplayName("Descripción")]
        public string descripcion { get; set; }
        [Required]
        [DisplayName("IVA")]
        public int iva { get; set; }
    }
    [MetadataType(typeof(CategoriaCE))]
    public partial class categoria
    {
    }
}