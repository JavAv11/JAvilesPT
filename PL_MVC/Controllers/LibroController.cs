using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
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

            return View();
        }
    }
}