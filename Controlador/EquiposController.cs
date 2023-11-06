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
    public class EquiposController
    {
        public static SqlConnection Connect_Controller()
        {
            return Conexion.getConnect();
        }
        //Atributos tb_Acta_Defuncion
        public string codigoEquipos { get; set; }
        public string Nombre { get; set; }
        public int codigoUbicacion { get; set; }        

        //Constructor
        public EquiposController() { }


        //Métodos Paquetes Entierro
        public static DataTable CargarEquipos_Controller()
        {
            return ModelEquipos.CargarEquipos();
        }
        public DataTable CargarUbicacion_Controller(string Laboratorio, string Ubicacion)
        {
            return ModelEquipos.CargarUbicacion(Laboratorio, Ubicacion);
        }
        public static DataTable CargarUbicacion()
        {
            return ModelEquipos.CargarUbicacion();
        }
        public bool AgregarEquipo()
        {
            return ModelEquipos.AgregarEquipo(Nombre, codigoUbicacion);
        }
        public bool ActualizarEquipo()
        {
            return ModelEquipos.ActualizaEquipo(codigoEquipos, Nombre, codigoUbicacion);
        }
        public bool EliminarEquipo()
        {
            return ModelEquipos.EliminarEquipo(codigoEquipos);
        }
    }
}
