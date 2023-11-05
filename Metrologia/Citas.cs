using Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metrologia
{
    public partial class Citas : Form
    {
        Dashboard dash = new Dashboard();

        public Citas()
        {
            InitializeComponent();
            cargarEncargado();
            cargarEmpresa();
            cargarEstadoCi();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }        

        void cargarEncargado()
        {
            cbEncargado.DataSource = CitasController.CargarEncargado_Controller();
            cbEncargado.DisplayMember = "Nombre";
            cbEncargado.ValueMember = "CodigoEncargado";
        }

        void cargarEmpresa()
        {
            cbEmpresa.DataSource = CitasController.CargarEmpresa_Controller();
            cbEmpresa.DisplayMember = "Nombre";
            cbEmpresa.ValueMember = "CodigoEmpresa";
        }

        void cargarEstadoCi()
        {
            cbEstadoCi.DataSource = CitasController.CargarEstado_Controller();
            cbEstadoCi.DisplayMember = "Nombre";
            cbEstadoCi.ValueMember = "CodigoEstadoCi";
        }
        public void ocultarCodigo()
        {
            pnlCodigoCita.Visible = false;
            txtCodigoCita.Visible = false;
        }

        public void mostrarCodigo()
        {
            pnlCodigoCita.Visible = true;
            txtCodigoCita.Visible = true;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCodigoCita.Visible == true)
            {
                modificarCita();
            }
            else
            {
                agregarCita();
            }
        }

        void agregarCita()
        {

            CitasController citacontrol = new CitasController();

            citacontrol.Comentarios = txtComentarios.Text;
            DateTime Fecha = dtpFecha.Value;
            citacontrol.Fecha = Fecha.ToString("MM/dd/yyyy");
            citacontrol.Hora = Convert.ToString(dtpHora.Value);
            citacontrol.Encargado = Convert.ToInt16(cbEncargado.SelectedValue); ;
            citacontrol.Empresa = Convert.ToInt16(cbEmpresa.SelectedValue);
            citacontrol.EstadoCi = Convert.ToInt16(cbEstadoCi.SelectedValue);

            if (citacontrol.AgregarCita() == true)
            {
                MessageBox.Show("Cita agendada con exito");
                this.Hide();
                dash.CargarDatosCitas();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al agendar cita");
            }
        }

        void modificarCita()
        {
            CitasController citacontrol = new CitasController();

            citacontrol.codigoCita = txtCodigoCita.Text;
            citacontrol.Comentarios = txtComentarios.Text;
            DateTime Fecha = dtpFecha.Value;
            citacontrol.Fecha = Fecha.ToString("MM/dd/yyyy");
            citacontrol.Hora = Convert.ToString(dtpHora.Value);
            citacontrol.Encargado = Convert.ToInt16(cbEncargado.SelectedValue); ;
            citacontrol.Empresa = Convert.ToInt16(cbEmpresa.SelectedValue);
            citacontrol.EstadoCi = Convert.ToInt16(cbEstadoCi.SelectedValue);

            if (citacontrol.ActualizarCita() == true)
            {
                MessageBox.Show("Cita actualizada con exito");
                this.Hide();
                dash.CargarDatosCitas();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al actualizar cita");
            }
        }

        public void llenarModal(string CodigoCita, string Comentarios, string Fecha, string Hora, string Encargado, string Empresa, string EstadoCi)
        {
            string[] formatos = { "d/M/yyyy H:mm:ss", "M/d/yyyy H:mm:ss" };
            CitasController objselect = new CitasController();

            txtCodigoCita.Text = CodigoCita;
            txtComentarios.Text = Comentarios;
            dtpFecha.Value = DateTime.ParseExact(Fecha, formatos, CultureInfo.InvariantCulture, DateTimeStyles.None);
            dtpHora.Value = DateTime.ParseExact(Hora, "HH:mm:ss", CultureInfo.InvariantCulture);
            
            cargarEncargado();
            DataTable codigoEn = objselect.CargarEncargado_Controller(Encargado);
            object valorEn = codigoEn.Rows[0]["CodigoEncargado"];
            cbEncargado.SelectedIndex = int.Parse(valorEn.ToString()) - 1;

            cargarEmpresa();
            DataTable codigoEm = objselect.CargarEmpresa_Controller(Empresa);
            object valorEm = codigoEm.Rows[0]["CodigoEmpresa"];            
            cbEmpresa.SelectedIndex = int.Parse(valorEm.ToString()) - 1;

            DataTable codigoEstadoC = objselect.CargarEstado_Controller(EstadoCi);
            object valorEstado = codigoEstadoC.Rows[0]["CodigoEstadoCi"];
            cbEstadoCi.SelectedIndex = int.Parse(valorEstado.ToString()) - 1;
          
        }

        public void eliminarCitas(string codigoCita)
        {
            CitasController citacontrol = new CitasController();

            citacontrol.codigoCita = codigoCita;
            citacontrol.EstadoCi = 2;

            if (citacontrol.EliminarCitas() == true)
            {
                MessageBox.Show("Cita se eliminó con exito");
                dash.CargarDatosCitas();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al eliminar Cita");
            }
        }
    }
}
