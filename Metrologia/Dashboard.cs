using Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace Metrologia
{
    public partial class Dashboard : Form
    {
        public string usua;
        public string txt3;

        public Dashboard(string usuario, string txt2)
        {
            InitializeComponent();
            ObtenerDatos(usuario, txt2);
            usua = usuario;
            txt3 = txt2;
        }

        void ObtenerDatos(string user, string pass)
        {            
            string roluser;
            usua = user;
            txt3 = pass;

            LoginController logincontrol = new LoginController();

            AtributosLogin.Username = usua;
            AtributosLogin.txt2 = txt3;

            DataTable rolusuario = logincontrol.nivelUsuario_Controller();
            object valorRol = rolusuario.Rows[0]["Nombre"];
            roluser = valorRol.ToString();
            rolesUsuario(roluser);
        }

        void rolesUsuario(string rol)
        {
            if (rol == "Directora")
            {
                btnEmpleados.Visible = true;
                btnCitas.Visible = true;
                btnEmpresas.Visible = true;
                btnEquipos.Visible = true;
                btnExtras.Visible = true;
            }
            else if (rol == "Asistente")
            {
                btnEmpleados.Visible = false;
                btnCitas.Visible = true;
                btnEmpresas.Visible = false;
                btnEquipos.Visible = false;
                btnExtras.Visible = true;
            }
            else
            {
                btnEmpleados.Visible = false;
                btnCitas.Visible = false;
                btnEmpresas.Visible = false;
                btnEquipos.Visible = false;
                btnExtras.Visible = false;
            }
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

        private void btnMaximi_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
            CargarDatosCitas();
        }

        private void btnEmpresas_Click(object sender, EventArgs e)
        {
            // Se muestra el panel 4 de tabControl
            tbcCruds.SelectedIndex = 3;
            CargarDatosEmpresa();
        }

        private void btnEquipos_Click(object sender, EventArgs e)
        {
            // Se muestra el panel 5 de tabControl
            tbcCruds.SelectedIndex = 4;
            CargarDatosEquipos();
        }

        private void btnExtras_Click(object sender, EventArgs e)
        {
            // Se muestra el panel 6 de tabControl
            tbcCruds.SelectedIndex = 5;
            CargarDatosRevisiones();
        }

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

        public void CargarDatosCitas()
        {
            try
            {
                tbcCruds.SelectedIndex = 2;
                dgvCitas.DataSource = null;
                dgvCitas.DataSource = CitasController.CargarCitas_Controller();
                dgvCitas.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos existentes en la base de datos, consulte con su administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarDatosUbicacion()
        {
            try
            {
                tbcCruds.SelectedIndex = 7;
                dgvUbicacion.DataSource = null;
                dgvUbicacion.DataSource = UbicacionController.CargarUbicacion_Controller();
                dgvUbicacion.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos existentes en la base de datos, consulte con su administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CargarDatosEquipos()
        {
            try
            {
                tbcCruds.SelectedIndex = 4;
                dgvEquipos.DataSource = null;
                dgvEquipos.DataSource = EquiposController.CargarEquipos_Controller();
                dgvEquipos.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos existentes en la base de datos, consulte con su administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CargarDatosRevisiones()
        {
            try
            {
                tbcCruds.SelectedIndex = 5;
                dgvRevisiones.DataSource = null;
                dgvRevisiones.DataSource = RevisionController.CargarRevision_Controller();
                dgvRevisiones.Refresh();
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
        }
        //Botones extra dentro de cruds en especificos

        private void btnEncargado_Click(object sender, EventArgs e)
        {
            // Se muestra el panel 7 de tabControl
            tbcCruds.SelectedIndex = 6;
            CargarDatosEncargado();
        }

        private void btnUbicacion_Click(object sender, EventArgs e)
        {
            // Se muestra el panel 8 de tabControl
            tbcCruds.SelectedIndex = 7;
            CargarDatosUbicacion();
        }

        private void btnAgregarC_Click(object sender, EventArgs e)
        {
            Citas formC = new Citas();

            // Mostrar el formulario
            formC.ocultarCodigo();
            formC.Show();
        }

        private void btnEliminarC_Click(object sender, EventArgs e)
        {
            int posicion = dgvCitas.CurrentRow.Index;
            string codigoCitas = dgvCitas[0, posicion].Value.ToString();
            Citas formC = new Citas();
            formC.eliminarCitas(codigoCitas);
        }

        private void dgvCitas_DoubleClick(object sender, EventArgs e)
        {
            int posicion;
            string codigoCitas, Encargado, Empresa, EstadoCi, Comentarios;
            DateTime Fecha, Hora;
            posicion = dgvCitas.CurrentRow.Index;

            codigoCitas = dgvCitas[0, posicion].Value.ToString();
            Encargado = dgvCitas[1, posicion].Value.ToString();
            Empresa = dgvCitas[2, posicion].Value.ToString();
            Fecha = Convert.ToDateTime(dgvCitas[4, posicion].Value);  // Convertir a DateTime directamente
            Comentarios = dgvCitas[5, posicion].Value.ToString();
            Hora = DateTime.Today.Add((TimeSpan)dgvCitas[6, posicion].Value);  // Convertir a DateTime directamente
            EstadoCi = dgvCitas[7, posicion].Value.ToString();

            Citas formC = new Citas();

            // Mostrar el formulario
            formC.mostrarCodigo();
            formC.llenarModal(codigoCitas, Comentarios, Fecha, Hora, Encargado, Empresa, EstadoCi);
            formC.Show();
        }

        private void btnServicio_Click(object sender, EventArgs e)
        {
            int posicion;
            string codigoCita, servicio;
            posicion = dgvCitas.CurrentRow.Index;

            codigoCita = dgvCitas[0, posicion].Value.ToString();
            servicio = dgvCitas[3, posicion].Value.ToString();

            Servicios formS = new Servicios();

            if (servicio.Equals(""))
            {
                formS.ocultarCodigo();
                formS.cargarCodigoCita(codigoCita);
                formS.Show();
            }
            else if (servicio != null)
            {
                formS.mostrarCodigo();
                formS.cargarCodigoCita(codigoCita);
                formS.llenarModal(codigoCita);
                formS.Show();
            }
        }

        //Hover de botones del menu
        private void btnHome_MouseHover(object sender, EventArgs e)
        {
            //Hover cambiar imagen
            btnHome.BackgroundImage = Properties.Resources.hogar__1_;

        }

        private void btnHome_MouseLeave(object sender, EventArgs e)
        {
            //Hover regresar imagen
            btnHome.BackgroundImage = Properties.Resources.hogar;
        }

        private void btnEmpleados_MouseHover(object sender, EventArgs e)
        {
            //Hover cambiar imagen
            btnEmpleados.BackgroundImage = Properties.Resources.usuario_de_archivo__1_;
        }

        private void btnEmpleados_MouseLeave(object sender, EventArgs e)
        {
            //Hover regresar imagen
            btnEmpleados.BackgroundImage = Properties.Resources.usuario_de_archivo;
        }

        private void btnCitas_MouseHover(object sender, EventArgs e)
        {
            //Hover cambiar imagen
            btnCitas.BackgroundImage = Properties.Resources.calendario_reloj__1_;
        }

        private void btnCitas_MouseLeave(object sender, EventArgs e)
        {
            //Hover regresar imagen
            btnCitas.BackgroundImage = Properties.Resources.calendario_reloj;
        }

        private void btnEmpresas_MouseHover(object sender, EventArgs e)
        {
            btnEmpresas.BackgroundImage = Properties.Resources.edificio__1_;
        }

        private void btnEmpresas_MouseLeave(object sender, EventArgs e)
        {
            btnEmpresas.BackgroundImage = Properties.Resources.edificio;
        }

        private void btnEquipos_MouseHover(object sender, EventArgs e)
        {
            btnEquipos.BackgroundImage = Properties.Resources.herramientas__1_;
        }

        private void btnEquipos_MouseLeave(object sender, EventArgs e)
        {
            btnEquipos.BackgroundImage = Properties.Resources.herramientas;
        }

        private void btnExtras_MouseHover(object sender, EventArgs e)
        {
            btnExtras.BackgroundImage = Properties.Resources.ojo__2_;
        }

        private void btnExtras_MouseLeave(object sender, EventArgs e)
        {
            btnExtras.BackgroundImage = Properties.Resources.ojo__1_;
        }

        private void btnAgregarUb_Click(object sender, EventArgs e)
        {
            Ubicacion formU = new Ubicacion();

            // Mostrar el formulario
            formU.ocultarCodigo();
            formU.Show();
        }

        private void dgvUbicacion_DoubleClick(object sender, EventArgs e)
        {
            int posicion;
            string codigoUbicacion, laboratorio, ubiLab;
            posicion = dgvUbicacion.CurrentRow.Index;

            codigoUbicacion = dgvUbicacion[0, posicion].Value.ToString();
            laboratorio = dgvUbicacion[1, posicion].Value.ToString();
            ubiLab = dgvUbicacion[2, posicion].Value.ToString();

            Ubicacion formU = new Ubicacion();

            // Mostrar el formulario
            formU.mostrarCodigo();
            formU.llenarModal(codigoUbicacion, laboratorio, ubiLab);
            formU.Show();
        }

        private void btnEliminarUb_Click(object sender, EventArgs e)
        {
            int posicion = dgvUbicacion.CurrentRow.Index;
            string codigoUbicacion = dgvUbicacion[0, posicion].Value.ToString();
            Ubicacion formU = new Ubicacion();
            formU.eliminarUbicacion(codigoUbicacion);
        }

        private void btnAgregarEq_Click(object sender, EventArgs e)
        {
            Equipos formE = new Equipos();

            // Mostrar el formulario
            formE.ocultarCodigo();
            formE.Show();
        }

        private void dgvEquipos_DoubleClick(object sender, EventArgs e)
        {
            int posicion;
            string codigoEquipo, nombre, laboratorio, ubiLab;
            posicion = dgvEquipos.CurrentRow.Index;

            codigoEquipo = dgvEquipos[0, posicion].Value.ToString();
            nombre = dgvEquipos[1, posicion].Value.ToString();
            laboratorio = dgvEquipos[2, posicion].Value.ToString();
            ubiLab = dgvEquipos[3, posicion].Value.ToString();

            Equipos formE = new Equipos();

            // Mostrar el formulario
            formE.mostrarCodigo();
            formE.llenarModal(codigoEquipo, nombre, laboratorio, ubiLab);
            formE.Show();
        }

        private void btnEliminarEq_Click(object sender, EventArgs e)
        {
            int posicion = dgvEquipos.CurrentRow.Index;
            string codigoEquipo = dgvEquipos[0, posicion].Value.ToString();
            Equipos formE = new Equipos();
            formE.eliminarEquipo(codigoEquipo);

        }


        //Codigo de Milton-------------------------------Empresas
        private void btnAgregarEm_Click(object sender, EventArgs e)
        {
            Empresas formEmpresa = new Empresas();
            formEmpresa.ocultarCodigo();
            formEmpresa.Show();
        }

        private void dgvEmpresas_DoubleClick(object sender, EventArgs e)
        {
            int posicion;
            string codigoEmpresa, nombre, razonsocial, informacion, direccion, telefono, correo, encargado, categoria, estado;
            posicion = dgvEmpresas.CurrentRow.Index;

            codigoEmpresa = dgvEmpresas[0, posicion].Value.ToString();
            nombre = dgvEmpresas[1, posicion].Value.ToString();
            razonsocial = dgvEmpresas[2, posicion].Value.ToString();
            informacion = dgvEmpresas[3, posicion].Value.ToString();
            direccion = dgvEmpresas[4, posicion].Value.ToString();
            telefono = dgvEmpresas[5, posicion].Value.ToString();
            correo = dgvEmpresas[6, posicion].Value.ToString();

            encargado = dgvEmpresas[7, posicion].Value.ToString();

            categoria = dgvEmpresas[8, posicion].Value.ToString();

            estado = dgvEmpresas[9, posicion].Value.ToString();

            Empresas formEmpresa = new Empresas();

            // Mostrar el formulario
            formEmpresa.mostrarCodigo();
            formEmpresa.llenarModal(codigoEmpresa, nombre, razonsocial, informacion, direccion, telefono, correo, encargado, categoria, estado);
            formEmpresa.Show();
        }

        private void btnEliminarEm_Click(object sender, EventArgs e)
        {
            int posicion = dgvEmpresas.CurrentRow.Index;
            string codigoEmpresa = dgvEmpresas[0, posicion].Value.ToString();
            Empresas formEmpresa = new Empresas();
            formEmpresa.eliminarEmpresa(codigoEmpresa);
        }

        public void CargarDatosEmpresa()
        {
            try
            {
                tbcCruds.SelectedIndex = 3;
                dgvEmpresas.DataSource = null;
                dgvEmpresas.DataSource = EmpresasController.CargarEmpresas_Controller();
                dgvEmpresas.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos existentes en la base de datos, consulte con su administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //Codigo Milton encargados----------------------------

        private void btnAgregarEn_Click(object sender, EventArgs e)
        {
            Encargados formEncargados = new Encargados();
            formEncargados.ocultarCodigo();
            formEncargados.Show();
        }

        private void dgvEncargados_DoubleClick(object sender, EventArgs e)
        {
            int posicion;
            string codigoEncargado, nombre, codemp, codcar, codesten;
            DateTime fecha;

            posicion = dgvEncargados.CurrentRow.Index;

            codigoEncargado = dgvEncargados[0, posicion].Value.ToString();
            nombre = dgvEncargados[3, posicion].Value.ToString();
            fecha = Convert.ToDateTime(dgvRevisiones[4, posicion].Value);

            codemp = dgvEncargados[1, posicion].Value.ToString();

            codcar = dgvEncargados[2, posicion].Value.ToString();

            codesten = dgvEncargados[5, posicion].Value.ToString();



            Encargados formEncargados = new Encargados();

            // Mostrar el formulario
            formEncargados.mostrarCodigo();
            formEncargados.llenarModal(codigoEncargado, nombre, fecha, codemp, codcar, codesten);
            formEncargados.Show();
        }

        public void CargarDatosEncargado()
        {
            try
            {
                tbcCruds.SelectedIndex = 6;
                dgvEncargados.DataSource = null;
                dgvEncargados.DataSource = EncargadosController.CargarEncargados_Controller();
                dgvEncargados.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos existentes en la base de datos, consulte con su administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarEn_Click(object sender, EventArgs e)
        {
            int posicion = dgvEncargados.CurrentRow.Index;
            string codigoEncargado = dgvEncargados[0, posicion].Value.ToString();
            Encargados formE = new Encargados();
            formE.EliminarEncargado(codigoEncargado);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                dgvEmpleados.DataSource = UsuarioController.CargarUsuarios_Controller();
            }
            else
            {
                dgvEmpleados.DataSource = UsuarioController.BuscarUsuario(txtBuscar.Text);
            }
        }

        private void txtBuscarEn_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarEn.Text))
            {
                dgvEncargados.DataSource = EncargadosController.CargarEncargados_Controller();
            }
            else
            {
                dgvEncargados.DataSource = EncargadosController.BuscarEncargado(txtBuscarEn.Text);
            }
        }

        private void txtBuscarC_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarC.Text))
            {
                dgvCitas.DataSource = CitasController.CargarCitas_Controller();
            }
            else
            {
                dgvCitas.DataSource = CitasController.BuscarCita(txtBuscarC.Text);
            }
        }

        private void txtBuscarEq_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarEq.Text))
            {
                dgvEquipos.DataSource = EquiposController.CargarEquipos_Controller();
            }
            else
            {
                dgvEquipos.DataSource = EquiposController.BuscarEquipos(txtBuscarEq.Text);
            }
        }

        private void txtBuscarUb_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarUb.Text))
            {
                dgvUbicacion.DataSource = UbicacionController.CargarUbicacion_Controller();
            }
            else
            {
                dgvUbicacion.DataSource = UbicacionController.BuscarUbicacion(txtBuscarUb.Text);
            }
        }

        private void btnAgregarSe_Click(object sender, EventArgs e)
        {
            
            Revision formRevision = new Revision();
            formRevision.ocultarCodigo();
            formRevision.Show();
        }

        private void dgvRevisiones_DoubleClick(object sender, EventArgs e)
        {
            int posicion;
            string CodigoRevision, Comentario,  Equipo, Empleado, Motivo, EstadoR;
            DateTime Fecha;

            posicion = dgvRevisiones.CurrentRow.Index;

            CodigoRevision = dgvRevisiones[0, posicion].Value.ToString();
            Equipo = dgvRevisiones[1, posicion].Value.ToString();
            Empleado = dgvRevisiones[2, posicion].Value.ToString();
            Motivo = dgvRevisiones[3, posicion].Value.ToString();
            EstadoR = dgvRevisiones[6, posicion].Value.ToString();
            Comentario = dgvRevisiones[4, posicion].Value.ToString();
            Fecha = Convert.ToDateTime(dgvRevisiones[5, posicion].Value);  // Convertir a DateTime directamente



            Revision formRevision = new Revision();

            // Mostrar el formulario
            formRevision.mostrarCodigo();
            formRevision.llenarModal(CodigoRevision, Comentario, Fecha, Equipo, Empleado, Motivo, EstadoR);
            formRevision.Show();
        }

        private void btnEliminarSe_Click(object sender, EventArgs e)
        {
            int posicion = dgvRevisiones.CurrentRow.Index;
            string codigoRevision = dgvRevisiones[0, posicion].Value.ToString();
            Revision formRevision = new Revision();
            formRevision.eliminarRevision(codigoRevision);
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            DialogResult dr1 = MessageBox.Show("¿Está seguro de cerrar sesión?", "Confirmación de Cierre de Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr1 == DialogResult.Yes)
            {
                this.Hide();
                Form1 frmlogin = new Form1();
                frmlogin.Show();
            }
        }

        private void txtBuscarEm_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarEm.Text))
            {
                dgvEmpresas.DataSource = EmpresasController.CargarEmpresas_Controller();
            }
            else
            {
                dgvEmpresas.DataSource = EmpresasController.BuscarEmpresa(txtBuscarEm.Text);
            }
        }
        private void txtBuscarRe_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarRe.Text))
            {
                dgvRevisiones.DataSource = RevisionController.CargarRevision_Controller();
            }
            else
            {
                dgvRevisiones.DataSource = RevisionController.BuscarRevision(txtBuscarRe.Text);
            }
        }

        private void btnUsuario_MouseHover(object sender, EventArgs e)
        {
            //Hover cambiar imagen
            btnUsuario.BackgroundImage = Properties.Resources.salida__1_;
        }


        private void btnUsuario_MouseLeave(object sender, EventArgs e)
        {
            btnUsuario.BackgroundImage = Properties.Resources.salida;
        }
    }
}
