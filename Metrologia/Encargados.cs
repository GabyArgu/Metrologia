using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;

namespace Metrologia
{
    public partial class Encargados : Form
    {
        Dashboard dash = new Dashboard();

        public Encargados()
        {
            InitializeComponent();
            cargarEmpresa();
            cargarCargo();
            cargarEstado();
        }

        void cargarEmpresa()
        {
            cbEmpresa.DataSource = EncargadosController.CargarEmpresa_Controller();
            cbEmpresa.DisplayMember = "Nombre";
            cbEmpresa.ValueMember = "CodigoEmpresa";
        }

        void cargarCargo()
        {
            cbCargo.DataSource = EncargadosController.CargarCargo_Controller();
            cbCargo.DisplayMember = "Nombre";
            cbCargo.ValueMember = "CodigoCargo";
        }

        void cargarEstado()
        {
            cbEstado.DataSource = EncargadosController.CargarEstado_Controller();
            cbEstado.DisplayMember = "Nombre";
            cbEstado.ValueMember = "CodigoEstadoEn";
        }

        public void ocultarCodigo()
        {
            pnlCodigoEncargado.Visible = false;
            txtCodigoEncargado.Visible = false;
        }

        public void mostrarCodigo()
        {
            pnlCodigoEncargado.Visible = true;
            txtCodigoEncargado.Visible = true;
        }

        void agregarEncargado()
        {
            EncargadosController encargadocontrol = new EncargadosController();

            encargadocontrol.Nombre = txtNombreEncargado.Text;
            encargadocontrol.Fecha = dtpFecha.Value;
            encargadocontrol.CodEmp = Convert.ToInt16(cbEmpresa.SelectedValue);
            encargadocontrol.CodCar = Convert.ToInt16(cbCargo.SelectedValue);
            encargadocontrol.CodEstEn = Convert.ToInt16(cbEstado.SelectedValue);

            if (encargadocontrol.AgregarEncargado() == true)
            {

                MessageBox.Show("Encargado agregado con exito");
                this.Hide();
                dash.CargarDatosEncargado();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al agregar encargado");
            }
        }

        void modificarEncargado()
        {
            EncargadosController encargadocontrol = new EncargadosController();

            encargadocontrol.Nombre = txtNombreEncargado.Text;
            encargadocontrol.Fecha = dtpFecha.Value;
            encargadocontrol.CodEmp = Convert.ToInt16(cbEmpresa.SelectedValue);
            encargadocontrol.CodCar = Convert.ToInt16(cbCargo.SelectedValue);
            encargadocontrol.CodEstEn = Convert.ToInt16(cbEstado.SelectedValue);

            if (encargadocontrol.ActualizarEncargado() == true)
            {
                MessageBox.Show("Encargado actualizado con exito");
                this.Hide();
                dash.CargarDatosEncargado();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al actualizar encargado");
            }
        }

        public void llenarModal(string codigoEncargado, string nombre, DateTime fecha, string codemp, string codcar, string codesten)
        {
            EncargadosController objselect = new EncargadosController();

            txtCodigoEncargado.Text = codigoEncargado;
            txtNombreEncargado.Text = nombre;
            dtpFecha.Value = fecha;

            cbEmpresa.DataSource = objselect.CargarEmpresaEncargado_Controller(codigoEncargado);
            cbEmpresa.DisplayMember = "Nombre";
            cbEmpresa.ValueMember = "CodigoEmpresa";

            cbCargo.DataSource = objselect.CargarCargoEncargado_Controller(codigoEncargado);
            cbCargo.DisplayMember = "Nombre";
            cbCargo.ValueMember = "CodigoCargo";

            cbEstado.DataSource = objselect.CargarEstadoEncargado_Controller(codigoEncargado);
            cbEstado.DisplayMember = "Nombre";
            cbEstado.ValueMember = "CodigoEstadoEn";
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
            if (txtCodigoEncargado.Visible == true) modificarEncargado();
            else agregarEncargado();
        }

    }
}
