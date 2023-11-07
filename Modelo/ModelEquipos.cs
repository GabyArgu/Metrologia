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
    public class ModelEquipos
    {
        public static DataTable CargarEquipos()
        {
            DataTable retorno;
            string query = "SELECT E.CodigoEquipos AS Código, E.Nombre, UE.Laboratorio, UE.Ubicacion FROM Equipos E, UbicacionEquipos UE WHERE E.CodigoUbicacion=UE.CodigoUbicacion";
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
        public static DataTable CargarUbicacion()
        {
            DataTable data;
            try
            {
                string query = "SELECT CodigoUbicacion,Laboratorio+' '+Ubicacion AS Nombre FROM UbicacionEquipos";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                SqlDataAdapter adp = new SqlDataAdapter(cmdselect);
                data = new DataTable();
                adp.Fill(data);
                return data;
            }
            catch (Exception)
            {
                return data = null;
            }
            finally
            {
                Conexion.getConnect().Close();
            }
        }
        public static DataTable CargarUbicacion(string Laboratorio, string Ubicacion)
        {
            DataTable data;
            try
            {
                string query = "SELECT CodigoUbicacion ,Laboratorio+' '+Ubicacion AS Nombre FROM UbicacionEquipos WHERE Laboratorio = @laboratorio AND Ubicacion = @ubicacion";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("laboratorio", Laboratorio));
                cmdselect.Parameters.Add(new SqlParameter("ubicacion", Ubicacion));
                SqlDataAdapter adp = new SqlDataAdapter(cmdselect);
                data = new DataTable();
                adp.Fill(data);
                return data;
            }
            catch (Exception)
            {
                return data = null;
            }
            finally
            {
                Conexion.getConnect().Close();
            }
        }
        public static bool AgregarEquipo(string Nombre, int codigoUbicacion)
        {
            bool retorno;
            try
            {
                string query = "INSERT INTO Equipos ( Nombre, CodigoUbicacion) VALUES ( @nombre, @ubicacion)";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("nombre", Nombre));
                cmdinsert.Parameters.Add(new SqlParameter("ubicacion", codigoUbicacion));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno;
            }
            catch (Exception ex)
            {
                return retorno = false;
            }

        }
        public static bool ActualizaEquipo(string CodigoEquipos, string Nombre, int codigoUbicacion)
        {
            bool retorno;
            try
            {
                string query = "UPDATE Equipos SET Nombre = @nombre, CodigoUbicacion = @ubicacion WHERE CodigoEquipos = @codigoE";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("codigoE", CodigoEquipos));
                cmdinsert.Parameters.Add(new SqlParameter("nombre", Nombre));
                cmdinsert.Parameters.Add(new SqlParameter("ubicacion", codigoUbicacion));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno = true;
            }
            catch (Exception)
            {
                return retorno = false;
            }
        }
        public static bool EliminarEquipo(string CodigoEquipos)
        {
            bool retorno;
            try
            {
                string query = "DELETE Equipos WHERE CodigoEquipos = @codigoE";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("codigoE", CodigoEquipos));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno = true;
            }
            catch (Exception)
            {
                return retorno = false;
            }
        }
    }
}
