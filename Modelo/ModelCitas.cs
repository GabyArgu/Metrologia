﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Contracts;

namespace Modelo
{
    public class ModelCitas
    {
        public static DataTable CargarEstado()
        {
            DataTable data;
            try
            {
                string query = "SELECT CodigoEstadoCi, Nombre FROM EstadoCita";
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
        public static DataTable CargarEncargado(int codigoEmpresa)
        {
            DataTable data;
            try
            {
                string query = "SELECT CodigoEncargado, Nombre FROM Encargado WHERE CodigoEstadoEn = 1 AND CodigoEmpresa = @empresa";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("empresa", codigoEmpresa));
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

        public static DataTable CargarEmpresa()
        {
            DataTable data;
            try
            {
                string query = "SELECT CodigoEmpresa,Nombre FROM Empresas WHERE CodigoEstadoE = 1";
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
        public static DataTable CargarEmpresa(string Empresa)
        {
            DataTable data;
            try
            {
                string query = "SELECT CodigoEmpresa FROM Empresas WHERE Nombre= @empresa";
                SqlCommand cmdselect = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdselect.Parameters.Add(new SqlParameter("empresa", Empresa));
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
        public static DataTable CargarCitas()
        {
            DataTable retorno;
            string query = "SELECT Ci.CodigoCita AS Código, En.Nombre AS Encargado," +
                " Empr.Nombre AS Empresa, TS.Nombre AS Servicio, " +
                " Ci.FechaCita AS Fecha, Ci.Comentarios, Ci.HoraCita AS Hora, Esci.Nombre AS Estado FROM Cita Ci " +
                "INNER JOIN Encargado En ON Ci.CodigoEncargado = En.CodigoEncargado " +
                "LEFT JOIN Servicio Se ON Ci.CodigoServicio = Se.CodigoServicio " +
                "INNER JOIN Empresas Empr ON Ci.CodigoEmpresa = Empr.CodigoEmpresa " +
                "INNER JOIN EstadoCita Esci ON Ci.CodigoEstadoCi = Esci.CodigoEstadoCi " +
                "LEFT JOIN TipoServicio TS ON Se.CodigoTipo = TS.CodigoTipo";
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
        public static bool AgregarCita(string Comentarios, DateTime Fecha, DateTime Hora, int Encargado, int Empresa, int EstadoCi)
        {
            bool retorno;
            try
            {
                string query = "INSERT INTO Cita (CodigoEncargado, CodigoEmpresa, CodigoEstadoCi, FechaCita, Comentarios, HoraCita) VALUES ( @codigoEn, @codigoEm, @codigoEstado, @fecha, @comentario, @hora)";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("codigoEn", Encargado));
                cmdinsert.Parameters.Add(new SqlParameter("codigoEm", Empresa));
                cmdinsert.Parameters.Add(new SqlParameter("codigoEstado", EstadoCi));
                cmdinsert.Parameters.Add(new SqlParameter("fecha", Fecha));
                cmdinsert.Parameters.Add(new SqlParameter("comentario", Comentarios));
                cmdinsert.Parameters.Add(new SqlParameter("hora", Hora));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno;
            }
            catch (Exception ex)
            {
                return retorno = false;
            }

        }
        public static bool ActualizaCita(string CodigoCita, string Comentarios, DateTime Fecha, DateTime Hora, int Encargado, int Empresa, int EstadoCi)
        {
            bool retorno;
            try
            {
                string query = "UPDATE Cita SET CodigoEncargado = @codigoEn,CodigoEmpresa = @codigoEm," +
                    "CodigoEstadoCi = @codigoEstadoCi,FechaCita = @fecha,Comentarios = @comentarios,HoraCita = @hora WHERE CodigoCita =@codigoCi";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("codigoCi", CodigoCita));
                cmdinsert.Parameters.Add(new SqlParameter("codigoEn", Encargado));
                cmdinsert.Parameters.Add(new SqlParameter("codigoEm", Empresa));
                cmdinsert.Parameters.Add(new SqlParameter("codigoEstadoCi", EstadoCi));
                cmdinsert.Parameters.Add(new SqlParameter("fecha", Fecha));
                cmdinsert.Parameters.Add(new SqlParameter("comentarios", Comentarios));
                cmdinsert.Parameters.Add(new SqlParameter("hora", Hora));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno = true;
            }
            catch (Exception)
            {
                return retorno = false;
            }
        }
        public static bool EliminarCitas(string CodigoCita, int EstadoCi)
        {
            bool retorno;
            try
            {
                string query = "UPDATE Cita SET CodigoEstadoCi = @codigoEstadoCi WHERE CodigoCita =@codigoCi ";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("codigoCi", CodigoCita));
                cmdinsert.Parameters.Add(new SqlParameter("codigoEstadoCi", EstadoCi));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno = true;
            }
            catch (Exception)
            {
                return retorno = false;
            }
        }
        public static bool servicioCitas(string CodigoCita, int codigoServicio)
        {
            bool retorno;
            try
            {
                string query = "UPDATE Cita SET CodigoServicio = @codigoSer WHERE CodigoCita =@codigoCi ";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("codigoCi", CodigoCita));
                cmdinsert.Parameters.Add(new SqlParameter("codigoSer", codigoServicio));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno = true;
            }
            catch (Exception)
            {
                return retorno = false;
            }
        }
        public static bool citasServicio(string CodigoCita, int codigoServicio)
        {
            bool retorno;
            try
            {
                string query = "UPDATE Servicio SET CodigoCita = @codigoCi WHERE CodigoServicio = @codigoSer ";
                SqlCommand cmdinsert = new SqlCommand(string.Format(query), Conexion.getConnect());
                cmdinsert.Parameters.Add(new SqlParameter("codigoCi", CodigoCita));
                cmdinsert.Parameters.Add(new SqlParameter("codigoSer", codigoServicio));
                retorno = Convert.ToBoolean(cmdinsert.ExecuteNonQuery());
                return retorno = true;
            }
            catch (Exception)
            {
                return retorno = false;
            }
        }
        public static DataTable BuscarCita(string Busqueda)
        {
            DataTable retorno;
            string query = "SELECT * FROM CargarCitas WHERE Encargado LIKE @Busqueda OR Empresa LIKE @Busqueda OR Servicio LIKE @Busqueda OR Estado LIKE @Busqueda";
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
