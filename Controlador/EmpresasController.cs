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
    public class EmpresasController
    {
        public static SqlConnection Connect_Controller()
        {
            return Conexion.getConnect();
        }
        //Atributos tb_Acta_Defuncion
        public string codigoEmpresa { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
        public string Informacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int CodigoEnc { get; set; }
        public int CodigoCat { get; set; }
        public int EstadoE { get; set; }

        //Constructor
        public EmpresasController() { }


        //Métodos Paquetes Entierro
        public  DataTable CargarEstadoEM_Controller(string codigoEmpresa)
        {
            return ModelEmpresa.CargarEstadoEM(codigoEmpresa);
        }        
        public static DataTable CargarEncargado_Controller(string codigoEmpresa)
        {
            return ModelEmpresa.CargarEncargado(codigoEmpresa);
        }
        public DataTable CargarCategoriaEmpresa_Controller(string codigoEmpresa)
        {
            return ModelEmpresa.CargarCategoriaEmpresa(codigoEmpresa);
        }
        public static DataTable CargarCategoria_Controller()
        {
            return ModelEmpresa.CargarCategoria();
        }        
        public static DataTable CargarEmpresas_Controller()
        {
            return ModelEmpresa.CargarEmpresas();
        }
        public bool AgregarEmpresa()
        {
            return ModelEmpresa.AgregarEmpresa(Nombre, RazonSocial, Informacion, Direccion, Telefono, Correo, CodigoCat, EstadoE);
        }
        public bool ActualizarEmpresa()
        {
            return ModelEmpresa.ActualizarEmpresa(codigoEmpresa , Nombre, RazonSocial, Informacion, Direccion, Telefono, Correo, CodigoEnc, CodigoCat, EstadoE);
        }
        public bool EliminarEmpresa()
        {
            return ModelEmpresa.EliminarEmpresa(codigoEmpresa, EstadoE);
        }

        public static DataTable BuscarEmpresa(string Busqueda)
        {
            return ModelEmpresa.BuscarEmpresa(Busqueda);
        }
    }
}
