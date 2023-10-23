using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Metrologia.Controller
{
    class ModelUsuario:Conexion
    {
        private string codigoEmpleado;
        private string usuario;
        private string contrasena;
        private string nombre;
        private string apellido;
        private string correo;
        private string telefono;
        private int cargoEmpleado;
        private int estadoEmpleado;

        public string CodigoEmpleado
        {
            get { return codigoEmpleado; }
            set { codigoEmpleado = value; }
        }
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public int CargoEmpleado
        {
            get { return cargoEmpleado; }
            set { cargoEmpleado = value; }
        }
        public int EstadoEmpleado
        {
            get { return estadoEmpleado; }
            set { estadoEmpleado = value; }
        }


        public bool Login()
        {
            try
            {
                using (var conection = establecerConexion()) 
                {
                    conection.Open();
                    using (var comand = new SqlCommand())
                    {
                    
                        string query = "SELECT Usuario, Contrasena FROM Empleado WHERE Usuario = @usua AND Contrasena = @contra";
                        comand.Connection = conection;
                        comand.Parameters.AddWithValue("usua", Usuario);
                        comand.Parameters.AddWithValue("contra", Contrasena);
                        comand.CommandText = query;
                        comand.CommandType = CommandType.Text;
                        SqlDataReader reader = comand.ExecuteReader();
                        if (reader.HasRows)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexion: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
