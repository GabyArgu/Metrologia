using Controlador;
using Guna.UI2.WinForms.Interfaces;
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

namespace Metrologia
{
    public partial class Ubicacion : Form
    {
        Dashboard dash = (Dashboard)formularios.DashboardFRM;

        public Ubicacion()
        {
            InitializeComponent();
        }
        public void ocultarCodigo()
        {
            pnlCodigoUbicacion.Visible = false;
            txtCodigoUbicacion.Visible = false;
        }

        public void mostrarCodigo()
        {
            pnlCodigoUbicacion.Visible = true;
            txtCodigoUbicacion.Visible = true;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCodigoUbicacion.Visible == true)
            {
                modificarUbicacion();
            }
            else
            {
                agregarUbicacion();
            }
        }
        void agregarUbicacion()
        {

            UbicacionController ubicontrol = new UbicacionController();

            ubicontrol.Laboratorio = txtLaboratorio.Text;
            ubicontrol.Ubicacion = txtUbiLab.Text;

            if (ubicontrol.AgregarUbicacion() == true)
            {
                MessageBox.Show("Ubicacion agregada con exito");
                this.Hide();
                dash.CargarDatosUbicacion();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al agregar ubicacion");
            }
        }

        void modificarUbicacion()
        {
            UbicacionController ubicontrol = new UbicacionController();

            ubicontrol.codigoUbicacion = txtCodigoUbicacion.Text;
            ubicontrol.Laboratorio = txtLaboratorio.Text;
            ubicontrol.Ubicacion = txtUbiLab.Text;

            if (ubicontrol.ActualizarUbicacion() == true)
            {
                MessageBox.Show("Ubicacion actualizada con exito");
                this.Hide();
                dash.CargarDatosUbicacion();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al actualizar Ubicacion");
            }
        }

        public void eliminarUbicacion(string codigoUbicacion)
        {
            UbicacionController ubicontrol = new UbicacionController();

            ubicontrol.codigoUbicacion = codigoUbicacion;

            if (ubicontrol.EliminarUbicacion() == true)
            {
                MessageBox.Show("Ubicacion se eliminó con exito");
                dash.CargarDatosUbicacion();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al eliminar Ubicacion");
            }
        }
        public void llenarModal(string CodigoUbicacion, string Laboratorio, string UbiLab)
        {
            txtCodigoUbicacion.Text = CodigoUbicacion;
            txtLaboratorio.Text = Laboratorio;
            txtUbiLab.Text = UbiLab;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
