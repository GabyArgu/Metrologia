using Controlador;
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

namespace Metrologia
{
    public partial class Revision : Form
    {
        Dashboard dash = (Dashboard)formularios.DashboardFRM;
        public Revision()
        {
            InitializeComponent();
            cargarEmpleado();
            cargarEquipo();
            cargarMotivo();
            cargarEstadoR();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        void cargarEmpleado()
        {
            cbEmpleado.DataSource = RevisionController.CargarEmpleado_Controller();
            cbEmpleado.DisplayMember = "Nombre";
            cbEmpleado.ValueMember = "CodigoEmpleado";
        }

        void cargarEquipo()
        {
            cbEquipo.DataSource = RevisionController.CargarEquipo_Controller();
            cbEquipo.DisplayMember = "Nombre";
            cbEquipo.ValueMember = "CodigoEquipos";
        }
        void cargarMotivo()
        {
            cbMotivo.DataSource = RevisionController.CargarMotivo_Controller();
            cbMotivo.DisplayMember = "Nombre";
            cbMotivo.ValueMember = "CodigoMotivo";
        }

        void cargarEstadoR()
        {
            cbEstadoR.DataSource = RevisionController.CargarEstado_Controller();
            cbEstadoR.DisplayMember = "Nombre";
            cbEstadoR.ValueMember = "CodigoEstadoRev";
        }
        public void ocultarCodigo()
        {
            pnlCodigoRevision.Visible = false;
            txtCodigoRevison.Visible = false;
        }

        public void mostrarCodigo()
        {
            pnlCodigoRevision.Visible = true;
            txtCodigoRevison.Visible = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCodigoRevison.Visible == true)
            {
                modificarRevision();
            }
            else
            {
                agregarRevision();
            }
        }
        void agregarRevision()
        {

            RevisionController revisioncontrol = new RevisionController();

            revisioncontrol.comentario = txtComentarios.Text;
            DateTime Fecha = dtpFecha.Value;
            revisioncontrol.fecha = Fecha.ToString("MM/dd/yyyy");
            revisioncontrol.equipo = Convert.ToInt16(cbEquipo.SelectedValue);
            revisioncontrol.empleado = Convert.ToInt16(cbEmpleado.SelectedValue);
            revisioncontrol.motivo = Convert.ToInt16(cbMotivo.SelectedValue);
            revisioncontrol.estado = Convert.ToInt16(cbEstadoR.SelectedValue);

            if (revisioncontrol.AgregarRevision() == true)
            {
                MessageBox.Show("Revision agregada con exito");
                this.Hide();
                dash.CargarDatosRevisiones();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al agregar revision", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void modificarRevision()
        {
            RevisionController revisioncontrol = new RevisionController();

            revisioncontrol.codigoRevision = txtCodigoRevison.Text;
            revisioncontrol.comentario = txtComentarios.Text;
            DateTime Fecha = dtpFecha.Value;
            revisioncontrol.fecha = Fecha.ToString("MM/dd/yyyy");
            revisioncontrol.equipo = Convert.ToInt16(cbEquipo.SelectedValue);
            revisioncontrol.empleado = Convert.ToInt16(cbEmpleado.SelectedValue);
            revisioncontrol.motivo = Convert.ToInt16(cbMotivo.SelectedValue);
            revisioncontrol.estado = Convert.ToInt16(cbEstadoR.SelectedValue);

            if (revisioncontrol.ActualizarRevision() == true)
            {
                MessageBox.Show("Revision actualizada con exito");
                this.Hide();
                dash.CargarDatosRevisiones();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al actualizar revision", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void llenarModal(string CodigoRevision, string Comentario, string Fecha, string Equipo, string Empleado, string Motivo, string EstadoR)
        {
            string[] formatos = { "d/M/yyyy H:mm:ss", "M/d/yyyy H:mm:ss" };
            RevisionController objselect = new RevisionController();

            txtCodigoRevison.Text = CodigoRevision;
            txtComentarios.Text = Comentario;
            dtpFecha.Value = DateTime.ParseExact(Fecha, formatos, CultureInfo.InvariantCulture, DateTimeStyles.None);

            cargarEmpleado();
            DataTable codigoEm = objselect.CargarEmpleado_Controller(Empleado);
            object valorEm = codigoEm.Rows[0]["CodigoEmpleado"];
            cbEmpleado.SelectedIndex = int.Parse(valorEm.ToString()) - 1;

            cargarEquipo();
            DataTable codigoEq = objselect.CargarEquipo_Controller(Equipo);
            object valorEq = codigoEq.Rows[0]["CodigoEquipos"];
            cbEquipo.SelectedIndex = int.Parse(valorEq.ToString()) - 1;

            cargarMotivo();
            DataTable codigoMo = objselect.CargarMotivo_Controller(Motivo);
            object valorMo = codigoMo.Rows[0]["CodigoMotivo"];
            cbMotivo.SelectedIndex = int.Parse(valorMo.ToString()) - 1;

            cargarEstadoR();
            DataTable codigoEstadoR = objselect.CargarEstadoR_Controller(EstadoR);
            object valorEstR = codigoEstadoR.Rows[0]["CodigoEstadoRev"];
            cbEstadoR.SelectedIndex = int.Parse(valorEstR.ToString()) - 1;
        }

        public void eliminarRevision(string codigoRevision)
        {
            RevisionController revisioncontrol = new RevisionController();

            revisioncontrol.codigoRevision = codigoRevision;
            revisioncontrol.estado = 2;
            if (revisioncontrol.EliminarRevision() == true)
            {
                MessageBox.Show("La revision se eliminó con exito");
                dash.CargarDatosRevisiones();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al eliminar la revision", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
