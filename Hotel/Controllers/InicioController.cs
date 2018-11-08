using Hoteles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace Hoteles.Controllers
{
    public class InicioController : Controller
    {
        public ActionResult Inicio()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult obtenerDetalle(string id, string fecha1 = null, string fecha2 = null)
        {
            using (hotelesEntidad db = new hotelesEntidad())
            {
                if (String.IsNullOrEmpty(id))
                {
                    return null;
                }
                int cod = 0;
                bool isValid = Int32.TryParse(id, out cod);
                var s = db.habitacion.Find(cod);
                codigos co = new codigos();
                co.codigo = s.codigo;
                co.precio = s.precio;
                co.hotel = s.hotel.nombre;
                co.clase = Listado.getLista(s.clase);
                co.iva = s.hotel.categoria.iva;
                if (fecha1 != null && fecha2 != null)
                {
                    var f1 = DateTime.ParseExact(fecha1.Split(' ')[0] + " 12:00", "dd/MM/yyyy HH:mm", null);
                    var a1 = DateTime.ParseExact(fecha2.Split(' ')[0] + " 12:00", "dd/MM/yyyy HH:mm", null);
                    var f2 = DateTime.ParseExact(fecha1, "dd/MM/yyyy HH:mm", null);
                    var a2 = DateTime.ParseExact(fecha2, "dd/MM/yyyy HH:mm", null);
                    var f3 = fecha2.Split(' ')[1].Split(':');
                    TimeSpan ts = new TimeSpan();
                    TimeSpan ts2 = new TimeSpan();
                    TimeSpan hora1 = new TimeSpan(Convert.ToInt32(f3[0]), Convert.ToInt32(f3[1]), 0), hora2 = new TimeSpan(12, 0, 0);
                    ts = f2.Subtract(f1);
                    ts2 = a2.Subtract(a1);
                    co.tiempoExtra = ts.Days + ((ts.Days == 1) ? " Día":" Dias");
                    if (hora1 > hora2)
                    {
                        co.tiempoExtra += " con " + ts2.Hours + ((ts2.Hours == 1) ? " Hora" : " Horas");
                        co.total = (( (ts.Days==0) ? co.precio *1 : co.precio * ts.Days) * co.iva) / 100;
                    }
                }
                return Json(co, JsonRequestBehavior.AllowGet);
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult obtenerHabitaciones(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return null;
            }
            hotelesEntidad db = new hotelesEntidad();
            int cod = 0;
            bool isValid = Int32.TryParse(id, out cod);
            var habitaciones = from habitacion in db.habitacion
                                where habitacion.hotel_id == cod
                                select habitacion;
            var contenido = habitaciones.ToList<habitacion>();

            var result = (from s in contenido
                            select new
                            {
                                id = s.id,
                                codigo = s.codigo,
                                precio = s.precio
                            }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inicio(habitacion h)
        {
            using (hotelesEntidad db = new hotelesEntidad())
            {
                if (!ModelState.IsValid) return View();
                try
                {
                    h.codigo = h.codigo.ToUpper();
                    db.habitacion.Add(h);
                    db.SaveChanges();
                    TempData["Mensaje"] = new Mensajes() { Clase = "alert-success", Titulo = "Perfecto!", Mensaje = "La habitación fue creada." };
                    return RedirectToAction("Ver", "Hotel", new { id = h.hotel_id });
                }
                catch (Exception e)
                {
                    TempData["Mensaje"] = new Mensajes() { Clase = "alert-danger", Titulo = "Error!", Mensaje = "Error al agregar la habitación." };
                    return RedirectToAction("Ver", "Hotel", new { id = h.hotel_id });
                }
            }
        }
    }
}