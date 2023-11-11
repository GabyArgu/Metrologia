using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class ServicioController
    {
        public static SqlConnection Connect_Controller()
        {
            return Conexion.getConnect();
        }
        //Atributos tb_Acta_Defuncion
        public string codigoServicio { get; set; }
        public string Precio { get; set; }
        public string Comentarios { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public int Area { get; set; }
        public int Empleado { get; set; }
        public int TipoSer { get; set; }
        public int EstadoSer { get; set; }

        //Constructor
        public ServicioController() { }


        //Métodos Paquetes Entierro
        public static DataTable CargarArea_Controller()
        {
            return ModelServicio.CargarArea();
        }
        public static DataTable CargarEmpleado_Controller()
        {
            return ModelServicio.CargarEmpleado();
        }
        public DataTable CargarModal_Controller(string CodigoC)
        {
            return ModelServicio.CargarServicio(CodigoC);
        }
        public static DataTable CargarTipoSer_Controller()
        {
            return ModelServicio.CargarTipoSer();
        }
        public static DataTable CargarEstadoSer_Controller()
        {
            return ModelServicio.CargarEstadoSer();
        }
        public bool AgregarServicio()
        {
            return ModelServicio.AgregarServicio(Precio,Comentarios, Fecha, Hora, Area, Empleado, TipoSer, EstadoSer);
        }
        public bool ActualizarServicio()
        {
            return ModelServicio.ActualizaServicio(codigoServicio, Precio, Comentarios, Fecha, Hora, Area, Empleado, TipoSer, EstadoSer);
        }
        public static DataTable obtenerServicio()
        {
            return ModelServicio.obtenerServicio();
        }

        public static DateTime GetFechaCita(int IdCita)
        {
            return ModelServicio.GetFechaCita(IdCita);
        }
    }
}
