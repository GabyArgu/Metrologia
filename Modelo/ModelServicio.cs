using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Contracts;
using System.Reflection.Emit;

namespace Modelo
{
    public class ModelServicio
    {
        public static DataTable CargarArea()
        {
            DataTable data;
            try
            {
                string query = "SELECT CodigoArea, Nombre FROM AreaMetrologia";
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
        public static DataTable CargarTipoSer()
        {
            DataTable data;
            try
            {
                string query = "SELECT CodigoTipo,Nombre FROM TipoServicio ORDER BY CodigoTipo";
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
        public static DataTable CargarEstadoSer()
        {
            DataTable data;
            try
            {
                string query = "SELECT CodigoEstadoSe,Nombre FROM EstadoServicio";
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
        public static DataTable CargarEstado(string EstadoCi)
        {
            DataTable data;
            try
            {
                string query = "SELECT CodigoEstadoCi FROM EstadoCita WHERE Nombre= @estadoCi";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("estadoCi", EstadoCi));
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
        public static DataTable CargarEncargado(string Encargado)
        {
            DataTable data;
            try
            {
                string query = "SELECT CodigoEncargado FROM Encargado WHERE Nombre= @encargado";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("encargado", Encargado));
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
        public static DataTable CargarServicio(string CodigoC)
        {
            DataTable data;
            try
            {
                string query = "SELECT Ser.CodigoServicio,Ser.CodigoTipo, TSer.Nombre AS NombreTipoServicio, Ser.CodigoArea, Ser.CodigoEmpleado, " +
                    "Ser.CodigoEstadoSe, Ser.Precio, Ser.FechaEntrega, Ser.HoraEntrega, Ser.Comentarios " +
                    "FROM Servicio Ser, TipoServicio TSer, AreaMetrologia AM, Empleado Emp, EstadoServicio ESer " +
                    "WHERE Ser.CodigoTipo = TSer.CodigoTipo AND Ser.CodigoArea = AM.CodigoArea " +
                    "AND Ser.CodigoEmpleado = Emp.CodigoEmpleado AND Ser.CodigoEstadoSe = ESer.CodigoEstadoSe AND Ser.CodigoCita = @codigoC";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("codigoC", CodigoC));
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
        public static bool AgregarServicio(string Precio, string Comentarios, string Fecha, string Hora, int Area, int Empleado, int TipoSer, int EstadoSer)
        {
            bool retorno;
            try
            {
                string query = "INSERT INTO Servicio (Precio, Comentarios, FechaEntrega, HoraEntrega, CodigoArea, CodigoEmpleado, CodigoTipo, CodigoEstadoSe) VALUES ( @precio, @comentario, @fecha, @hora, @codigoA, @codigoE, @codigoTS, @codigoES)";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("precio", Precio));
                cmdinsert.Parameters.Add(new SqlParameter("comentario", Comentarios));
                cmdinsert.Parameters.Add(new SqlParameter("fecha", Fecha));
                cmdinsert.Parameters.Add(new SqlParameter("hora", Hora));
                cmdinsert.Parameters.Add(new SqlParameter("codigoA", Area));
                cmdinsert.Parameters.Add(new SqlParameter("codigoE", Empleado));
                cmdinsert.Parameters.Add(new SqlParameter("codigoTS", TipoSer));
                cmdinsert.Parameters.Add(new SqlParameter("codigoES", EstadoSer));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno;
            }
            catch (Exception ex)
            {
                return retorno = false;
            }

        }
        public static bool ActualizaServicio(string CodigoServicio, string Precio, string Comentarios, string Fecha, string Hora, int Area, int Empleado, int TipoSer, int EstadoSer)
        {
            bool retorno;
            try
            {
                string query = "UPDATE Servicio SET CodigoArea = @codigoA, CodigoEmpleado = @codigoE, CodigoTipo = @codigoTS, CodigoEstadoSe = @codigoES, Precio = @precio, FechaEntrega = @fecha, HoraEntrega = @hora, Comentarios = @comentarios WHERE CodigoServicio =@codigoSer";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("codigoSer", CodigoServicio));
                cmdinsert.Parameters.Add(new SqlParameter("codigoA", Area));
                cmdinsert.Parameters.Add(new SqlParameter("codigoE", Empleado));
                cmdinsert.Parameters.Add(new SqlParameter("codigoTS", TipoSer));
                cmdinsert.Parameters.Add(new SqlParameter("codigoES", EstadoSer));
                cmdinsert.Parameters.Add(new SqlParameter("precio", Precio));
                cmdinsert.Parameters.Add(new SqlParameter("fecha", Fecha));
                cmdinsert.Parameters.Add(new SqlParameter("hora", Hora));
                cmdinsert.Parameters.Add(new SqlParameter("comentarios", Comentarios));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno = true;
            }
            catch (Exception)
            {
                return retorno = false;
            }
        }
        public static DataTable obtenerServicio()
        {
            DataTable data;
            try
            {
                string query = "SELECT MAX(CodigoServicio) AS UltimoID FROM Servicio";
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

        public static DateTime GetFechaCita(int IdCita)
        {
            try
            {
                string query = "SELECT FechaCita FROM Cita WHERE CodigoCita = @IdCita";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("IdCita", IdCita));
                SqlDataReader data = cmdselect.ExecuteReader();
                if (data.Read())
                {
                    return (DateTime)data["FechaCita"];
                }
                return DateTime.Now;
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
            finally
            {
                Conexion.getConnect().Close();
            }
        }
    }
}
