using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using Controlador;

namespace Metrologia
{
    public partial class Empleados : Form
    {
        Dashboard dash = new Dashboard();
        public Empleados()
        {
            InitializeComponent();
            cargarCargo();
            cargarEstado();
        }

        void cargarCargo()
        {
            cbCargo.DataSource = UsuarioController.CargarCargos_Controller();
            cbCargo.DisplayMember = "Nombre";
            cbCargo.ValueMember = "CodigoCargo";
        }

        void cargarEstado()
        {
            cbEstado.DataSource = UsuarioController.CargarEstado_Controller();
            cbEstado.DisplayMember = "Nombre";
            cbEstado.ValueMember = "CodigoEstadoEm";
        }

        public void ocultarCodigo() 
        {
            pnlCodigoEmpleado.Visible = false;
            txtCodigoEmpleado.Visible = false;
        }

        public void mostrarCodigo()
        {
            pnlCodigoEmpleado.Visible = true;
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCodigoEmpleado.Visible == true)
            {
                modificarUsuario();
            }
            else 
            {
                agregarUsuario();
            }
        }

        void agregarUsuario() 
        {            

            UsuarioController usercontrol = new UsuarioController();

            if (txtContra.Text == txtConfirmContra.Text)
            {
                usercontrol.Username = txtNombreUser.Text;
                usercontrol.Nombre = txtNombre.Text;
                usercontrol.Apellido = txtApellido.Text;
                usercontrol.Correo = txtCorreo.Text;
                usercontrol.Telefono = txtTelefono.Text;
                usercontrol.ContraUser = txtContra.Text;
                usercontrol.CargoE = Convert.ToInt16(cbCargo.SelectedValue);
                usercontrol.EstadoE = 1;

                if (usercontrol.AgregarUsuario() == true)
                {
                    MessageBox.Show("Empleado agregado con exito");
                    this.Hide();
                    dash.CargarDatosUsuario();
                    dash.Refresh();
                }
                else
                {
                    MessageBox.Show("Error al agregar empleado");
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden intentelo denuevo");
            }
        }

        void modificarUsuario()
        {            
            UsuarioController usercontrol = new UsuarioController(); 

            usercontrol.codigoEmpleado = txtCodigoEmpleado.Text;
            usercontrol.Username = txtNombreUser.Text;
            usercontrol.Nombre = txtNombre.Text;
            usercontrol.Apellido = txtApellido.Text;
            usercontrol.Correo = txtCorreo.Text;
            usercontrol.Telefono = txtTelefono.Text;
            usercontrol.CargoE = Convert.ToInt16(cbCargo.SelectedValue);
            usercontrol.EstadoE = Convert.ToInt16(cbEstado.SelectedValue);

            if (usercontrol.ActualizarUsuario() == true)
            {
                MessageBox.Show("Empleado actualizado con exito");
                this.Hide();
                dash.CargarDatosUsuario();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al actualizar empleado");
            }           
        }

        public void llenarModal(string codigoEmpleado, string nombreUser, string nombre, string apellido, string correo, string telefono, string cargo, string estado) 
        {
            UsuarioController objselect = new UsuarioController();

            txtCodigoEmpleado.Text = codigoEmpleado;
            txtNombreUser.Text = nombreUser;
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtCorreo.Text = correo;
            txtTelefono.Text = telefono;

            cargarCargo();
            DataTable codigoCargo = objselect.CargarCargoEmpleado_Controller(codigoEmpleado);
            object valorCar = codigoCargo.Rows[0]["CodigoCargo"];
            cbCargo.SelectedIndex = int.Parse(valorCar.ToString()) - 1;

            cargarEstado();
            DataTable codigoEstado = objselect.CargarEstadoEmpleado_Controller(codigoEmpleado);
            object valorEstado = codigoEstado.Rows[0]["CodigoEstadoEm"];
            cbEstado.SelectedIndex = int.Parse(valorEstado.ToString()) - 1;

            pnlContrasena.Visible = false;
            txtContra.Visible = false;
            pnlConfirmar.Visible = false;
            txtConfirmContra.Visible = false;
        }

        public void eliminarUsuario(string codigoEmpleado) 
        {
            UsuarioController usercontrol = new UsuarioController();

            usercontrol.codigoEmpleado = codigoEmpleado;
            usercontrol.EstadoE = 2;
            
            if (usercontrol.EliminarUsuario() == true)
            {
                MessageBox.Show("Empleado se eliminó con exito");
                dash.CargarDatosUsuario();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al eliminar empleado");
            }
        }
    }
}
