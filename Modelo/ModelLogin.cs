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
        public static List<string> ObtenerDatos(string Usuario)
        {
            List<string> datos = null;
            try
            {
                string query = "SELECT * FROM tb_usuario tu, tb_tipo_usuario ttu WHERE tu.Nombre_Usuario = BINARY ?param1 AND tu.Id_Tipo_Usuario = ttu.Id_Tipo_Usuario";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("param1", Usuario));
                SqlDataReader reader = cmdselect.ExecuteReader();
                while (reader.Read())
                {
                    datos = new List<string>();
                    datos.Add(reader.GetString(4));
                    datos.Add(reader.GetString(16));
                }
                return datos;
            }
            catch (Exception)
            {
                return datos;
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



        //Registro de Usuario Root en Primer Uso de Sistema
        public static DataTable CargarTiposUsuarios()
        {
            DataTable data;
            try
            {
                string query = "SELECT * FROM tb_tipo_usuario WHERE Tipo_Usuario = 'Root';";
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
        public static DataTable CargarFunerarias()
        {
            DataTable data;
            try
            {
                string query = "SELECT * FROM tb_funeraria";
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
        public static bool registrarUsuarioRoot(string Nombres, string Apellidos, string DUI, string User, string Contra_user, int Tipo_User, int Funeraria, string R1, string R2, string R3)
        {
            bool retorno;
            try
            {
                SqlCommand cmdinsert = new SqlCommand(string.Format("INSERT INTO tb_usuario (Nombres, Apellidos, DUI, Nombre_Usuario, Contra_Usuario, Id_Tipo_Usuario, Id_Funeraria, Nombre_Secundaria, Color_Favorito, Animal_Favorito) VALUES ('{0}', '{1}', '{2}' , '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", 
                    Nombres, Apellidos, DUI, User, Contra_user, Tipo_User, Funeraria, R1, R2, R3), Conexion.getConnect());
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno;
            }
            catch (Exception)
            {

                return retorno = false;
            }

        }





        //Métodos Cambio de contraseña.
        public static DataTable CargarCodigosAdmin()
        {
            DataTable data;
            try
            {
                string query = "SELECT Nombre_Usuario, Codigo FROM tb_usuario WHERE Id_Tipo_Usuario=2";
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
        public static bool ActualizarContra(string Nombre_U, string Contra_Usuario)
        {
            bool retorno;

            try
            {
                SqlCommand cmdinsert = new SqlCommand(string.Format("UPDATE tb_usuario SET Contra_Usuario = '" + Contra_Usuario + "' where Nombre_Usuario = BINARY '" + Nombre_U + "' "), Conexion.getConnect());
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno;
            }
            catch (Exception)
            {
                return retorno = false;
            }
            finally
            {
                Conexion.getConnect().Close();
            }
        }


        //Preguntas
        public static bool AccesoPreguntas(string secundaria, string color, string animal, string usuario)
        {
            bool retorno;
            try
            {
                string query = "SELECT * FROM tb_usuario WHERE Nombre_Secundaria = binary ?param1 AND Color_Favorito = binary ?param2 AND Animal_Favorito = binary ?param3 AND Nombre_Usuario = binary ?param4";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("param1", secundaria));
                cmdselect.Parameters.Add(new SqlParameter("param2", color));
                cmdselect.Parameters.Add(new SqlParameter("param3", animal));
                cmdselect.Parameters.Add(new SqlParameter("param4", usuario));
                retorno = Convert.ToBoolean(cmdselect.ExecuteScalar());
                return retorno;
            }
            catch (Exception)
            {
                return retorno = false;
            }
        }

    }
}
