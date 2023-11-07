using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using Controlador;

namespace Metrologia
{
    public partial class Empleados : Form
    {
        Dashboard dash = (Dashboard)formularios.DashboardFRM;
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
                dash.CargarDatosUsuario();
            }
            else
            {
                agregarUsuario();
                dash.CargarDatosUsuario();
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


        private void txtSoloLetras(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || // Letras mayúsculas
                (e.KeyChar >= 'a' && e.KeyChar <= 'z') || // Letras minúsculas
                    (e.KeyChar == 'á' || e.KeyChar == 'é' || e.KeyChar == 'í' || e.KeyChar == 'ó' || e.KeyChar == 'ú' || // Letras con tildes
                    e.KeyChar == 'Á' || e.KeyChar == 'É' || e.KeyChar == 'Í' || e.KeyChar == 'Ó' || e.KeyChar == 'Ú' || // Letras mayúsculas con tildes
                    e.KeyChar == ' '))) // Espacio en blanco
            {
                // Validación de caracteres no permitidos
                MessageBox.Show("Solo se aceptan letras, letras con tildes y espacios en blanco", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (validaremail(txtCorreo.Text))
            {
                //si es correcto no debe hacer nada
            }
            else
            {
                MessageBox.Show("Dirección de correo no válida");
                txtCorreo.SelectAll(); //selecciona todo lo de la casilla
                txtCorreo.Focus(); //se posiciona ahí de nuevo
            }

        }

        public static bool validaremail(string email)
        {
            //cadena o expresion regular que verifica a un formato de correo electrónico
            string expresion = "^(([\\w-]+\\.)+[\\w-]+|([a-zA-Z]{1}|[\\w-]{2,}))@(([a-zA-Z]+[\\w-]+\\.){1,2}[a-zA-Z]{2,4})$";
            //verifica que el email ingresado corresponda con la expresion válida
            if (Regex.IsMatch(email, expresion))
            {//verifica que la direccion corresponda y que la longitud de la cadena no sté vacía
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir números del 0 al 9, guion y control de edición (por ejemplo, retroceso)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            // Permitir un guion en la posición 4
            if (e.KeyChar == '-' && (sender as TextBox).Text.Contains("-"))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            string input = txtTelefono.Text.Replace("-", ""); // Eliminar guiones existentes
            if (input.Length > 8)
            {
                input = input.Substring(0, 8); // Limitar a 8 dígitos
            }

            if (input.Length >= 4)
            {
                input = input.Insert(4, "-"); // Insertar guion después de los primeros 4 dígitos
            }

            txtTelefono.Text = input;
            txtTelefono.SelectionStart = txtTelefono.Text.Length; // Colocar el cursor al final del texto
        }
    }
}
