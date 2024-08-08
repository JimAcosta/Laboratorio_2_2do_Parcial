using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class AccesoDatos
    {
        private static readonly SqlConnection sqlConnection;
        private static readonly SqlCommand command;

        static AccesoDatos()
        {
            sqlConnection = new SqlConnection("Server=.;Database=20240701-SP;Trusted_Connection=True;");
            command = new SqlCommand { Connection = sqlConnection };
        }

        public static List<Serie> ObtenerBacklog()
        {
            List<Serie> backlog = new List<Serie>();

            try
            {
                sqlConnection.Open();
                command.CommandText = "SELECT * FROM Series";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombre = reader["Nombre"].ToString();
                        string genero = reader["Genero"].ToString();
                        backlog.Add(new Serie(nombre, genero));
                    }
                }
            }
            catch (SqlException ex)
            {
                Logger.Log($"Error al obtener el backlog: {ex.Message}");
                throw new BackLogException("Error al obtener el backlog de series.", ex);
            }
            finally
            {
                sqlConnection.Close();
            }

            return backlog;
        }
        public static void ActualizarSerie(Serie serie)
        {
            try
            {
                sqlConnection.Open();
                command.CommandText = "UPDATE Series SET Alumno = @Alumno WHERE Nombre = @Nombre";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Alumno", "NombreDelAlumno");
                command.Parameters.AddWithValue("@Nombre", serie.Nombre);

                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Logger.Log($"Error al actualizar la serie '{serie.Nombre}': {ex.Message}");
                throw new BackLogException($"Error al actualizar la serie '{serie.Nombre}'.", ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        
    }
}
