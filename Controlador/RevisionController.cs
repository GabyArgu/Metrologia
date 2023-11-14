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
    public class RevisionController
    {
        public static SqlConnection Connect_Controller()
        {
            return Conexion.getConnect();
        }
        //Atributos tb_Acta_Defuncion
        public string codigoRevision { get; set; }
        public string comentario { get; set; }
        public DateTime fecha { get; set; }
        public int equipo { get; set; }
        public int empleado { get; set; }
        public int motivo { get; set; }
        public int estado { get; set; }

        //Constructor
        public RevisionController() { }


        //Métodos Paquetes Entierro
        public static DataTable CargarRevision_Controller()
        {
            return ModelRevision.CargarRevision();
        }
        public static DataTable CargarEmpleado_Controller(string user, string txt2)
        {
            return ModelRevision.CargarEmpleado(user, txt2);
        }
        public static DataTable CargarEquipo_Controller()
        {
            return ModelRevision.CargarEquipo();
        }
        public static DataTable CargarMotivo_Controller()
        {
            return ModelRevision.CargarMotivoRev();
        }
        public static DataTable CargarEstado_Controller()
        {
            return ModelRevision.CargarEstado();
        }
        public DataTable CargarEquipo_Controller(string Equipo)
        {
            return ModelRevision.CargarEquipo(Equipo);
        }
        public DataTable CargarEmpleado_Controller(string Empleado)
        {
            return ModelRevision.CargarEmpleado(Empleado);
        }

        public DataTable CargarMotivo_Controller(string Motivo)
        {
            return ModelRevision.CargarMotivo(Motivo);
        }
        public DataTable CargarEstadoR_Controller(string EstadoR)
        {
            return ModelRevision.CargarEstado(EstadoR);
        }
        public bool AgregarRevision()
        {
            return ModelRevision.AgregarRevision(comentario, fecha, equipo, empleado, motivo, estado);
        }
        public bool ActualizarRevision()
        {
            return ModelRevision.ActualizaRevision(codigoRevision, comentario, fecha, equipo, empleado, motivo, estado);
        }
        public bool EliminarRevision()
        {
            return ModelRevision.EliminarRevision(codigoRevision, estado);
        }

        public static DataTable BuscarRevision(string Busqueda)
        {
            return ModelRevision.BuscarRevision(Busqueda);
        }
    }
}
