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
        Dashboard dash = new Dashboard();

        public Empresas()
        {
            InitializeComponent();
            cargarEncargado();
            cargarCategoria();
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

            empresacontrol.Nombre = txtNombreEmpresa.Text;
            empresacontrol.RazonSocial = txtRazonSocial.Text;
            empresacontrol.Informacion = txtInformacion.Text;
            empresacontrol.Direccion = txtDireccion.Text;
            empresacontrol.Telefono = txtTelefono.Text;
            empresacontrol.Correo = txtCorreo.Text;
            empresacontrol.CodigoEnc = Convert.ToInt16(cbEncargado.SelectedValue);
            empresacontrol.CodigoCat = Convert.ToInt16(cbCategoria.SelectedValue);

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

        public void llenarModal(string codigoEmpresa, string nombre, string razonsocial, string informacion, string direccion, string telefono, string correo, string codigoenc, string codigocat)
        {
            EmpresasController objselect = new EmpresasController();

            txtCodigoEmpresa.Text = codigoEmpresa;
            txtNombreEmpresa.Text = nombre;
            txtRazonSocial.Text = razonsocial;
            txtInformacion.Text = informacion;
            txtCorreo.Text = correo;
            txtTelefono.Text = telefono;
            txtDireccion.Text = direccion;

            cbEncargado.DataSource = objselect.CargarEncargadoEmpresa_Controller(codigoEmpresa);
            cbEncargado.DisplayMember = "Nombre";
            cbEncargado.ValueMember = "CodigoEncargado";

            cbCategoria.DataSource = objselect.CargarCategoriaEmpresa_Controller(codigoEmpresa);
            cbCategoria.DisplayMember = "Nombre";
            cbCategoria.ValueMember = "CodigoCategoria";
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
