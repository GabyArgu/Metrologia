using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;

namespace Metrologia
{
    public partial class Empresas : Form
    {
        Dashboard dash = (Dashboard)formularios.DashboardFRM;

        public Empresas()
        {
            InitializeComponent();
            cargarEncargado();
            cargarCategoria();
            cargarEstadoEM();
        }

        void cargarEncargado()
        {
            cbEncargado.DataSource = EmpresasController.CargarEncargado_Controller();
            cbEncargado.DisplayMember = "Nombre";
            cbEncargado.ValueMember = "CodigoEncargado";
        }

        void cargarCategoria()
        {
            cbCategoria.DataSource = EmpresasController.CargarCategoria_Controller();
            cbCategoria.DisplayMember = "Nombre";
            cbCategoria.ValueMember = "CodigoCategoria";
        }

        void cargarEstadoEM()
        {
            cbEstadoE.DataSource = UsuarioController.CargarEstado_Controller();
            cbEstadoE.DisplayMember = "Nombre";
            cbEstadoE.ValueMember = "CodigoEstadoEm";
        }

        public void ocultarCodigo()
        {
            pnlCodigoEmpresa.Visible = false;
            txtCodigoEmpresa.Visible = false;
        }

        public void mostrarCodigo()
        {
            pnlCodigoEmpresa.Visible = true;
            txtCodigoEmpresa.Visible = true;
        }

        void agregarEmpresa()
        {
            EmpresasController empresacontrol = new EmpresasController();

            empresacontrol.Nombre = txtNombreEmpresa.Text;
            empresacontrol.RazonSocial = txtRazonSocial.Text;
            empresacontrol.Informacion = txtInformacion.Text;
            empresacontrol.Direccion = txtDireccion.Text;
            empresacontrol.Telefono = txtTelefono.Text;
            empresacontrol.Correo = txtCorreo.Text;
            empresacontrol.CodigoEnc = Convert.ToInt16(cbEncargado.SelectedValue);
            empresacontrol.CodigoCat = Convert.ToInt16(cbCategoria.SelectedValue);
            empresacontrol.EstadoE = Convert.ToInt16(cbEstadoE.SelectedValue);

            if (empresacontrol.AgregarEmpresa() == true)
            {

                MessageBox.Show("Empresa agregada con exito");
                this.Hide();
                dash.CargarDatosEmpresa();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al agregar empresa");
            }
        }

        void modificarEmpresa()
        {
            EmpresasController empresacontrol = new EmpresasController();

            empresacontrol.codigoEmpresa = txtCodigoEmpresa.Text;
            empresacontrol.Nombre = txtNombreEmpresa.Text;
            empresacontrol.RazonSocial = txtRazonSocial.Text;
            empresacontrol.Informacion = txtInformacion.Text;
            empresacontrol.Direccion = txtDireccion.Text;
            empresacontrol.Telefono = txtTelefono.Text;
            empresacontrol.Correo = txtCorreo.Text;
            empresacontrol.CodigoEnc = Convert.ToInt16(cbEncargado.SelectedValue);
            empresacontrol.CodigoCat = Convert.ToInt16(cbCategoria.SelectedValue);
            empresacontrol.EstadoE = Convert.ToInt16(cbEstadoE.SelectedValue);

            if (empresacontrol.ActualizarEmpresa() == true)
            {
                MessageBox.Show("Empresa actualizada con exito");
                this.Hide();
                dash.CargarDatosEmpresa();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al actualizar empresa");
            }
        }

        public void llenarModal(string codigoEmpresa, string nombre, string razonsocial, string informacion, string direccion, string telefono, string correo, string codigoenc, string codigocat, string EstadoE)
        {
            EmpresasController objselect = new EmpresasController();

            txtCodigoEmpresa.Text = codigoEmpresa;
            txtNombreEmpresa.Text = nombre;
            txtRazonSocial.Text = razonsocial;
            txtInformacion.Text = informacion;
            txtDireccion.Text = direccion;
            txtTelefono.Text = telefono;
            txtCorreo.Text = correo;

            cargarEncargado();
            DataTable codigoE = objselect.CargarEncargadoEmpresa_Controller(codigoEmpresa);
            object valorE = codigoE.Rows[0]["CodigoEncargado"];
            cbEncargado.SelectedIndex = int.Parse(valorE.ToString()) - 1;

            cargarCategoria();
            DataTable codigoC = objselect.CargarCategoriaEmpresa_Controller(codigoEmpresa);
            object valorC = codigoC.Rows[0]["CodigoCategoria"];
            cbCategoria.SelectedIndex = int.Parse(valorC.ToString()) - 1;

            cargarEstadoEM();
            DataTable codigoEstado = objselect.CargarEstadoEM_Controller(codigoEmpresa);
            object valorEstado = codigoEstado.Rows[0]["CodigoEstadoE"];
            cbEstadoE.SelectedIndex = int.Parse(valorEstado.ToString()) - 1;
        }

        public void eliminarEmpresa(string codigoEmpresa)
        {
            EmpresasController empresacontrol = new EmpresasController();

            empresacontrol.codigoEmpresa = codigoEmpresa;

            if (empresacontrol.EliminarEmpresa() == true)
            {
                MessageBox.Show("Empresa se eliminó con exito");
                dash.CargarDatosEmpresa();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al eliminar empresa");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCodigoEmpresa.Visible == true) modificarEmpresa();
            else agregarEmpresa();
        }
    }
}
