﻿using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Controlador;
using Guna.UI2.WinForms;


namespace Metrologia
{

    public partial class Form1 : Form
    {
        string usuario;
        string txt2;
        
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
                usuario = txtUsuario.Text;
                txt2 = txtContra.Text;
                formularios.DashboardFRM = new Dashboard(usuario, txt2);

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

        private void txtContra_IconRightClick(object sender, EventArgs e)
        {
            txtContra.PasswordChar = '\0';
            this.txtContra.IconRight = global::Metrologia.Properties.Resources.ojo_cruzado;
        }

        private void txtContra_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtContra.PasswordChar = '*';
            this.txtContra.IconRight = global::Metrologia.Properties.Resources.ojo__1_;
            
        }


    }
}
