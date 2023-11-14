using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Contracts;
using System.Reflection;

namespace Modelo
{
    public class ModelRevision
    {
        public static DataTable CargarEstado()
        {
            DataTable data;
            try
            {
                string query = "SELECT CodigoEstadoRev, Nombre FROM EstadoRevision";
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
        public static DataTable CargarEquipo()
        {
            DataTable data;
            try
            {
                string query = "SELECT CodigoEquipos,Nombre FROM Equipos";
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
        public static DataTable CargarEmpleado(string username, string txt2)
        {
            DataTable data;
            try
            {
                string query = "SELECT CodigoEmpleado,Nombre+' '+Apellido AS Nombre FROM Empleado WHERE Usuario = @user AND Contrasena = @txt";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("user", username));
                cmdselect.Parameters.Add(new SqlParameter("txt", txt2));
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
        public static DataTable CargarMotivoRev()
        {
            DataTable data;
            try
            {
                string query = "SELECT CodigoMotivo, Nombre FROM MotivoRevision";
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
        public static DataTable CargarEquipo(string Equipo)
        {
            DataTable data;
            try
            {
                string query = "SELECT CodigoEquipos FROM Equipos WHERE Nombre= @equipo";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("equipo", Equipo));
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
        public static DataTable CargarEmpleado(string Empleado)
        {
            DataTable data;
            try
            {
                string query = "SELECT CodigoEmpleado FROM Empleado WHERE Nombre+' '+Apellido = @empleado";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("empleado", Empleado));
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
        public static DataTable CargarMotivo(string Motivo)
        {
            DataTable data;
            try
            {
                string query = "SELECT CodigoMotivo FROM MotivoRevision WHERE Nombre= @motivo";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("motivo", Motivo));
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
        public static DataTable CargarEstado(string EstadoR)
        {
            DataTable data;
            try
            {
                string query = "SELECT CodigoEstadoRev FROM EstadoRevision WHERE Nombre= @estadoR";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("estadoR", EstadoR));
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
        public static DataTable CargarRevision()
        {
            DataTable retorno;
            string query = "SELECT R.CodigoRevision,Eq.Nombre AS Equipo,Emp.Nombre+' '+Emp.Apellido AS Empleado,MoR.Nombre " +
                "AS MotivoRevision, R.Comentarios,R.Fecha, EstR.Nombre AS Estado FROM Revisiones R " +
                "INNER JOIN Equipos Eq ON R.CodigoEquipo = Eq.CodigoEquipos " +
                "INNER JOIN Empleado Emp ON R.CodigoEmpleado = Emp.CodigoEmpleado " +
                "INNER JOIN MotivoRevision MoR ON R.CodigoMotivo = MoR.CodigoMotivo " +
                "INNER JOIN EstadoRevision EstR ON R.CodigoEstadoRev = EstR.CodigoEstadoRev";
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
        public static bool AgregarRevision(string Comentario, DateTime Fecha, int CodigoEq, int CodigoEm, int CodigoMo, int CodigoEstR)
        {
            bool retorno;
            try
            {
                string query = "INSERT INTO Revisiones ( Comentarios, Fecha, CodigoEquipo, CodigoEmpleado, CodigoMotivo, CodigoEstadoRev) VALUES ( @comentarios, @fecha, @coidgoEq, @codigoEm, @codigoM, @codigoEstRev)";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("comentarios", Comentario));
                cmdinsert.Parameters.Add(new SqlParameter("fecha", Fecha));
                cmdinsert.Parameters.Add(new SqlParameter("coidgoEq", CodigoEq));
                cmdinsert.Parameters.Add(new SqlParameter("codigoEm", CodigoEm));
                cmdinsert.Parameters.Add(new SqlParameter("codigoM", CodigoMo));
                cmdinsert.Parameters.Add(new SqlParameter("codigoEstRev", CodigoEstR));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno;
            }
            catch (Exception ex)
            {
                return retorno = false;
            }

        }
        public static bool ActualizaRevision(string CodigoRevision, string Comentario, DateTime Fecha, int CodigoEq, int CodigoEm, int CodigoMo, int CodigoEstR)
        {
            bool retorno;
            try
            {
                string query = "UPDATE Revisiones SET Comentarios = @comentario, Fecha = @fecha, CodigoEquipo = @coidgoEq , CodigoEmpleado = @codigoEm , CodigoMotivo = @codigoM , CodigoEstadoRev = @codigoEstRev WHERE CodigoRevision = @codigoR";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("codigoR", CodigoRevision));
                cmdinsert.Parameters.Add(new SqlParameter("comentario", Comentario));
                cmdinsert.Parameters.Add(new SqlParameter("fecha", Fecha));
                cmdinsert.Parameters.Add(new SqlParameter("coidgoEq", CodigoEq));
                cmdinsert.Parameters.Add(new SqlParameter("codigoEm", CodigoEm));
                cmdinsert.Parameters.Add(new SqlParameter("codigoM", CodigoMo));
                cmdinsert.Parameters.Add(new SqlParameter("codigoEstRev", CodigoEstR));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno = true;
            }
            catch (Exception)
            {
                return retorno = false;
            }
        }
        public static bool EliminarRevision(string CodigoRevision, int CodigoEstR)
        {
            bool retorno;
            try
            {
                string query = "UPDATE Revisiones SET CodigoEstadoRev = @codigoEstRev WHERE CodigoRevision = @codigoR";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("codigoR", CodigoRevision));
                cmdinsert.Parameters.Add(new SqlParameter("codigoEstRev", CodigoEstR));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno = true;
            }
            catch (Exception)
            {
                return retorno = false;
            }
        }

        public static DataTable BuscarRevision(string Busqueda)
        {
            DataTable retorno;
            string query = "SELECT * FROM CargarRevisiones WHERE Empleado LIKE @Busqueda OR Estado LIKE @Busqueda OR Equipo LIKE @Busqueda";
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
