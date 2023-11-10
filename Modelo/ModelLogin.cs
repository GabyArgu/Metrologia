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




        //Verificar Pimer Uso del Sistema
        public static int ObtenerFunerarias()
        {
            int retorno;
            string query = "SELECT * FROM tb_funeraria";
            try
            {
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                retorno = Convert.ToInt16(cmdselect.ExecuteScalar());
                return retorno;
            }
            catch (Exception)
            {
                return retorno = -1;
            }
        }
        public static int ObtenerUsuarios()
        {
            int retorno;
            string query = "SELECT * FROM tb_usuario";
            try
            {
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                retorno = Convert.ToInt16(cmdselect.ExecuteScalar());
                return retorno;
            }
            catch (Exception)
            {
                return retorno = -1;
            }
        }



        //Registro de Funeraria en Primer Uso de Sistema
        public static bool registrarFuneraria(string NombreFuneraria, string Registro, string Telefono, string CorreoElectronico, string Direccion, string Representante, string NIT)
        {
            bool retorno;
            try
            {
                SqlCommand cmdinsert = new SqlCommand(string.Format("INSERT INTO tb_funeraria (Nombre_Funeraria, N°_Registro, Num_Telefono, Correo_Electronico, Direccion, Representante_Legal, NIT) VALUES ('{0}', '{1}', '{2}' , '{3}', '{4}', '{5}', '{6}')", NombreFuneraria, Registro, Telefono, CorreoElectronico, Direccion, Representante, NIT), Conexion.getConnect());
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno;
            }
            catch (Exception)
            {

                return retorno = false;
            }

        }
    }
}
