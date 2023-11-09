using Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metrologia
{
    public partial class Equipos : Form
    {
        Dashboard dash = (Dashboard)formularios.DashboardFRM;
        public Equipos()
        {
            InitializeComponent();
            cargarUbicacion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        void cargarUbicacion()
        {
            cbUbicacion.DataSource = EquiposController.CargarUbicacion();
            cbUbicacion.DisplayMember = "Nombre";
            cbUbicacion.ValueMember = "CodigoUbicacion";
        }
        public void ocultarCodigo()
        {
            pnlCodigoEquipo.Visible = false;
            txtCodigoEquipo.Visible = false;
        }

        public void mostrarCodigo()
        {
            pnlCodigoEquipo.Visible = true;
            txtCodigoEquipo.Visible = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCodigoEquipo.Visible == true)
            {
                modificarEquipo();
            }
            else
            {
                agregarEquipo();
            }
        }
        void agregarEquipo()
        {

            EquiposController equicontrol = new EquiposController();

            equicontrol.Nombre = txtNombre.Text;
            equicontrol.codigoUbicacion = Convert.ToInt16(cbUbicacion.SelectedValue);

            if (equicontrol.AgregarEquipo() == true)
            {
                MessageBox.Show("Equipo agregado con exito");
                this.Hide();
                dash.CargarDatosEquipos();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al agregar equipo");
            }
        }

        void modificarEquipo()
        {
            EquiposController equicontrol = new EquiposController();

            equicontrol.codigoEquipos = txtCodigoEquipo.Text;
            equicontrol.Nombre = txtNombre.Text;
            equicontrol.codigoUbicacion = Convert.ToInt16(cbUbicacion.SelectedValue);

            if (equicontrol.ActualizarEquipo() == true)
            {
                MessageBox.Show("Equipo actualizado con exito");
                this.Hide();
                dash.CargarDatosEquipos();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al actualizar el equipo");
            }
        }

        public void eliminarEquipo(string codigoEquipo)
        {
            EquiposController equicontrol = new EquiposController();

            equicontrol.codigoEquipos = codigoEquipo;

            if (equicontrol.EliminarEquipo() == true)
            {
                MessageBox.Show("El equipo se eliminó con exito");
                dash.CargarDatosEquipos();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al eliminar el equipo");
            }
        }
        public void llenarModal(string CodigoEquipo, string Nombre, string Laboratorio, string Ubicacion)
        {
            EquiposController objselect = new EquiposController();

            txtCodigoEquipo.Text = CodigoEquipo;
            txtNombre.Text = Nombre;

            cargarUbicacion();
            DataTable codigoUbi = objselect.CargarUbicacion_Controller(Laboratorio, Ubicacion);
            object valorUbi = codigoUbi.Rows[0]["CodigoUbicacion"];
            cbUbicacion.SelectedIndex = int.Parse(valorUbi.ToString()) - 1;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
