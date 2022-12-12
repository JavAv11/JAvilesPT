using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Autor
    {
        public static ML.Result AutorGetAll()
        {
            ML.Result result = new ML.Result();
            try
            {

                using(DL_EF.JAvilesPTEntities context = new DL_EF.JAvilesPTEntities())
                {
                    var query = context.AutorGetAll().ToList();
                    result.Objects = new List<object>() ;
                    if (query != null)
                    {
                        foreach(var objAutor in query)
                        {
                            ML.Autor autor = new ML.Autor();

                            autor.IdAutor = objAutor.IdAutor;
                            autor.Nombre = objAutor.NombreAutor;

                            result.Objects.Add(autor);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.ex=ex;
            }
            return result;
        }
    }
}
