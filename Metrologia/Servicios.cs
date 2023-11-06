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
        Dashboard dash = new Dashboard();

        public Servicios()
        {
            InitializeComponent();
            cargarArea();
            cargarEmpleado();
            cargarTipoSer();
            cargarEstadoSer();
        }
        void cargarArea() 
        {
            cbArea.DataSource = ServicioController.CargarArea_Controller();
            cbArea.DisplayMember = "Nombre";
            cbArea.ValueMember = "CodigoArea";
        }
        void cargarEmpleado()
        {
            cbEmpleado.DataSource = ServicioController.CargarEmpleado_Controller();
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
            pnlCodigoServicio.Visible = false;
            txtCodigoServicio.Visible = false;
        }

        public void mostrarCodigo()
        {
            pnlCodigoServicio.Visible = true;
            txtCodigoServicio.Visible = true;
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
            if (txtCodigoServicio.Visible == true)
            {
                modificarServicio();
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
            serviciocontrol.Fecha = Fecha.ToString("MM/dd/yyyy");
            serviciocontrol.Hora = Convert.ToString(dtpHoraEntrega.Value);
            serviciocontrol.Area = Convert.ToInt16(cbArea.SelectedValue); ;
            serviciocontrol.Empleado = Convert.ToInt16(cbEmpleado.SelectedValue);
            serviciocontrol.TipoSer = Convert.ToInt16(cbTipoSer.SelectedValue);
            serviciocontrol.EstadoSer = Convert.ToInt16(cbEstadoSer.SelectedValue);

            if (serviciocontrol.AgregarServicio() == true)
            {
                DataTable codigoServi = ServicioController.obtenerServicio();
                object valorServi = codigoServi.Rows[0]["UltimoID"];
                citacontrol.Servicio = int.Parse(valorServi.ToString());
                citacontrol.codigoCita = txtcodigoCita.Text;

                if (citacontrol.servicioCitas() == true)
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
            serviciocontrol.Fecha = Fecha.ToString("MM/dd/yyyy");
            serviciocontrol.Hora = Convert.ToString(dtpHoraEntrega.Value);
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
        public void llenarModal(string Servicio)
        {
            string[] formatos = { "d/M/yyyy H:mm:ss", "M/d/yyyy H:mm:ss" };
            ServicioController objselect = new ServicioController();

            DataTable servicioModal = objselect.CargarModal_Controller(Servicio);
            txtCodigoServicio.Text = servicioModal.Rows[0]["CodigoServicio"].ToString();
            txtPrecio.Text = servicioModal.Rows[0]["Precio"].ToString();
            txtComentarioServicio.Text = servicioModal.Rows[0]["Comentarios"].ToString();
            string Fecha = servicioModal.Rows[0]["FechaEntrega"].ToString();
            string Hora = servicioModal.Rows[0]["HoraEntrega"].ToString();
            dtpFechaEntrega.Value = DateTime.ParseExact(Fecha, formatos, CultureInfo.InvariantCulture, DateTimeStyles.None);
            dtpHoraEntrega.Value = DateTime.ParseExact(Hora, "HH:mm:ss", CultureInfo.InvariantCulture);

            cargarArea();            
            object valorA = servicioModal.Rows[0]["CodigoArea"];
            cbArea.SelectedIndex = int.Parse(valorA.ToString()) - 1;

            cargarEmpleado();      
            object valorEm = servicioModal.Rows[0]["CodigoEmpleado"];
            cbEmpleado.SelectedIndex = int.Parse(valorEm.ToString()) - 1;

            cargarTipoSer();
            object valorTipoS = servicioModal.Rows[0]["CodigoTipo"];
            cbTipoSer.SelectedIndex = int.Parse(valorTipoS.ToString()) - 1;

            cargarEstadoSer();
            object valorEstadoS = servicioModal.Rows[0]["CodigoEstadoSe"];
            cbEstadoSer.SelectedIndex = int.Parse(valorEstadoS.ToString()) - 1;
        }
    }
}