using Controlador;
using Metrologia.Properties;
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
            CargarDatosUsuario();
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

        //Botones extra dentro de cruds en especificos

        private void btnEncargado_Click(object sender, EventArgs e)
        {
            // Se muestra el panel 7 de tabControl
            tbcCruds.SelectedIndex = 6;
        }

        private void btnUbicacion_Click(object sender, EventArgs e)
        {
            // Se muestra el panel 8 de tabControl
            tbcCruds.SelectedIndex = 7;
        }

        //Botones para el CRUD

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            Empleados formE = new Empleados();

            // Mostrar el formulario
            formE.ocultarCodigo();
            formE.Show();     
        }

        public void CargarDatosUsuario()
        {
            try
            {
                tbcCruds.SelectedIndex = 1;
                dgvEmpleados.DataSource = null;
                dgvEmpleados.DataSource = UsuarioController.CargarUsuarios_Controller();
                dgvEmpleados.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos existentes en la base de datos, consulte con su administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEmpleados_DoubleClick(object sender, EventArgs e)
        {
            int posicion;
            string codigoEmpleado, nombreUser, nombre, apellido, correo, telefono, cargo, estado;
            posicion = dgvEmpleados.CurrentRow.Index;

            codigoEmpleado = dgvEmpleados[0, posicion].Value.ToString();
            nombreUser = dgvEmpleados[1, posicion].Value.ToString();
            nombre = dgvEmpleados[2, posicion].Value.ToString();
            apellido = dgvEmpleados[3, posicion].Value.ToString();
            correo = dgvEmpleados[4, posicion].Value.ToString();
            telefono = dgvEmpleados[5, posicion].Value.ToString();

            cargo = dgvEmpleados[6, posicion].Value.ToString();

            estado = dgvEmpleados[7, posicion].Value.ToString();

            Empleados formE = new Empleados();

            // Mostrar el formulario
            formE.mostrarCodigo();
            formE.llenarModal(codigoEmpleado, nombreUser, nombre, apellido, correo, telefono, cargo, estado);
            formE.Show();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int posicion = dgvEmpleados.CurrentRow.Index;
            string codigoEmpleado = dgvEmpleados[0, posicion].Value.ToString();
            Empleados formE = new Empleados();
            formE.eliminarUsuario(codigoEmpleado);
            CargarDatosUsuario();
        }


        //Hover de botones del menu
        private void btnHome_MouseHover(object sender, EventArgs e)
        {
            //Hover cambiar imagen
            btnHome.BackgroundImage = global::Metrologia.Properties.Resources.hogar__1_;

        }

        private void btnHome_MouseLeave(object sender, EventArgs e)
        {
            //Hover regresar imagen
            btnHome.BackgroundImage = global::Metrologia.Properties.Resources.hogar;
        }

        private void btnEmpleados_MouseHover(object sender, EventArgs e)
        {
            //Hover cambiar imagen
            btnEmpleados.BackgroundImage = global::Metrologia.Properties.Resources.usuario_de_archivo__1_;
        }

        private void btnEmpleados_MouseLeave(object sender, EventArgs e)
        {
            //Hover regresar imagen
            btnEmpleados.BackgroundImage = global::Metrologia.Properties.Resources.usuario_de_archivo;
        }

        private void btnCitas_MouseHover(object sender, EventArgs e)
        {
            //Hover cambiar imagen
            btnCitas.BackgroundImage = global::Metrologia.Properties.Resources.calendario_reloj__1_;
        }

        private void btnCitas_MouseLeave(object sender, EventArgs e)
        {
            //Hover regresar imagen
            btnCitas.BackgroundImage = global::Metrologia.Properties.Resources.calendario_reloj;
        }

        private void btnEmpresas_MouseHover(object sender, EventArgs e)
        {
            btnEmpresas.BackgroundImage = global::Metrologia.Properties.Resources.edificio__1_;
        }

        private void btnEmpresas_MouseLeave(object sender, EventArgs e)
        {
            btnEmpresas.BackgroundImage = global::Metrologia.Properties.Resources.edificio;
        }

        private void btnEquipos_MouseHover(object sender, EventArgs e)
        {
            btnEquipos.BackgroundImage = global::Metrologia.Properties.Resources.herramientas__1_;
        }

        private void btnEquipos_MouseLeave(object sender, EventArgs e)
        {
            btnEquipos.BackgroundImage = global::Metrologia.Properties.Resources.herramientas;
        }

        private void btnExtras_MouseHover(object sender, EventArgs e)
        {
            btnExtras.BackgroundImage = global::Metrologia.Properties.Resources.ojo__2_;
        }

        private void btnExtras_MouseLeave(object sender, EventArgs e)
        {
            btnExtras.BackgroundImage = global::Metrologia.Properties.Resources.ojo__1_;
        }
    }
}
