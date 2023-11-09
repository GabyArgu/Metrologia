using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Contracts;

namespace Modelo
{
    public class ModelUbicacion
    {
        public static DataTable CargarUbicacion()
        {
            DataTable retorno;
            string query = "SELECT CodigoUbicacion AS Código, Laboratorio, Ubicacion FROM UbicacionEquipos";
            try
            {
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                SqlDataAdapter adp = new SqlDataAdapter(cmdselect);
                retorno = new DataTable();
                adp.Fill(retorno);
                return retorno;
            }
            catch (Exception)
            {

                return retorno = null;
            }

            finally
            {
                Conexion.getConnect().Close();
            }
        }
        public static bool AgregarUbicacion(string Laboratorio, string Ubicacion)
        {
            bool retorno;
            try
            {
                string query = "INSERT INTO UbicacionEquipos ( Laboratorio, Ubicacion) VALUES ( @laboratorio, @ubicacion)";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("laboratorio", Laboratorio));
                cmdinsert.Parameters.Add(new SqlParameter("ubicacion", Ubicacion));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno;
            }
            catch (Exception ex)
            {
                return retorno = false;
            }

        }
        public static bool ActualizaUbicacion(string CodigoUbicacion, string Laboratorio, string Ubicacion)
        {
            bool retorno;
            try
            {
                string query = "UPDATE UbicacionEquipos SET Laboratorio = @laboratorio, Ubicacion = @ubicacion WHERE CodigoUbicacion =@codigoU";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("codigoU", CodigoUbicacion));
                cmdinsert.Parameters.Add(new SqlParameter("laboratorio", Laboratorio));
                cmdinsert.Parameters.Add(new SqlParameter("ubicacion", Ubicacion));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno = true;
            }
            catch (Exception)
            {
                return retorno = false;
            }
        }
        public static bool EliminarUbicacion(string CodigoUbicacion)
        {
            bool retorno;
            try
            {
                string query = "DELETE UbicacionEquipos WHERE CodigoUbicacion = @codigoU";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("codigoU", CodigoUbicacion));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno = true;
            }
            catch (Exception)
            {
                return retorno = false;
            }
        }

        public static DataTable BuscarUbicacion(string Busqueda)
        {
            DataTable retorno;
            string query = "SELECT * FROM CargarUbicacion WHERE Laboratorio LIKE @Busqueda OR Ubicacion LIKE @Busqueda";
            try
            {
                SqlCommand cmdsearch = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdsearch.Parameters.Add(new SqlParameter("Busqueda", "%" + Busqueda + "%"));
                SqlDataAdapter adp = new SqlDataAdapter(cmdsearch);
                retorno = new DataTable();
                adp.Fill(retorno);
                return retorno;
            }
            catch (Exception)
            {

                return retorno = null;
            }

            finally
            {
                Conexion.getConnect().Close();
            }
        }
    }
}
