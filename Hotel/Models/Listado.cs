using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hoteles.Models
{
    public class Listado
    {
        public static string[] lista = { "Seleccionar Clase", "Individuales", "Dobles", "Suite" };
        public static string getLista(int id) { return lista[id]; }
        public static string[] getListado() { return lista; }
        public int id { get; set; }
        public string nombre { get; set; }
    }
    public class codigos
    {
        public string codigo { get; set; }
        public int precio { get; set; }
        public int total { get; set;  }
        public string tiempoExtra { get; set; }
        public string hotel { get; set; }
        public string clase { get; set; }
        public int iva { get; set; }
    }
}