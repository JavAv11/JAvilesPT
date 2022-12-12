using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Genero
    {
        public static ML.Result GeneroGetAll()
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.JAvilesPTEntities context = new DL_EF.JAvilesPTEntities())
                {
                    var query = context.GeneroGetAll().ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var objGenero in query)
                        {
                            ML.Genero genero = new ML.Genero();

                            genero.IdGenero = objGenero.IdGenero;
                            genero.Nombre = objGenero.NombreGenero;

                            result.Objects.Add(genero);
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
                result.ex = ex;
            }
            return result;
        }
    }
}
