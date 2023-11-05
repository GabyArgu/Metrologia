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
    public class ModelUsuario
    {
        //Métodos para Agregar Nuevo Usuario
        public static DataTable CargarEstado()
        {
            DataTable data;
            try
            {
                string query = "SELECT * FROM EstadoEmpleado";
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
        public static DataTable CargarCargo()
        {
            DataTable data;
            try
            {
                string query = "SELECT * FROM CargoEmpleado";
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
        public static DataTable CargarCargoEmpleado(string codigoEmpleado)
        {
            DataTable data;
            try
            {
                string query = "SELECT CE.CodigoCargo FROM CargoEmpleado CE , Empleado E WHERE CE.CodigoCargo=E.CodigoCargo AND E.CodigoEmpleado = @codigoe";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("codigoe", codigoEmpleado));
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
        public static DataTable CargarEstadoEmpleado(string codigoEmpleado)
        {
            DataTable data;
            try
            {
                string query = "SELECT EE.CodigoEstadoEm FROM EstadoEmpleado EE , Empleado E WHERE EE.CodigoEstadoEm=E.CodigoEstadoEm AND E.CodigoEmpleado = @codigoe";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("codigoe", codigoEmpleado));
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
        //Cargar DataGridView
        public static DataTable CargarUsuarios()
        {
            DataTable retorno;
            string query = "SELECT E.CodigoEmpleado,E.Usuario,E.Nombre,E.Apellido,E.Correo,E.Telefono,CE.Nombre AS Cargo, EE.Nombre AS Estado FROM Empleado E, EstadoEmpleado EE, CargoEmpleado CE WHERE E.CodigoEstadoEm=EE.CodigoEstadoEm AND E.CodigoCargo=CE.CodigoCargo";
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
        public static bool AgregarUsuario( string Nombre, string Apellido, string Correo, string Telefono, string Username, string ContraUser, int CargoE, int EstadoE)
        {
            bool retorno;
            try
            {
                string query = "INSERT INTO [dbo].[Empleado] ([Nombre],[Apellido],[Correo],[Telefono],[Usuario],[Contrasena],[CodigoCargo],[CodigoEstadoEm]) VALUES (@nombre,@apellido,@correo,@telefono,@username,@contra,@cargo,@estado)";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("nombre", Nombre));
                cmdinsert.Parameters.Add(new SqlParameter("apellido", Apellido));
                cmdinsert.Parameters.Add(new SqlParameter("correo", Correo));
                cmdinsert.Parameters.Add(new SqlParameter("telefono", Telefono));
                cmdinsert.Parameters.Add(new SqlParameter("username", Username));
                cmdinsert.Parameters.Add(new SqlParameter("contra", ContraUser));
                cmdinsert.Parameters.Add(new SqlParameter("cargo", CargoE));
                cmdinsert.Parameters.Add(new SqlParameter("estado", EstadoE));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno;
            }
            catch (Exception ex)
            {
                return retorno = false;
            }

        }
        public static bool ActualizaUsuario(string CodigoEmpleado, string Nombre, string Apellido, string Correo, string Telefono, string Username, int CargoE, int EstadoE)
        {
            bool retorno;
            try
            {
                string query = "UPDATE [dbo].[Empleado] SET [CodigoCargo] = @cargo ,[CodigoEstadoEm] = @estado ,[Nombre] = @nombre ,[Apellido] = @apellido ,[Correo] = @correo ,[Telefono] = @telefono ,[Usuario] = @username WHERE [CodigoEmpleado] = @codigoe   ";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("codigoe", CodigoEmpleado));
                cmdinsert.Parameters.Add(new SqlParameter("nombre", Nombre));
                cmdinsert.Parameters.Add(new SqlParameter("apellido", Apellido));
                cmdinsert.Parameters.Add(new SqlParameter("correo", Correo));
                cmdinsert.Parameters.Add(new SqlParameter("telefono", Telefono));
                cmdinsert.Parameters.Add(new SqlParameter("username", Username));
                cmdinsert.Parameters.Add(new SqlParameter("cargo", CargoE));
                cmdinsert.Parameters.Add(new SqlParameter("estado", EstadoE));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno = true;
            }
            catch (Exception)
            {
                return retorno = false;
            }
        }
        public static bool EliminarUsuario(string CodigoEmpleado, int EstadoE)
        {
            bool retorno;
            try
            {
                string query = "UPDATE [dbo].[Empleado] SET [CodigoEstadoEm] = @estado WHERE [CodigoEmpleado] = @codigoe   ";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("codigoe", CodigoEmpleado));
                cmdinsert.Parameters.Add(new SqlParameter("estado", EstadoE));
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
