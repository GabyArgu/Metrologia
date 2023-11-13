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
    public class CitasController
    {
        public static SqlConnection Connect_Controller()
        {
            return Conexion.getConnect();
        }
        //Atributos tb_Acta_Defuncion
        public string codigoCita { get; set; }
        public string Comentarios { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public int Encargado { get; set; }
        public int Empresa { get; set; }
        public int Servicio { get; set; }
        public int EstadoCi { get; set; }        

        //Constructor
        public CitasController() { }


        //Métodos Paquetes Entierro
        public DataTable CargarEstado_Controller(string EstadoCi)
        {
            return ModelCitas.CargarEstado(EstadoCi);
        }
        public static DataTable CargarEstado_Controller()
        {
            return ModelCitas.CargarEstado();
        }
        public DataTable CargarEncargado_Controller(string Encargado)
        {
            return ModelCitas.CargarEncargado(Encargado);
        }
        public static DataTable CargarEncargado_Controller(int codigoEmpresa)
        {
            return ModelCitas.CargarEncargado(codigoEmpresa);
        }

        public DataTable CargarEmpresa_Controller(string Empresa)
        {
            return ModelCitas.CargarEmpresa(Empresa);
        }
        public static DataTable CargarEmpresa_Controller()
        {
            return ModelCitas.CargarEmpresa();
        }
        public static DataTable CargarCitas_Controller()
        {
            return ModelCitas.CargarCitas();
        }
        public bool AgregarCita()
        {
            return ModelCitas.AgregarCita(Comentarios, Fecha, Hora, Encargado, Empresa, EstadoCi);
        }
        public bool ActualizarCita()
        {
            return ModelCitas.ActualizaCita(codigoCita, Comentarios, Fecha, Hora, Encargado, Empresa, EstadoCi);
        }
        public bool EliminarCitas()
        {
            return ModelCitas.EliminarCitas(codigoCita, EstadoCi);
        }
        public bool servicioCitas()
        {
            return ModelCitas.servicioCitas(codigoCita, Servicio);
        }
        public bool citasServicio()
        {
            return ModelCitas.citasServicio(codigoCita, Servicio);
        }
        public static DataTable BuscarCita(string Busqueda)
        {
            return ModelCitas.BuscarCita(Busqueda);
        }
    }
}
