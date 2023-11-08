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
    public class EncargadosController
    {
        public static SqlConnection Connect_Controller()
        {
            return Conexion.getConnect();
        }
        //Atributos tb_Acta_Defuncion
        public string codigoEncargado { get; set; }
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public int CodEmp { get; set; }
        public int CodCar { get; set; }
        public int CodEstEn { get; set; }

        //Constructor
        public EncargadosController() { }


        //Métodos Paquetes Entierro
        public DataTable CargarEmpresaEncargado_Controller(string CodEmp)
        {
            return ModelEncargado.CargarEmpresaEncargado(CodEmp);
        }
        public static DataTable CargarEmpresa_Controller()
        {
            return ModelEncargado.CargarEmpresa();
        }
        public DataTable CargarCargoEncargado_Controller(string codigoEncargado)
        {
            return ModelEncargado.CargarCargoEncargado(codigoEncargado);
        }
        public static DataTable CargarCargo_Controller()
        {
            return ModelEncargado.CargarCargo();
        }
        public DataTable CargarEstadoEncargado_Controller(string codigoEncargado)
        {
            return ModelEncargado.CargarEstadoEncargado(codigoEncargado);
        }
        public static DataTable CargarEstado_Controller()
        {
            return ModelEncargado.CargarEstado();
        }
        public static DataTable CargarEncargados_Controller()
        {
            return ModelEncargado.CargarEncargados();
        }
        public bool AgregarEncargado()
        {
            return ModelEncargado.AgregarEncargado(Nombre, Fecha, CodEmp, CodCar, CodEstEn);
        }
        public bool ActualizarEncargado()
        {
            return ModelEncargado.ActualizarEncargado(codigoEncargado , Nombre, Fecha, CodEmp, CodCar, CodEstEn);
        }
        public bool EliminarEncargado()
        {
            return ModelEncargado.EliminarEncargado(codigoEncargado, CodEstEn);
        }
    }
}
