using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Controlador;


namespace Metrologia
{

    public partial class Form1 : Form
    {
        string usuario;
        string contrasena;
        
        public Form1()
        {
            InitializeComponent();
        }

        void limpiarCampos() 
        {
            txtUsuario.Clear();
            txtContra.Clear();
            txtUsuario.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult cerrar = MessageBox.Show("¿Quieres salir del programa?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (cerrar == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnMaximi_Click(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximi_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            AtributosLogin.Username = txtUsuario.Text;
            AtributosLogin.txt2 = txtContra.Text;

            if (LoginController.Acceso_Controller()==true)
            {
                formularios.DashboardFRM = new Dashboard();

                // Mostrar el formulario
                formularios.DashboardFRM.Show();

                // Cerrar el formulario actual
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos, intentelo denuevo", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                limpiarCampos();
            }
        }

    }
}
