using Hoteles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hoteles.Controllers
{
    public class HabitacionController : Controller
    {
        // GET: Habitacion
        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult codigoExistente(string codigo, int id)
        {
            habitacion hab = null;
            using (hotelesEntidad db = new hotelesEntidad())
            {
                try {
                    hab = (from c in db.habitacion where c.codigo == codigo select c).First();
                }catch(Exception e) { }
            }
            if (hab.codigo == codigo && id != hab.id )
            {
                return Content("false");
            }
            else
            {
                return Content("true");
            }
        }
        public ActionResult Eliminar(int id)
        {
            using (hotelesEntidad db = new hotelesEntidad())
            {
                if (!ModelState.IsValid) return View();
                try
                {
                    habitacion h = db.habitacion.Find(id);
                    db.habitacion.Remove(h);
                    db.SaveChanges();
                    TempData["Mensaje"] = new Mensajes() { Clase = "alert-success", Titulo = "Perfecto!", Mensaje = "La categoria fue eliminada." };
                    return RedirectToAction("Ver", "Hotel", new { id = h.hotel_id });
                }
                catch (Exception e)
                {
                    TempData["Mensaje"] = new Mensajes() { Clase = "alert-danger", Titulo = "Error!", Mensaje = "Error al agregar la categoria." };
                    return RedirectToAction("Inicio", "Hotel" );
                }
            }
        }
        public ActionResult Agregar(int id)
        {
            try
            {
                string[] lista = Listado.getListado();
                List<Listado> clases = new List<Listado>();
                
                for(int i=0; i< lista.Length; i++ ) {
                    Listado item = new Listado();
                    item.id = i;
                    item.nombre = lista[i];
                    clases.Add(item);
                }
                ViewData["listaClases"] = clases;
                habitacion hab = new habitacion();
                hab.hotel_id = id;
                return View(hab);
            }
            catch (Exception e)
            {
                TempData["Mensaje"] = new Mensajes() { Clase = "alert-danger", Titulo = "Error!", Mensaje = "Error al agregar la habitación." };
                return RedirectToAction("Ver", "Hotel", id); ;
            }
        }
        public ActionResult Editar(int id)
        {
            using (hotelesEntidad db = new hotelesEntidad())
            {
                try
                {
                    string[] lista = Listado.getListado();
                    List<Listado> clases = new List<Listado>();

                    for (int i = 0; i < lista.Length; i++)
                    {
                        Listado item = new Listado();
                        item.id = i;
                        item.nombre = lista[i];
                        clases.Add(item);
                    }
                    ViewData["listaClases"] = clases;
                    habitacion h = db.habitacion.Find(id);
                    return View(h);
                }
                catch (Exception e)
                {
                    TempData["Mensaje"] = new Mensajes() { Clase = "alert-danger", Titulo = "Error!", Mensaje = "Error al editar esta habitación." };
                    return RedirectToAction("Inicio");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(habitacion h)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(habitacion h)
        {
            using (hotelesEntidad db = new hotelesEntidad())
            {
                if (!ModelState.IsValid) return View();
                try
                {
                    habitacion hab = db.habitacion.Find(h.id);
                    hab.codigo = h.codigo.ToUpper();
                    hab.precio = h.precio;
                    hab.clase = h.clase;
                    db.SaveChanges();
                    TempData["Mensaje"] = new Mensajes() { Clase = "alert-success", Titulo = "Perfecto!", Mensaje = "La habitación fue actualizada." };
                    return RedirectToAction("Ver", "Hotel", new { id = h.hotel_id });
                }
                catch (Exception e)
                {
                    TempData["Mensaje"] = new Mensajes() { Clase = "alert-danger", Titulo = "Error!", Mensaje = "Error al editar la habitación." };
                    return RedirectToAction("Ver", "Hotel", new { id = h.hotel_id });
                }
            }
        }
    }
}