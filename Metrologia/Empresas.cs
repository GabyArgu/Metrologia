using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;

namespace Metrologia
{
    public partial class Empresas : Form
    {
        Dashboard dash = (Dashboard)formularios.DashboardFRM;

        public Empresas()
        {
            InitializeComponent();
            cargarCategoria();
            cargarEstadoEM();
        }

        void cargarCategoria()
        {
            cbCategoria.DataSource = EmpresasController.CargarCategoria_Controller();
            cbCategoria.DisplayMember = "Nombre";
            cbCategoria.ValueMember = "CodigoCategoria";
        }

        void cargarEstadoEM()
        {
            cbEstadoE.DataSource = UsuarioController.CargarEstado_Controller();
            cbEstadoE.DisplayMember = "Nombre";
            cbEstadoE.ValueMember = "CodigoEstadoEm";
        }

        public void ocultarCodigo()
        {
            pnlCodigoEmpresa.Enabled = false;
            txtCodigoEmpresa.Enabled = false;
            cbEncargado.Enabled = false;
        }

        public void mostrarCodigo()
        {
            pnlCodigoEmpresa.Enabled = true;
            txtCodigoEmpresa.Enabled = true;
            cbEncargado.Enabled = true;
        }

        void agregarEmpresa()
        {
            EmpresasController empresacontrol = new EmpresasController();

            empresacontrol.Nombre = txtNombreEmpresa.Text;
            empresacontrol.RazonSocial = txtRazonSocial.Text;
            empresacontrol.Informacion = txtInformacion.Text;
            empresacontrol.Direccion = txtDireccion.Text;
            empresacontrol.Telefono = txtTelefono.Text;
            empresacontrol.Correo = txtCorreo.Text;
            empresacontrol.CodigoCat = Convert.ToInt16(cbCategoria.SelectedValue);
            empresacontrol.EstadoE = Convert.ToInt16(cbEstadoE.SelectedValue);

            if (empresacontrol.AgregarEmpresa() == true)
            {

                MessageBox.Show("Empresa agregada con exito");
                this.Hide();
                dash.CargarDatosEmpresa();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al agregar empresa");
            }
        }

        void modificarEmpresa()
        {
            EmpresasController empresacontrol = new EmpresasController();

            empresacontrol.codigoEmpresa = txtCodigoEmpresa.Text;
            empresacontrol.Nombre = txtNombreEmpresa.Text;
            empresacontrol.RazonSocial = txtRazonSocial.Text;
            empresacontrol.Informacion = txtInformacion.Text;
            empresacontrol.Direccion = txtDireccion.Text;
            empresacontrol.Telefono = txtTelefono.Text;
            empresacontrol.Correo = txtCorreo.Text;
            empresacontrol.CodigoEnc = Convert.ToInt16(cbEncargado.SelectedValue);
            empresacontrol.CodigoCat = Convert.ToInt16(cbCategoria.SelectedValue);
            empresacontrol.EstadoE = Convert.ToInt16(cbEstadoE.SelectedValue);

            if (empresacontrol.ActualizarEmpresa() == true)
            {
                MessageBox.Show("Empresa actualizada con exito");
                this.Hide();
                dash.CargarDatosEmpresa();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al actualizar empresa");
            }
        }

        public void llenarModal(string codigoEmpresa, string nombre, string razonsocial, string informacion, string direccion, string telefono, string correo, string nombreenc, string codigocat, string EstadoE)
        {
            EmpresasController objselect = new EmpresasController();

            txtCodigoEmpresa.Text = codigoEmpresa;
            txtNombreEmpresa.Text = nombre;
            txtRazonSocial.Text = razonsocial;
            txtInformacion.Text = informacion;
            txtDireccion.Text = direccion;
            txtTelefono.Text = telefono;
            txtCorreo.Text = correo;

            if (nombreenc == "")
            {
                cbEncargado.DataSource = EmpresasController.CargarEncargado_Controller(codigoEmpresa);
                cbEncargado.DisplayMember = "Nombre";
                cbEncargado.ValueMember = "CodigoEncargado";
            }
            else 
            {
                cbEncargado.DataSource = EmpresasController.CargarEncargado_Controller(codigoEmpresa);
                cbEncargado.DisplayMember = "Nombre";
                cbEncargado.ValueMember = "CodigoEncargado";
                int indice = cbEncargado.FindStringExact(nombreenc);
                cbEncargado.SelectedIndex = indice;
            }

            cargarCategoria();
            DataTable codigoC = objselect.CargarCategoriaEmpresa_Controller(codigoEmpresa);
            object valorC = codigoC.Rows[0]["CodigoCategoria"];
            cbCategoria.SelectedIndex = int.Parse(valorC.ToString()) - 1;

            cargarEstadoEM();
            DataTable codigoEstado = objselect.CargarEstadoEM_Controller(codigoEmpresa);
            object valorEstado = codigoEstado.Rows[0]["CodigoEstadoE"];
            cbEstadoE.SelectedIndex = int.Parse(valorEstado.ToString()) - 1;
        }

        public void eliminarEmpresa(string codigoEmpresa)
        {
            EmpresasController empresacontrol = new EmpresasController();

            empresacontrol.codigoEmpresa = codigoEmpresa;
            empresacontrol.EstadoE = 2;

            if (empresacontrol.EliminarEmpresa() == true)
            {
                MessageBox.Show("Empresa se eliminó con exito");
                dash.CargarDatosEmpresa();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al eliminar empresa");
            }
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
            if (txtCodigoEmpresa.Enabled == true) modificarEmpresa();
            else agregarEmpresa();
        }

        //Validaciones
        private void txtSoloLetras(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 'A' && e.KeyChar <= 'Z') ||  // Letras mayúsculas
                (e.KeyChar >= 'a' && e.KeyChar <= 'z') || // Letras minúsculas
                (e.KeyChar == 'á' || e.KeyChar == 'é' || e.KeyChar == 'í' || e.KeyChar == 'ó' || e.KeyChar == 'ú' || // Letras con tildes
                    e.KeyChar == 'Á' || e.KeyChar == 'É' || e.KeyChar == 'Í' || e.KeyChar == 'Ó' || e.KeyChar == 'Ú' || // Letras mayúsculas con tildes
                    e.KeyChar == ' ' || e.KeyChar == (char)Keys.Back))) // Espacio en blanco o tecla "Borrar"
            {
                // Validación de caracteres no permitidos
                MessageBox.Show("Solo se aceptan letras, letras con tildes y espacios en blanco", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
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
                //Validacion de solo teclas numericas
                MessageBox.Show("Solo se aceptan valores numericos y positivos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
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


        private void txtCorreo_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                if (!validaremail(txtCorreo.Text))
                {
                    MessageBox.Show("Dirección de correo no válida");
                    txtCorreo.SelectAll();
                    e.Cancel = true; // Cancela el evento Validating para evitar que el foco cambie
                }
            }
        }
    }
}
