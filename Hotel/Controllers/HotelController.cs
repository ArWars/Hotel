using Hoteles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hoteles.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult Inicio()
        {
            hotelesEntidad db = new hotelesEntidad();
            List<hotel> hoteles = hoteles = db.hotel.ToList();
            
            return View(hoteles);
        }
        public ActionResult Agregar()
        {
            using (hotelesEntidad db = new hotelesEntidad())
            {
                List<categoria> categorias = db.categoria.ToList();
                ViewData["listaCategoria"] = categorias;
                return View();
            }
        }
        public ActionResult Ver(int id)
        {
            try
            {
                hotelesEntidad db = new hotelesEntidad();
                hotel hotel = db.hotel.Find(id);
                ViewData["categoria"] = hotel.categoria.nombre;
                ViewData["id"] = hotel.id;
                return View(hotel);
            }
            catch (Exception e)
            {
                TempData["Mensaje"] = new Mensajes() { Clase = "alert-danger", Titulo = "Error!", Mensaje = "Error al ver el hotel." };
                return View();
            }
        }
        public ActionResult Eliminar(int id)
        {
            using (hotelesEntidad db = new hotelesEntidad())
            {
                if (!ModelState.IsValid) return View();
                try
                {
                    hotel hotel = db.hotel.Find(id);
                    db.hotel.Remove(hotel);
                    db.SaveChanges();
                    return RedirectToAction("Inicio");
                }
                catch (Exception e)
                {
                    TempData["Mensaje"] = new Mensajes() { Clase = "alert-danger", Titulo = "Error!", Mensaje = "Error al eliminar el hotel." };
                    return View();
                }
            }
        }
        public ActionResult Editar(int id)
        {
            using (hotelesEntidad db = new hotelesEntidad())
            {
                List<categoria> categorias = db.categoria.ToList();
                ViewData["listaCategoria"] = categorias;
                try
                {
                    hotel h = db.hotel.Find(id);
                    return View(h);
                }
                catch (Exception e)
                {
                    TempData["Mensaje"] = new Mensajes() { Clase = "alert-danger", Titulo = "Error!", Mensaje = "Error al editar el hotel." };
                    return RedirectToAction("Inicio");
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(hotel h)
        {
            using (hotelesEntidad db = new hotelesEntidad())
            {
                List<categoria> categorias = db.categoria.ToList();
                ViewData["listaCategoria"] = categorias;
                if (!ModelState.IsValid) return View();
                try
                {
                    db.hotel.Add(h);
                    db.SaveChanges();
                    TempData["Mensaje"] = new Mensajes() { Clase = "alert-success", Titulo = "Perfecto!", Mensaje = "El hotel fue agregado satisfactoriamente." };
                    return RedirectToAction("Inicio");
                }
                catch (Exception e)
                {
                    TempData["Mensaje"] = new Mensajes() { Clase = "alert-danger", Titulo = "Error!", Mensaje = "Error al agregar el hotel." };
                    return View();
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(hotel h)
        {
            using (hotelesEntidad db = new hotelesEntidad())
            {
                List<categoria> categorias = db.categoria.ToList();
                ViewData["listaCategoria"] = categorias;
                if (!ModelState.IsValid) return View();
                try
                {
                    hotel hotel = db.hotel.Find(h.id);
                    hotel.nombre = h.nombre;
                    hotel.telefono = h.telefono;
                    hotel.fecha_construccion = h.fecha_construccion;
                    hotel.direccion = h.direccion;
                    hotel.categoria_id = h.categoria_id;
                    db.SaveChanges();
                    TempData["Mensaje"] = new Mensajes() { Clase = "alert-success", Titulo = "Perfecto!", Mensaje = "El hotel fue actualizado." };
                    return RedirectToAction("Inicio");
                }
                catch (Exception e)
                {
                    TempData["Mensaje"] = new Mensajes() { Clase = "alert-danger", Titulo = "Error!", Mensaje = "Error al editar el hotel." };
                    return View();
                }
            }
        }
    }
}