using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Editorial
    {
        public static ML.Result EditorialGetAll()
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.JAvilesPTEntities context = new DL_EF.JAvilesPTEntities())
                {
                    var query = context.EditorialGetAll().ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var objEditorial in query)
                        {
                            ML.Editorial editorial = new ML.Editorial();

                            editorial.IdEditorial = objEditorial.IdEditorial;
                            editorial.Nombre = objEditorial.NombreEditorial;

                            result.Objects.Add(editorial);
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
