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

        //Constructor
        public EmpresasController() { }


        //Métodos Paquetes Entierro
        public DataTable CargarEncargadoEmpresa_Controller(string codigoEmpresa)
        {
            return ModelEmpresa.CargarEncargadoEmpresa(codigoEmpresa);
        }
        public static DataTable CargarEncargado_Controller()
        {
            return ModelEmpresa.CargarEncargado();
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
            return ModelEmpresa.AgregarEmpresa(Nombre, RazonSocial, Informacion, Direccion, Telefono, Correo, CodigoEnc, CodigoCat);
        }
        public bool ActualizarEmpresa()
        {
            return ModelEmpresa.ActualizarEmpresa(codigoEmpresa , Nombre, RazonSocial, Informacion, Direccion, Telefono, Correo, CodigoEnc, CodigoCat);
        }
        public bool EliminarEmpresa()
        {
            return ModelEmpresa.EliminarEmpresa(codigoEmpresa,CodigoEnc);
        }
    }
}
