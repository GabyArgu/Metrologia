using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        Dashboard dash = (Dashboard)formularios.DashboardFRM;

        public Encargados()
        {
            InitializeComponent();
            cargarEmpresa();
            cargarCargo();
            cargarEstado();
            dtpFecha.Value = DateTime.Now;
            // Asocia el evento Validating con el control DateTimePicker
            dtpFecha.Validating += dtpFecha_Validating;
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
            pnlCodigoEncargado.Enabled = false;
            txtCodigoEncargado.Enabled = false;
        }

        public void mostrarCodigo()
        {
            pnlCodigoEncargado.Enabled = true;
            txtCodigoEncargado.Enabled = true;
        }

        private void dtpFecha_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DateTime selectedDate = dtpFecha.Value;
            DateTime currentDate = DateTime.Now;

            // Verifica si la fecha seleccionada es igual o posterior a la fecha actual
            if (selectedDate >= currentDate)
            {
                // Muestra un mensaje de error
                MessageBox.Show("Selecciona una fecha anterior a la fecha actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; // Cancela la validación
            }
        }

        void agregarEncargado()
        {
            EncargadosController encargadocontrol = new EncargadosController();

            encargadocontrol.Nombre = txtNombreEncargado.Text;
            DateTime fechas = dtpFecha.Value;
            encargadocontrol.Fecha = fechas;
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

            encargadocontrol.codigoEncargado = txtCodigoEncargado.Text;
            encargadocontrol.Nombre = txtNombreEncargado.Text;
            DateTime fechas = dtpFecha.Value;
            encargadocontrol.Fecha = fechas;
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

        public void EliminarEncargado(string codigoEncargado)
        {
            EncargadosController encargadocontrol = new EncargadosController();

            encargadocontrol.codigoEncargado = codigoEncargado;
            encargadocontrol.CodEstEn = 2;

            if (encargadocontrol.EliminarEncargado() == true)
            {
                MessageBox.Show("Encargado se eliminó con exito");
                dash.CargarDatosEncargado();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al eliminar Encargado");
            }
        }

        public void llenarModal(string codigoEncargado, string nombre, DateTime fecha, string codemp, string codcar, string codesten)
        {
            
            EncargadosController objselect = new EncargadosController();

            txtCodigoEncargado.Text = codigoEncargado;
            txtNombreEncargado.Text = nombre;

            dtpFecha.Value = fecha;

            cargarEmpresa();
            DataTable codigoEmpresa = objselect.CargarEmpresaEncargado_Controller(codigoEncargado);
            object valorEmpresa = codigoEmpresa.Rows[0]["CodigoEmpresa"];
            cbEmpresa.SelectedIndex = int.Parse(valorEmpresa.ToString()) - 1;

            cargarCargo();
            DataTable codigoCargo = objselect.CargarCargoEncargado_Controller(codigoEncargado);
            object valorCargo = codigoCargo.Rows[0]["CodigoCargo"];
            cbCargo.SelectedIndex = int.Parse(valorCargo.ToString()) - 1;

            cargarEstado();
            DataTable codigoEstado = objselect.CargarEstadoEncargado_Controller(codigoEncargado);
            object valorEstado = codigoEstado.Rows[0]["CodigoEstadoEn"];
            cbEstado.SelectedIndex = int.Parse(valorEstado.ToString()) - 1;
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
            if (txtCodigoEncargado.Enabled == true) modificarEncargado();
            else agregarEncargado();
        }

        //Validaciones
        private void txtSoloLetras(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 'A' && e.KeyChar <= 'Z') ||  // Letras mayúsculas
                (e.KeyChar >= 'a' && e.KeyChar <= 'z') || // Letras minúsculas
                (e.KeyChar == 'á' || e.KeyChar == 'é' || e.KeyChar == 'í' || e.KeyChar == 'ó' || e.KeyChar == 'ú' || // Letras con tildes
                    e.KeyChar == 'Á' || e.KeyChar == 'É' || e.KeyChar == 'Í' || e.KeyChar == 'Ó' || e.KeyChar == 'Ú' || // Letras mayúsculas con tildes
                    e.KeyChar == ' ' || e.KeyChar == (char)Keys.Back))) // Espacio en blanco o tecla "Borrar"
            {
                // Validación de caracteres no permitidos
                MessageBox.Show("Solo se aceptan letras, letras con tildes y espacios en blanco", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
