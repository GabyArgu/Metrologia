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
            txtCodigoEmpleado.Visible = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
