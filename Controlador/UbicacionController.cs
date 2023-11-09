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
    public class UbicacionController
    {
        public static SqlConnection Connect_Controller()
        {
            return Conexion.getConnect();
        }
        //Atributos tb_Acta_Defuncion
        public string codigoUbicacion { get; set; }
        public string Laboratorio { get; set; }
        public string Ubicacion { get; set; }        

        //Constructor
        public UbicacionController() { }


        //Métodos Paquetes Entierro
        public static DataTable CargarUbicacion_Controller()
        {
            return ModelUbicacion.CargarUbicacion();
        }
        public bool AgregarUbicacion()
        {
            return ModelUbicacion.AgregarUbicacion(Laboratorio, Ubicacion);
        }
        public bool ActualizarUbicacion()
        {
            return ModelUbicacion.ActualizaUbicacion(codigoUbicacion,Laboratorio,Ubicacion);
        }
        public bool EliminarUbicacion()
        {
            return ModelUbicacion.EliminarUbicacion(codigoUbicacion);
        }

        public static DataTable BuscarUbicacion(string Busqueda)
        {
            return ModelUbicacion.BuscarUbicacion(Busqueda);
        }
    }
}
