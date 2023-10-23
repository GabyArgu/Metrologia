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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult cerrar = MessageBox.Show("¿Quieres salir del programa?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (cerrar == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMaximi_Click(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // Se muestra el panel 1 de tabControl
            tbcCruds.SelectedIndex = 0;
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            // Se muestra el panel 2 de tabControl
            tbcCruds.SelectedIndex = 1;
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            // Se muestra el panel 3 de tabControl
            tbcCruds.SelectedIndex = 2;
        }

        private void btnEmpresas_Click(object sender, EventArgs e)
        {
            // Se muestra el panel 4 de tabControl
            tbcCruds.SelectedIndex = 3;
        }

        private void btnEquipos_Click(object sender, EventArgs e)
        {
            // Se muestra el panel 5 de tabControl
            tbcCruds.SelectedIndex = 4;
        }

        private void btnExtras_Click(object sender, EventArgs e)
        {
            // Se muestra el panel 6 de tabControl
            tbcCruds.SelectedIndex = 5;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            Empleados formE = new Empleados();

            // Mostrar el formulario
            formE.Show();
        }
    }
}
