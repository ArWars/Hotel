using Hoteles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using static Hoteles.Models.Helper;

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
                DateTime f1 = new DateTime();
                DateTime f2 = new DateTime();
                try
                {
                    f1 = Convertir.aTimeStamp(Convert.ToInt64(fecha1));
                    f2 = Convertir.aTimeStamp(Convert.ToInt64(fecha2));
                }
                catch(Exception e) {
                    co.total = (co.precio * co.iva) / 100 + co.precio;
                    return Json(co, JsonRequestBehavior.AllowGet);
                }
                TimeSpan ts = new TimeSpan();
                TimeSpan hora2 = new TimeSpan(12, 0, 0);
                ts = f2.Subtract(f1);
                //ts2 = a2.Subtract(a1);
                co.tiempoExtra = ts.Days + ((ts.Days == 1) ? " Día":" Dias");
                co.tiempoExtra += " con " + ts.Hours + ((ts.Hours == 1) ? " Hora" : " Horas");
                co.total = (( (ts.Days==0) ? co.precio *1 : co.precio * ts.Days) * co.iva) / 100 + co.precio;
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
        public ActionResult Inicio(reserva r)
        {
            using (hotelesEntidad db = new hotelesEntidad())
            {
                if (!ModelState.IsValid) return View();
                try
                {
                    int contador = db.reserva.Where(c => c.fechaInicio >= r.fechaInicio)
                                       .Where(c => c.fechaTermino <= r.fechaTermino)
                                       .Where(c => c.habitacion_id == r.habitacion_id).Count();
                    if (contador == 0)
                    {
                        db.reserva.Add(r);
                        db.SaveChanges();
                        TempData["Mensaje"] = new Mensajes() { Clase = "alert-success", Titulo = "Perfecto!", Mensaje = "La reserva fue creada." };
                    }
                    else TempData["Mensaje"] = new Mensajes() { Clase = "alert-danger", Titulo = "Error!", Mensaje = "Existen clientes en este horario, seleccionar otro." };
                    return RedirectToAction("Inicio", "Inicio");
                }
                catch (Exception e)
                {
                    TempData["Mensaje"] = new Mensajes() { Clase = "alert-danger", Titulo = "Error!", Mensaje = "Error al agregar la reserva." };
                    return RedirectToAction("Inicio", "Inicio");
                }
            }
        }
    }
}