using Hoteles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace categoriaes.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Inicio()
        {
            hotelesEntidad db = new hotelesEntidad();
            List<categoria> categorias = db.categoria.ToList();
            
            return View(categorias);
        }
        public ActionResult Agregar()
        {
            return View();
        }
        public ActionResult Eliminar(int id)
        {
            using (hotelesEntidad db = new hotelesEntidad())
            {
                if (!ModelState.IsValid) return View();
                try
                {
                    categoria categoria = db.categoria.Find(id);
                    db.categoria.Remove(categoria);
                    db.SaveChanges();
                    TempData["Mensaje"] = new Mensajes() { Clase = "alert-success", Titulo = "Perfecto!", Mensaje = "La categoria fue eliminada." };
                    return RedirectToAction("Inicio");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Error al eliminar el categoria.", e);
                    return View();
                }
            }
        }
        public ActionResult Editar(int id)
        {
            using (hotelesEntidad db = new hotelesEntidad())
            {
                try
                {
                    categoria h = db.categoria.Find(id);
                    return View(h);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Este categoria no existe.", e);
                    return RedirectToAction("Inicio");
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(categoria h)
        {
            using (hotelesEntidad db = new hotelesEntidad())
            {
                if (!ModelState.IsValid) return View();
                try
                {
                    db.categoria.Add(h);
                    db.SaveChanges();
                    TempData["Mensaje"] = new Mensajes() { Clase = "alert-success", Titulo = "Perfecto!", Mensaje = "La categoria fue agregada." };
                    return RedirectToAction("Inicio");
                }
                catch (Exception e)
                {
                    TempData["Mensaje"] = new Mensajes() { Clase = "alert-danger", Titulo = "Error!", Mensaje = "Error al agregar la categoria." };
                    return View();
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(categoria h)
        {
            using (hotelesEntidad db = new hotelesEntidad())
            {
                if (!ModelState.IsValid) return View();
                try
                {
                    categoria categoria = db.categoria.Find(h.id);
                    categoria.nombre = h.nombre;
                    categoria.descripcion = h.descripcion;
                    categoria.iva = h.iva;
                    db.SaveChanges();
                    TempData["Mensaje"] = new Mensajes() { Clase = "alert-success", Titulo = "Perfecto!", Mensaje = "La categoria fue actualizada." };
                    return RedirectToAction("Inicio");
                }
                catch (Exception e)
                {
                    TempData["Mensaje"] = new Mensajes() { Clase = "alert-danger", Titulo = "Error!", Mensaje = "Error al agregar la categoria." };
                    return View();
                }
            }
        }
    }
}