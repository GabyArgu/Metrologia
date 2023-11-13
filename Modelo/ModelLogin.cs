using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Modelo
{
    public class ModelLogin
    {
        //Comprobar credenciales de Login
        public static bool Acceso(string Username, string txt2)
        {
            bool retorno = false;
            try
            {
                string query = "SELECT COUNT(Usuario) FROM Empleado WHERE Usuario = @usua AND Contrasena = @contra";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("usua", Username));
                cmdselect.Parameters.Add(new SqlParameter("contra", txt2));
                retorno = Convert.ToBoolean(cmdselect.ExecuteScalar());
                return retorno;
            }
            catch (Exception)
            {
                return retorno;
            }
            finally
            {
                Conexion.getConnect().Close();
            }
        }
        //
        public static DataTable nivelUser(string User, string txt1)
        {
            DataTable data;
            try
            {
                string query = "SELECT E.CodigoCargo, CE.Nombre FROM Empleado E " +
                               "INNER JOIN CargoEmpleado CE ON E.CodigoCargo = CE.CodigoCargo " +
                               "WHERE E.Usuario = @usua AND E.Contrasena = @contra";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("usua", User));
                cmdselect.Parameters.Add(new SqlParameter("contra", txt1));
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
        public static DataTable estadoUser(string User, string txt1)
        {
            DataTable data;
            try
            {
                string query = "SELECT E.CodigoEstadoEm, EE.Nombre FROM Empleado E " +                               
                               "INNER JOIN EstadoEmpleado EE ON E.CodigoEstadoEm = EE.CodigoEstadoEm " +
                               "WHERE E.Usuario = @usua AND E.Contrasena = @contra";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("usua", User));
                cmdselect.Parameters.Add(new SqlParameter("contra", txt1));
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
    }
}
