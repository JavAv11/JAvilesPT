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
                                libro.NumeroPaginas = dataRow[3].ToString();
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
                            libro.NumeroPaginas = dataRow[3].ToString();
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
    }
}




