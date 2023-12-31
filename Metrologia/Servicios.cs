﻿using Controlador;
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

namespace Metrologia
{
    public partial class Servicios : Form
    {
        Dashboard dash = (Dashboard)formularios.DashboardFRM;

        public Servicios()
        {
            InitializeComponent();
            cargarArea();
            cargarEmpleado();
            cargarTipoSer();
            cargarEstadoSer();
            dtpFechaEntrega.Value = DateTime.Now;
            dtpHoraEntrega.Value = DateTime.Now;
            dtpHoraEntrega.CustomFormat = "hh:mm tt";
            dtpHoraEntrega.Format = DateTimePickerFormat.Custom;
            // Asocia el evento Validating con el control DateTimePicker
            dtpFechaEntrega.Validating += dtpFecha_Validating;
        }

        private void dtpFecha_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DateTime selectedDate = dtpFechaEntrega.Value;
            DateTime currentDate = DateTime.Now;

            // Verifica si la fecha seleccionada es igual o posterior a la fecha actual
            if (selectedDate >= currentDate)
            {
                // Muestra un mensaje de error
                MessageBox.Show("Selecciona una fecha anterior a la fecha actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; // Cancela la validación
            }
        }



        void cargarArea()
        {
            cbArea.DataSource = ServicioController.CargarArea_Controller();
            cbArea.DisplayMember = "Nombre";
            cbArea.ValueMember = "CodigoArea";
        }
        void cargarEmpleado()
        {
            cbEmpleado.DataSource = ServicioController.CargarEmpleado_Controller(dash.usua, dash.txt3);
            cbEmpleado.DisplayMember = "Nombre";
            cbEmpleado.ValueMember = "CodigoEmpleado";
        }
        void cargarTipoSer()
        {
            cbTipoSer.DataSource = ServicioController.CargarTipoSer_Controller();
            cbTipoSer.DisplayMember = "Nombre";
            cbTipoSer.ValueMember = "CodigoTipo";
        }
        void cargarEstadoSer()
        {
            cbEstadoSer.DataSource = ServicioController.CargarEstadoSer_Controller();
            cbEstadoSer.DisplayMember = "Nombre";
            cbEstadoSer.ValueMember = "CodigoEstadoSe";
        }
        public void ocultarCodigo()
        {
            pnlCodigoServicio.Enabled = false;
            txtCodigoServicio.Enabled = false;
        }

        public void mostrarCodigo()
        {
            pnlCodigoServicio.Enabled = true;
            txtCodigoServicio.Enabled = true;
        }
        public void cargarCodigoCita(string codigoCita)
        {
            txtcodigoCita.Text = codigoCita;
            txtcodigoCita.Visible = false;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCodigoServicio.Enabled == true)
            {
                if (dtpFechaEntrega.Value > ServicioController.GetFechaCita(int.Parse(txtcodigoCita.Text)))
                {
                    modificarServicio();
                }
                else
                {
                    MessageBox.Show("La fecha del servicio debe ser mayor a la fecha de la cita");
                }
            }
            else
            {
                agregarServicio();
            }
        }
        void agregarServicio()
        {

            ServicioController serviciocontrol = new ServicioController();
            CitasController citacontrol = new CitasController();

            serviciocontrol.Comentarios = txtComentarioServicio.Text;
            serviciocontrol.Precio = txtPrecio.Text;
            DateTime Fecha = dtpFechaEntrega.Value;
            serviciocontrol.Fecha = Fecha;
            DateTime Hora = dtpHoraEntrega.Value;
            serviciocontrol.Hora = Hora;
            serviciocontrol.Area = Convert.ToInt16(cbArea.SelectedValue);
            serviciocontrol.Empleado = Convert.ToInt16(cbEmpleado.SelectedValue);
            serviciocontrol.TipoSer = Convert.ToInt16(cbTipoSer.SelectedValue);
            serviciocontrol.EstadoSer = Convert.ToInt16(cbEstadoSer.SelectedValue);

            if (serviciocontrol.AgregarServicio() == true)
            {
                DataTable codigoServi = ServicioController.obtenerServicio();
                object valorServi = codigoServi.Rows[0]["UltimoID"];
                citacontrol.Servicio = int.Parse(valorServi.ToString());
                citacontrol.codigoCita = txtcodigoCita.Text;

                if (citacontrol.servicioCitas() == true && citacontrol.citasServicio() == true)
                {
                    MessageBox.Show("Servicio agregado con exito");
                    this.Hide();
                    dash.CargarDatosCitas();
                    dash.Refresh();
                }
                else
                {
                    MessageBox.Show("No se pudo enlacar el servicio con la cita");
                }
            }
            else
            {
                MessageBox.Show("Error al agregar servicio");
            }
        }
        void modificarServicio()
        {
            ServicioController serviciocontrol = new ServicioController();

            serviciocontrol.codigoServicio = txtCodigoServicio.Text;
            serviciocontrol.Comentarios = txtComentarioServicio.Text;
            serviciocontrol.Precio = txtPrecio.Text;
            DateTime Fecha = dtpFechaEntrega.Value;
            serviciocontrol.Fecha = Fecha;
            DateTime Hora = dtpHoraEntrega.Value;
            serviciocontrol.Hora = Hora;
            serviciocontrol.Area = Convert.ToInt16(cbArea.SelectedValue); ;
            serviciocontrol.Empleado = Convert.ToInt16(cbEmpleado.SelectedValue);
            serviciocontrol.TipoSer = Convert.ToInt16(cbTipoSer.SelectedValue);
            serviciocontrol.EstadoSer = Convert.ToInt16(cbEstadoSer.SelectedValue);

            if (serviciocontrol.ActualizarServicio() == true)
            {
                MessageBox.Show("Servicio actualizado con exito");
                this.Hide();
                dash.CargarDatosCitas();
                dash.Refresh();
            }
            else
            {
                MessageBox.Show("Error al actualizar servicio");
            }
        }
        public void llenarModal(string codigoCita)
        {
            ServicioController objselect = new ServicioController();

            DataTable servicioModal = objselect.CargarModal_Controller(codigoCita);
            txtCodigoServicio.Text = servicioModal.Rows[0]["CodigoServicio"].ToString();
            txtPrecio.Text = servicioModal.Rows[0]["Precio"].ToString();
            txtComentarioServicio.Text = servicioModal.Rows[0]["Comentarios"].ToString();

            DateTime Fecha = (DateTime)servicioModal.Rows[0]["FechaEntrega"];
            DateTime Hora;
            if (DateTime.TryParse(servicioModal.Rows[0]["HoraEntrega"].ToString(), out Hora))
            {
                // La conversión fue exitosa
                dtpHoraEntrega.Value = Hora;
            }
            else
            {
                // Manejar el caso en el que la conversión no es exitosa
                MessageBox.Show("No se puede convertir el valor de HoraEntrega a DateTime.");
            }
            dtpFechaEntrega.Value = Fecha;


            cargarArea();
            object valorA = servicioModal.Rows[0]["CodigoArea"];
            cbArea.SelectedIndex = int.Parse(valorA.ToString()) - 1;

            cargarEmpleado();

            cargarTipoSer();
            object valorTipoS = servicioModal.Rows[0]["CodigoTipo"];
            cbTipoSer.SelectedIndex = int.Parse(valorTipoS.ToString()) - 1;

            cargarEstadoSer();
            object valorEstadoS = servicioModal.Rows[0]["CodigoEstadoSe"];
            cbEstadoSer.SelectedIndex = int.Parse(valorEstadoS.ToString()) - 1;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            // Eliminar cualquier formato existente
            string textoSinFormato = txtPrecio.Text.Replace("$", "").Replace(",", "");

            if (decimal.TryParse(textoSinFormato, out decimal valor))
            {
                // Formatear el valor como dinero con comas y el símbolo "$"
                txtPrecio.Text = valor.ToString("C");
            }
            else
            {
                // Si la entrada no es válida, mostrar un mensaje de error o restaurar el valor anterior
                MessageBox.Show("Ingrese un valor válido.");
                txtPrecio.Text = string.Empty; // Puedes usar el valor anterior si lo tienes almacenado
            }

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Asegurarse de que el carácter ingresado sea un dígito o una coma
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Solo permitir una coma decimal
            if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Codigo formE = new Codigo();

            // Mostrar el formulario
            formE.Show();
        }
    }
}
