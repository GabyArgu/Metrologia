using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Modelo;
using System.Data;

namespace Controlador
{
    public class UsuarioController
    {
        public static SqlConnection Connect_Controller()
        {
            return Conexion.getConnect();
        }
        //Atributos tb_Acta_Defuncion
        public string codigoEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Username { get; set; }
        public string ContraUser { get; set; }
        public int CargoE { get; set; }
        public int EstadoE { get; set; }        

        //Constructor
        public UsuarioController() { }


        //Métodos Paquetes Entierro
        public DataTable CargarEstadoEmpleado_Controller(string codigoEmpleado)
        {
            return ModelUsuario.CargarEstadoEmpleado(codigoEmpleado);
        }
        public static DataTable CargarEstado_Controller()
        {
            return ModelUsuario.CargarEstado();
        }
        public DataTable CargarCargoEmpleado_Controller(string codigoEmpleado)
        {
            return ModelUsuario.CargarCargoEmpleado(codigoEmpleado);
        }
        public static DataTable CargarCargos_Controller()
        {
            return ModelUsuario.CargarCargo();
        }        
        public static DataTable CargarUsuarios_Controller()
        {
            return ModelUsuario.CargarUsuarios();
        }
        public bool AgregarUsuario()
        {
            return ModelUsuario.AgregarUsuario(Nombre, Apellido, Correo, Telefono, Username, ContraUser, CargoE, EstadoE);
        }
        public bool ActualizarUsuario()
        {
            return ModelUsuario.ActualizaUsuario(codigoEmpleado, Nombre, Apellido, Correo, Telefono, Username, CargoE, EstadoE);
        }
        public bool EliminarUsuario()
        {
            return ModelUsuario.EliminarUsuario(codigoEmpleado,EstadoE);
        }
    }
}
