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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Metrologia
{
    public partial class Citas : Form
    {
        Dashboard dash = (Dashboard)formularios.DashboardFRM;

        public Citas()
        {
            InitializeComponent();            
            cargarEmpresa();
            cargarEstadoCi();
            dtpHora.Value = DateTime.Now;
            dtpHora.CustomFormat = "hh:mm tt";
            dtpHora.Format = DateTimePickerFormat.Custom;
        }

        public bool EsFechaValida(DateTime fecha)
        {
            DateTime selectedDateTime = dtpFecha.Value.Date + dtpHora.Value.TimeOfDay;
            DateTime currentDateTime = DateTime.Now;

            // Verifica si la fecha seleccionada es anterior a la fecha actual
            if (selectedDateTime < currentDateTime)
            {
                // Muestra un mensaje de error
                MessageBox.Show("Selecciona una fecha y hora posterior a la  actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // La fecha no es válida
            }
            else
            {
                return true; // La fecha es válida
            }
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }        

        void cargarEncargado(int codigoEmpresa)
        {
            cbEncargado.DataSource = CitasController.CargarEncargado_Controller(codigoEmpresa);
            cbEncargado.DisplayMember = "Nombre";
            cbEncargado.ValueMember = "CodigoEncargado";
        }

        void cargarEmpresa()
        {
            cbEmpresa.DataSource = CitasController.CargarEmpresa_Controller();
            cbEmpresa.DisplayMember = "Nombre";
            cbEmpresa.ValueMember = "CodigoEmpresa";
            int Empresa = Convert.ToInt16(cbEmpresa.SelectedValue);
            cargarEncargado(Empresa);
        }
        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView codigoEm = (DataRowView)cbEmpresa.SelectedItem;
            object valorEm = codigoEm.Row["CodigoEmpresa"];
            int Empresa = int.Parse(valorEm.ToString());
            cargarEncargado(Empresa);
        }

        void cargarEstadoCi()
        {
            cbEstadoCi.DataSource = CitasController.CargarEstado_Controller();
            cbEstadoCi.DisplayMember = "Nombre";
            cbEstadoCi.ValueMember = "CodigoEstadoCi";
        }
        public void ocultarCodigo()
        {
            pnlCodigoCita.Enabled = false;
            txtCodigoCita.Enabled = false;
        }

        public void mostrarCodigo()
        {
            pnlCodigoCita.Enabled = true;
            txtCodigoCita.Enabled = true;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCodigoCita.Enabled == true)
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
            citacontrol.Fecha = Fecha;
            DateTime Hora = dtpHora.Value;
            citacontrol.Hora = Hora;
            citacontrol.Encargado = Convert.ToInt16(cbEncargado.SelectedValue); ;
            citacontrol.Empresa = Convert.ToInt16(cbEmpresa.SelectedValue);
            citacontrol.EstadoCi = Convert.ToInt16(cbEstadoCi.SelectedValue);
            
            if (EsFechaValida(Fecha) == true)
            {
                if (citacontrol.AgregarCita() == true)
                {
                    MessageBox.Show("Cita agendada con exito");
                    this.Hide();
                    dash.CargarDatosCitas();
                    dash.Refresh();
                }
                else
                {
                    MessageBox.Show("Error al agendar cita", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        void modificarCita()
        {
            CitasController citacontrol = new CitasController();

            citacontrol.codigoCita = txtCodigoCita.Text;
            citacontrol.Comentarios = txtComentarios.Text;
            DateTime Fecha = dtpFecha.Value;
            citacontrol.Fecha = Fecha;
            DateTime Hora = dtpHora.Value;
            citacontrol.Hora = Hora;
            citacontrol.Encargado = Convert.ToInt16(cbEncargado.SelectedValue); ;
            citacontrol.Empresa = Convert.ToInt16(cbEmpresa.SelectedValue);
            citacontrol.EstadoCi = Convert.ToInt16(cbEstadoCi.SelectedValue);

            if (EsFechaValida(Fecha) == true)
            {
                if (citacontrol.ActualizarCita())
                { 
                MessageBox.Show("Cita actualizada con exito");
                this.Hide();
                dash.CargarDatosCitas();
                dash.Refresh();
                }
                else
                {
                    MessageBox.Show("Error al actualizar cita", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }

        public void llenarModal(string CodigoCita, string Comentarios, DateTime Fecha, DateTime Hora, string Encargado, string Empresa, string EstadoCi)
        {
            CitasController objselect = new CitasController();

            txtCodigoCita.Text = CodigoCita;
            txtComentarios.Text = Comentarios;
            dtpFecha.Value = Fecha;
            dtpHora.Value = Hora;

            cargarEmpresa();
            DataTable codigoEm = objselect.CargarEmpresa_Controller(Empresa);
            object valorEm = codigoEm.Rows[0]["CodigoEmpresa"];
            int indiceEmpresa = cbEmpresa.FindStringExact(Empresa);
            cbEmpresa.SelectedIndex = indiceEmpresa;

            cargarEncargado(int.Parse(valorEm.ToString()));
            int indiceEncargado = cbEncargado.FindStringExact(Encargado);
            cbEncargado.SelectedIndex = indiceEncargado;

            cargarEstadoCi();
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
                MessageBox.Show("Error al eliminar Cita", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        
    }
}
