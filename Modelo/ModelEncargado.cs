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
    public class ModelEncargado
    {
        //Métodos para Agregar Nuevo Encargado

        public static DataTable CargarEmpresa()
        {
            DataTable data;
            try
            {
                string query = "SELECT * FROM Empresas";
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

        public static DataTable CargarEstado()
        {
            DataTable data;
            try
            {
                string query = "SELECT * FROM EstadoEncargado";
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
                string query = "SELECT * FROM CargoEncargado";
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

        public static DataTable CargarEmpresaEncargado(string codigoEncargado)
        {
            DataTable data;
            try
            {
                string query = "SELECT Em.CodigoEmpresa, Em.Nombre FROM Empresas Em , Encargado E WHERE Em.CodigoEmpresa=E.CodigoEmpresa AND E.CodigoEncargado = @codigoencargado";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("codigoencargado", codigoEncargado));
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

        public static DataTable CargarCargoEncargado(string codigoEncargado)
        {
            DataTable data;
            try
            {
                string query = "SELECT CE.CodigoCargo, CE.Nombre FROM CargoEncargado CE , Encargado E WHERE CE.CodigoCargo=E.CodigoCargo AND E.CodigoEncargado = @codigoencargado";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("codigoencargado", codigoEncargado));
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
        public static DataTable CargarEstadoEncargado(string codigoEncargado)
        {
            DataTable data;
            try
            {
                string query = "SELECT EE.CodigoEstadoEn, EE.Nombre FROM EstadoEncargado EE , Encargado E WHERE EE.CodigoEstadoEn= E.CodigoEstadoEn AND E.CodigoEncargado = @codigoencargado";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("codigoencargado", codigoEncargado));
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
        public static DataTable CargarEncargados()
        {
            DataTable retorno;
            string query = "SELECT E.CodigoEncargado AS Codigo, Em.Nombre AS Empresa, CE.Nombre AS Cargo, " +
                           " E.Nombre, E.FechaContratado , EE.Nombre AS Estado FROM Encargado E " +
                           "JOIN Empresas Em ON E.CodigoEmpresa = Em.CodigoEmpresa " +
                           "JOIN CargoEncargado CE ON E.CodigoCargo = CE.CodigoCargo " +
                           "JOIN EstadoEncargado EE ON E.CodigoEstadoEn = EE.CodigoEstadoEn";
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
        public static bool AgregarEncargado( string Nombre, DateTime Fecha, int CodEmp, int CodCar, int CodEstEn)
        {
            bool retorno;
            try
            {
                string query = "INSERT INTO [dbo].[Encargado] ([Nombre],[FechaContratado],[CodigoEmpresa],[CodigoCargo],[CodigoEstadoEn]) VALUES (@nombre,@fecha,@codemp,@codcar,@codesten)";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("nombre", Nombre));
                cmdinsert.Parameters.Add(new SqlParameter("fecha", Fecha));
                cmdinsert.Parameters.Add(new SqlParameter("codemp", CodEmp));
                cmdinsert.Parameters.Add(new SqlParameter("codcar", CodCar));
                cmdinsert.Parameters.Add(new SqlParameter("codesten", CodEstEn));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno;
            }
            catch (Exception ex)
            {
                return retorno = false;
            }

        }
        public static bool ActualizarEncargado(string CodigoEncargado, string Nombre, DateTime Fecha, int CodEmp, int CodCar, int CodEstEn)
        {
            bool retorno;
            try
            {
                string query = "UPDATE Encargado SET CodigoEmpresa = @codemp ,CodigoCargo = @codcar , " +
                    "CodigoEstadoEn = @codesten ,Nombre = @nombre ,FechaContratado = @fecha WHERE CodigoEncargado = @codigoencargado";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("codigoencargado", CodigoEncargado));
                cmdinsert.Parameters.Add(new SqlParameter("nombre", Nombre));
                cmdinsert.Parameters.Add(new SqlParameter("fecha", Fecha));
                cmdinsert.Parameters.Add(new SqlParameter("codemp", CodEmp));
                cmdinsert.Parameters.Add(new SqlParameter("codcar", CodCar));
                cmdinsert.Parameters.Add(new SqlParameter("codesten", CodEstEn));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno = true;
            }
            catch (Exception)
            {
                return retorno = false;
            }
        }
        public static bool EliminarEncargado(string codigoEncargado, int CodEstEn)
        {
            bool retorno;
            try
            {
                string query = "UPDATE [dbo].[Encargado] SET [CodigoEstadoEn] = @codesten WHERE [CodigoEncargado] = @codigoencargado   ";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("codigoencargado", codigoEncargado));
                cmdinsert.Parameters.Add(new SqlParameter("codesten", CodEstEn));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno = true;
            }
            catch (Exception)
            {
                return retorno = false;
            }
        }

        public static DataTable BuscarEncargado(string Busqueda)
        {
            DataTable retorno;
            string query = "SELECT * FROM CargarEncargados WHERE Nombre LIKE @Busqueda OR Estado LIKE @Busqueda OR Empresa LIKE @Busqueda";
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
