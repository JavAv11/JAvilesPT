using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Libro
    {

        public static void Add()
        {
            ML.Libro libro = new ML.Libro();


            Console.WriteLine("Escribe Nombre de un Libro");
            libro.Nombre = Console.ReadLine();

            Console.WriteLine("Escribe IdAutor de un Libro");
            libro.IdAutor = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe Numero de Paginas de un Libro");
            libro.NumeroPaginas = Console.ReadLine();

            Console.WriteLine("Escribe Fecha de Publicacion de un Libro");
            libro.FechaPublicacion = Console.ReadLine();

            Console.WriteLine("Escribe IdEditorial de un Libro");
            libro.IdEditorial = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe Edicion de un Libro");
            libro.Edicion = Console.ReadLine();

            Console.WriteLine("Escribe IdGenero de un Libro");
            libro.IdGenero = int.Parse(Console.ReadLine());

            ML.Result result = new ML.Result();

            result = BL.Libro.Add(libro);

            if (result.Correct = true)
            {
                Console.WriteLine("Libro Registrado");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Libro no Registrado");
                Console.ReadLine();
            }

        }

        public static void Update()
        {
            ML.Libro libro = new ML.Libro();

            Console.WriteLine("Escribe Nombre de un Libro");
            libro.IdLibro = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe Nombre de un Libro");
            libro.Nombre = Console.ReadLine();

            Console.WriteLine("Escribe IdAutor de un Libro");
            libro.IdAutor = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe Numero de Paginas de un Libro");
            libro.NumeroPaginas = Console.ReadLine();

            Console.WriteLine("Escribe Fecha de Publicacion de un Libro");
            libro.FechaPublicacion = Console.ReadLine();

            Console.WriteLine("Escribe IdEditorial de un Libro");
            libro.IdEditorial = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe Edicion de un Libro");
            libro.Edicion = Console.ReadLine();

            Console.WriteLine("Escribe IdGenero de un Libro");
            libro.IdGenero = int.Parse(Console.ReadLine());

            ML.Result result = new ML.Result();

            result = BL.Libro.Update(libro);

            if (result.Correct = true)
            {
                Console.WriteLine("Libro Registrado");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Libro no Registrado");
                Console.ReadLine();
            }

        }

        public static void Delete(int IdLibro)
        {
            ML.Libro libro = new ML.Libro();

            Console.WriteLine("Escribe el libro que quieras borrar");
            libro.IdLibro = Convert.ToInt32(Console.ReadLine());

            ML.Result result = new ML.Result();

            result = BL.Libro.Delete(IdLibro);

            if (result.Correct == true)
            {
                Console.WriteLine("El Libro se borro correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El Libro no pudo ser borrado " + result.ErrorMessage);
                Console.ReadKey();
            }
        } 

        
    }
   
}
