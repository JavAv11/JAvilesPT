using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "AddLibro";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = context;
                        SqlParameter[] collection = new SqlParameter[7];

                        collection[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = libro.Nombre;

                        collection[1] = new SqlParameter("@IdAutor", System.Data.SqlDbType.Int);
                        collection[1].Value = libro.IdAutor;

                        collection[2] = new SqlParameter("@NumeroPaginas", System.Data.SqlDbType.VarChar);
                        collection[2].Value = libro.NumeroPaginas;

                        collection[3] = new SqlParameter("@FechaPublicacion", System.Data.SqlDbType.VarChar);
                        collection[3].Value = libro.FechaPublicacion;

                        collection[4] = new SqlParameter("@IdEditorial", System.Data.SqlDbType.Int);
                        collection[4].Value = libro.IdEditorial;

                        collection[5] = new SqlParameter("@Edicion", System.Data.SqlDbType.VarChar);
                        collection[5].Value = libro.Edicion;

                        collection[6] = new SqlParameter("@IdGenero", System.Data.SqlDbType.Int);
                        collection[6].Value = libro.IdGenero;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;

        }

        public static ML.Result Update(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UpdateLibro";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = context;
                        SqlParameter[] collection = new SqlParameter[8];

                        collection[0] = new SqlParameter("@IdLibro", System.Data.SqlDbType.Int);
                        collection[0].Value = libro.IdLibro;

                        collection[1] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        collection[1].Value = libro.Nombre;

                        collection[2] = new SqlParameter("@IdAutor", System.Data.SqlDbType.Int);
                        collection[2].Value = libro.IdAutor;

                        collection[3] = new SqlParameter("@NumeroPaginas", System.Data.SqlDbType.VarChar);
                        collection[3].Value = libro.NumeroPaginas;

                        collection[4] = new SqlParameter("@FechaPublicacion", System.Data.SqlDbType.VarChar);
                        collection[4].Value = libro.FechaPublicacion;

                        collection[5] = new SqlParameter("@IdEditorial", System.Data.SqlDbType.Int);
                        collection[5].Value = libro.IdEditorial;

                        collection[6] = new SqlParameter("@Edicion", System.Data.SqlDbType.VarChar);
                        collection[6].Value = libro.Edicion;

                        collection[7] = new SqlParameter("@IdGenero", System.Data.SqlDbType.Int);
                        collection[7].Value = libro.IdGenero;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Delete(int IdLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "LibroDelete";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdLibro", System.Data.SqlDbType.Int);
                        collection[0].Value = IdLibro;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;

                        }
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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())

                    {
                        cmd.CommandText = "LibroGetAll";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;


                        DataTable tableLibro = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        ML.Libro libro = new ML.Libro();
                        adapter.Fill(tableLibro);
                        if (tableLibro.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow dataRow in tableLibro.Rows)
                            {
                                libro.IdLibro = int.Parse(dataRow[0].ToString());
                                libro.Nombre = dataRow[1].ToString();
                                libro.IdAutor = int.Parse(dataRow[2].ToString());
                                libro.NumeroPaginas = int.Parse(dataRow[3].ToString());
                                libro.FechaPublicacion = dataRow[4].ToString();
                                libro.IdEditorial = int.Parse(dataRow[0].ToString());
                                libro.Edicion = dataRow[5].ToString();
                                libro.IdGenero = int.Parse(dataRow[6].ToString());

                                result.Objects.Add(libro);

                            }
                            if (result.Objects.Count > 0)
                            {
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                            }
                        }
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

        public static ML.Result GetById(int IdLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "GetByIdLibro";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("@IdLibro", SqlDbType.Int);
                        collection[0].Value = IdLibro;

                        cmd.Parameters.Add(collection);


                        DataTable tableLibro = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        adapter.Fill(tableLibro);
                        if (tableLibro.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            DataRow dataRow = tableLibro.Rows[0];

                            ML.Libro libro = new ML.Libro();
                            libro.IdLibro = int.Parse(dataRow[0].ToString());
                            libro.Nombre = dataRow[1].ToString();
                            libro.IdAutor = int.Parse(dataRow[2].ToString());
                            libro.NumeroPaginas = int.Parse(dataRow[3].ToString());
                            libro.FechaPublicacion = dataRow[4].ToString();
                            libro.IdEditorial = int.Parse(dataRow[0].ToString());
                            libro.Edicion = dataRow[5].ToString();
                            libro.IdGenero = int.Parse(dataRow[6].ToString());

                            result.Objects.Add(libro);


                            if (result.Objects.Count > 0)
                            {
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                            }
                        }
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


        //ENtityFramework

        public static ML.Result Add_EF(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JAvilesPTEntities context = new DL_EF.JAvilesPTEntities())
                {

                    var query = context.AddLibro(
                        libro.Nombre,
                        libro.Autor.IdAutor,
                        libro.NumeroPaginas,
                        libro.FechaPublicacion,
                        libro.Editorial.IdEditorial,
                        libro.Edicion,
                        libro.Genero.IdGenero);

                    if (query > 0)
                    {
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
                result.Correct = true;
                result.ErrorMessage = ex.Message;
                result.ex = ex;
            }
            return result;
        }

        public static ML.Result Update_EF(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JAvilesPTEntities context = new DL_EF.JAvilesPTEntities())
                {

                    var query = context.UpdateLibro(libro.IdLibro, libro.Nombre, libro.Autor.IdAutor, libro.NumeroPaginas, libro.FechaPublicacion, libro.Editorial.IdEditorial, libro.Edicion, libro.Genero.IdGenero);

                    if (query > 0)
                    {
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

        public static ML.Result Delete_EF(int IdLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JAvilesPTEntities context = new DL_EF.JAvilesPTEntities())
                {
                    var query = context.LibroDelete(IdLibro);

                    if (query > 0)
                    {
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

        public static ML.Result GetAll_EF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JAvilesPTEntities context = new DL_EF.JAvilesPTEntities())
                {
                    var query = context.LibroGetAll().ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Libro objLibro = new ML.Libro();

                            objLibro.IdLibro = obj.IdLibro;
                            objLibro.Nombre = obj.Nombre;

                            objLibro.Autor = new ML.Autor();
                            objLibro.Autor.IdAutor = obj.IdAutor;
                            objLibro.Autor.Nombre = obj.NombreAutor;

                            objLibro.NumeroPaginas = obj.NumeroPaginas.Value;
                            objLibro.FechaPublicacion = obj.FechaPublicacion.ToString();

                            objLibro.Editorial = new ML.Editorial();
                            objLibro.Editorial.IdEditorial = obj.IdEditorial;
                            objLibro.Editorial.Nombre = obj.NombreEditorial;

                            objLibro.Edicion = obj.Edicion;

                            objLibro.Genero = new ML.Genero();
                            objLibro.Genero.IdGenero = obj.IdGenero;
                            objLibro.Genero.Nombre = obj.NombreGenero;

                            result.Objects.Add(objLibro);
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

        public static ML.Result GetById_EF(int IdLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JAvilesPTEntities context = new DL_EF.JAvilesPTEntities())
                {
                    var obj = context.LibroGetById(IdLibro).FirstOrDefault();
                    result.Objects = new List<object>();

                    if (obj != null)
                    {
                        ML.Libro libro = new ML.Libro();

                        libro.IdLibro = obj.IdLibro;
                        libro.Nombre = obj.Nombre;

                        libro.Autor = new ML.Autor();
                        libro.Autor.IdAutor = obj.IdAutor;
                        libro.Autor.Nombre = obj.Nombre;

                        libro.NumeroPaginas = obj.NumeroPaginas.Value;
                        libro.FechaPublicacion = obj.FechaPublicacion.ToString();

                        libro.Editorial = new ML.Editorial();
                        libro.Editorial.IdEditorial = obj.IdEditorial;
                        libro.Editorial.Nombre = obj.Nombre;

                        libro.Edicion = obj.Edicion;

                        libro.Genero = new ML.Genero();
                        libro.Genero.IdGenero = obj.IdGenero;
                        libro.Genero.Nombre = obj.Nombre;

                        

                        result.Object = libro;
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




