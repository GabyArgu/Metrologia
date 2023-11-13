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
    public class ModelEmpresa
    {
        public static bool AgregarEmpresa(string Nombre, string RazonSocial, string Informacion, string Direccion, string Telefono, string Correo, int CodigoCat, int EstadoE)
        {
            bool retorno;
            try
            {
                string query = "INSERT INTO [dbo].[Empresas] ([Nombre],[RazonSocial],[Informacion],[Direccion],[Telefono],[Correo],[CodigoCategoria], [CodigoEstadoE]) VALUES (@nombre,@razonsocial,@informacion,@direccion,@telefono,@correo,@categoria ,@estado)";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("nombre", Nombre));
                cmdinsert.Parameters.Add(new SqlParameter("razonsocial", RazonSocial));
                cmdinsert.Parameters.Add(new SqlParameter("informacion", Informacion));
                cmdinsert.Parameters.Add(new SqlParameter("direccion", Direccion));
                cmdinsert.Parameters.Add(new SqlParameter("telefono", Telefono));
                cmdinsert.Parameters.Add(new SqlParameter("correo", Correo));
                cmdinsert.Parameters.Add(new SqlParameter("categoria", CodigoCat));
                cmdinsert.Parameters.Add(new SqlParameter("estado", EstadoE));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno;
            }
            catch (Exception ex)
            {
                return retorno = false;
            }
        }

        public static bool ActualizarEmpresa(string CodigoEmpresa, string Nombre, string RazonSocial, string Informacion, string Direccion, string Telefono, string Correo, int CodigoEnc, int CodigoCat, int EstadoE)
        {
            bool retorno;
            try
            {
                string query = "UPDATE [dbo].[Empresas] SET [CodigoEncargado] = @encargado ,[CodigoCategoria] = @categoria ,[Nombre] = @nombre ,[RazonSocial] = @razonsocial, [Informacion] = @informacion, [Direccion] = @direccion, [Telefono] = @telefono , [Correo] = @correo, [CodigoEstadoE] = @estado WHERE [CodigoEmpresa] = @codigoemp  ";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("codigoemp", CodigoEmpresa));
                cmdinsert.Parameters.Add(new SqlParameter("nombre", Nombre));
                cmdinsert.Parameters.Add(new SqlParameter("razonsocial", RazonSocial));
                cmdinsert.Parameters.Add(new SqlParameter("informacion", Informacion));
                cmdinsert.Parameters.Add(new SqlParameter("direccion", Direccion));
                cmdinsert.Parameters.Add(new SqlParameter("telefono", Telefono));
                cmdinsert.Parameters.Add(new SqlParameter("correo", Correo));
                cmdinsert.Parameters.Add(new SqlParameter("encargado", CodigoEnc));
                cmdinsert.Parameters.Add(new SqlParameter("categoria", CodigoCat));
                cmdinsert.Parameters.Add(new SqlParameter("estado", EstadoE));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno = true;
            }
            catch (Exception)
            {
                return retorno = false;
            }
        }


        public static bool EliminarEmpresa(string CodigoEmpresa, int EstadoE)
        {
            bool retorno;
            try
            {
                string query = "UPDATE [dbo].[Empresas] SET [CodigoEstadoE] = @estadoE WHERE [CodigoEmpresa] = @codigoemp";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("codigoemp", CodigoEmpresa));
                cmdinsert.Parameters.Add(new SqlParameter("estadoE", EstadoE));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno = true;
            }
            catch (Exception)
            {
                return retorno = false;
            }
        }

        //Métodos para Agregar Nueva Empresa
        public static DataTable CargarEncargado(string codigoEmpresa)
        {
            DataTable data;
            try
            {
                string query = "SELECT EC.CodigoEncargado, EC.Nombre FROM Encargado EC WHERE EC.CodigoEstadoEn = 1 AND EC.CodigoEmpresa  =  @codigoemp";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("codigoemp", codigoEmpresa));
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
        public static DataTable CargarCategoria()
        {
            DataTable data;
            try
            {
                string query = "SELECT * FROM CategoriaEmpresa";
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

        public static DataTable CargarEstadoEM(string codigoEmpresa)
        {
            DataTable data;
            try
            {
                string query = "SELECT * FROM EstadoEmpresa";
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
      
        public static DataTable CargarCategoriaEmpresa(string codigoEmpresa)
        {
            DataTable data;
            try
            {
                string query = "SELECT CE.CodigoCategoria, CE.Nombre FROM CategoriaEmpresa CE , Empresas E WHERE CE.CodigoCategoria = E.CodigoCategoria AND E.CodigoEmpresa = @codigoemp";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("codigoemp", codigoEmpresa));
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

        public static DataTable CargarEmpresas()
        {
            DataTable retorno;
            string query = "SELECT E.CodigoEmpresa AS Codigo, E.Nombre AS Empresa, E.RazonSocial, " +
                "E.Informacion, E.Direccion, E.Telefono, E.Correo, EC.Nombre AS Encargado, CE.Nombre AS Categoria, " +
                "EE.Nombre AS Estado FROM Empresas E " +
                "LEFT JOIN Encargado EC ON E.CodigoEncargado = EC.CodigoEncargado " +
                "INNER JOIN CategoriaEmpresa CE ON E.CodigoCategoria = CE.CodigoCategoria " +
                "LEFT JOIN EstadoEmpresa EE ON E.CodigoEstadoE = EE.CodigoEstadoE";
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

        public static DataTable BuscarEmpresa(string Busqueda)
        {
            DataTable retorno;
            string query = "SELECT * FROM CargarEmpresa WHERE Empresa LIKE @Busqueda OR Categoria LIKE @Busqueda OR Estado LIKE @Busqueda";
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
