using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Libro libro = new ML.Libro();
            ML.Result result = new ML.Result();

            result = BL.Libro.GetAll_EF();
            if (result.Correct)
            {
                libro.Libros = result.Objects;
                return View(libro);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Form(int? IdLibro) {
            ML.Libro libro = new ML.Libro();

            libro.Autor = new ML.Autor();
            libro.Editorial=new ML.Editorial();
            libro.Genero = new ML.Genero();

            ML.Result resultAutor = BL.Autor.AutorGetAll();
            ML.Result resultEditorial = BL.Editorial.EditorialGetAll();
            ML.Result resultGenero = BL.Genero.GeneroGetAll();

            if (IdLibro == null)
            {
                libro.Autor.NombreAutor = resultAutor.Objects;
                libro.Editorial.NombreEditorial = resultEditorial.Objects;
                libro.Genero.NombreGenero = resultGenero.Objects;
                return View(libro);
            }
            else
            {
                ML.Result result = BL.Libro.GetById_EF(IdLibro.Value);

                if (result.Correct)
                {
                    libro = (ML.Libro)result.Object;
                    libro.Autor.NombreAutor = resultAutor.Objects;
                    libro.Editorial.NombreEditorial = resultEditorial.Objects;
                    libro.Genero.NombreGenero = resultGenero.Objects;
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al realizar la consulta";
                    return PartialView("Modal");
                }
                return View(libro);
            }
        }

        [HttpPost]

        public ActionResult Form(ML.Libro libro)
        {
            if (libro.IdLibro == 0)
            {
                ML.Result result = BL.Libro.Add_EF(libro);
                if (result.Correct)
                {
                    ViewBag.Message = "Se agrego correctamente";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Se agrego correctamente";
                    return PartialView("Modal");
                }
            }
            else
            {
                ML.Result result = BL.Libro.Update_EF(libro);
                if (result.Correct)
                {
                    ViewBag.Message = "Se Actualizo correctamente";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No se actualizo el libro";
                    return PartialView("Modal");
                }
            }
        }

        [HttpGet]

        public ActionResult Delete(int IdLibro)
        {
            ML.Result result = new ML.Result();

            result = BL.Libro.Delete_EF(IdLibro);

            if(result.Correct)
            {
                ViewBag.Message = "Se ha eliminado el registro";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "No se ha podido eliminar el registro";
                return PartialView("Modal");
            }
        }
    }
}