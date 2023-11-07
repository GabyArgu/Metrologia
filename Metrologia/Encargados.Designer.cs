namespace Metrologia
{
    partial class Encargados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.PictureBox();
            this.cbCargo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAceptar = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            this.cbEmpresa = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtCodigoEncargado = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNombreEncargado = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlCodigoEncargado = new System.Windows.Forms.Panel();
            this.pnl9 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cbEstado = new Guna.UI2.WinForms.Guna2ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.elipEncarg = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecha = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dgcEnca = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 32);
            this.panel1.TabIndex = 26;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackgroundImage = global::Metrologia.Properties.Resources.x;
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Location = new System.Drawing.Point(480, 6);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(20, 20);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.TabStop = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // cbCargo
            // 
            this.cbCargo.BackColor = System.Drawing.Color.Transparent;
            this.cbCargo.BorderRadius = 12;
            this.cbCargo.CustomizableEdges.BottomLeft = false;
            this.cbCargo.CustomizableEdges.TopLeft = false;
            this.cbCargo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCargo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.cbCargo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(188)))), ((int)(((byte)(43)))));
            this.cbCargo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(188)))), ((int)(((byte)(43)))));
            this.cbCargo.Font = new System.Drawing.Font("Mohave Medium", 15F, System.Drawing.FontStyle.Bold);
            this.cbCargo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbCargo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(188)))), ((int)(((byte)(43)))));
            this.cbCargo.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(188)))), ((int)(((byte)(43)))));
            this.cbCargo.ItemHeight = 30;
            this.cbCargo.Location = new System.Drawing.Point(72, 388);
            this.cbCargo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCargo.Name = "cbCargo";
            this.cbCargo.Size = new System.Drawing.Size(413, 36);
            this.cbCargo.TabIndex = 66;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(130)))));
            this.btnAceptar.BorderRadius = 8;
            this.btnAceptar.BorderThickness = 1;
            this.btnAceptar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAceptar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAceptar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAceptar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAceptar.FillColor = System.Drawing.Color.White;
            this.btnAceptar.Font = new System.Drawing.Font("Mohave SemiBold", 16F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.ForeColor = System.Drawing.Color.Black;
            this.btnAceptar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(188)))), ((int)(((byte)(43)))));
            this.btnAceptar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(214)))));
            this.btnAceptar.Location = new System.Drawing.Point(346, 527);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAceptar.MaximumSize = new System.Drawing.Size(525, 64);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(139, 47);
            this.btnAceptar.TabIndex = 65;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Animated = true;
            this.btnCancelar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(130)))));
            this.btnCancelar.BorderRadius = 8;
            this.btnCancelar.BorderThickness = 1;
            this.btnCancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancelar.FillColor = System.Drawing.Color.White;
            this.btnCancelar.Font = new System.Drawing.Font("Mohave SemiBold", 16F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(188)))), ((int)(((byte)(43)))));
            this.btnCancelar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(214)))));
            this.btnCancelar.Location = new System.Drawing.Point(149, 527);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.MaximumSize = new System.Drawing.Size(525, 64);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(147, 47);
            this.btnCancelar.TabIndex = 64;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.cbEmpresa.BorderRadius = 12;
            this.cbEmpresa.CustomizableEdges.BottomLeft = false;
            this.cbEmpresa.CustomizableEdges.TopLeft = false;
            this.cbEmpresa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.cbEmpresa.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(188)))), ((int)(((byte)(43)))));
            this.cbEmpresa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(188)))), ((int)(((byte)(43)))));
            this.cbEmpresa.Font = new System.Drawing.Font("Mohave Medium", 15F, System.Drawing.FontStyle.Bold);
            this.cbEmpresa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbEmpresa.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(188)))), ((int)(((byte)(43)))));
            this.cbEmpresa.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(188)))), ((int)(((byte)(43)))));
            this.cbEmpresa.ItemHeight = 30;
            this.cbEmpresa.Location = new System.Drawing.Point(72, 319);
            this.cbEmpresa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(413, 36);
            this.cbEmpresa.TabIndex = 60;
            // 
            // txtCodigoEncargado
            // 
            this.txtCodigoEncargado.BackColor = System.Drawing.Color.Transparent;
            this.txtCodigoEncargado.BorderRadius = 12;
            this.txtCodigoEncargado.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCodigoEncargado.CustomizableEdges.BottomLeft = false;
            this.txtCodigoEncargado.CustomizableEdges.TopLeft = false;
            this.txtCodigoEncargado.DefaultText = "";
            this.txtCodigoEncargado.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCodigoEncargado.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCodigoEncargado.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodigoEncargado.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodigoEncargado.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.txtCodigoEncargado.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(188)))), ((int)(((byte)(43)))));
            this.txtCodigoEncargado.FocusedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(188)))), ((int)(((byte)(43)))));
            this.txtCodigoEncargado.Font = new System.Drawing.Font("Mohave Medium", 15F, System.Drawing.FontStyle.Bold);
            this.txtCodigoEncargado.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(188)))), ((int)(((byte)(43)))));
            this.txtCodigoEncargado.Location = new System.Drawing.Point(72, 111);
            this.txtCodigoEncargado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCodigoEncargado.MaximumSize = new System.Drawing.Size(475, 57);
            this.txtCodigoEncargado.Name = "txtCodigoEncargado";
            this.txtCodigoEncargado.PasswordChar = '\0';
            this.txtCodigoEncargado.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtCodigoEncargado.PlaceholderText = "Codigo de Encargado";
            this.txtCodigoEncargado.SelectedText = "";
            this.txtCodigoEncargado.Size = new System.Drawing.Size(413, 47);
            this.txtCodigoEncargado.TabIndex = 71;
            // 
            // txtNombreEncargado
            // 
            this.txtNombreEncargado.BackColor = System.Drawing.Color.Transparent;
            this.txtNombreEncargado.BorderRadius = 12;
            this.txtNombreEncargado.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNombreEncargado.CustomizableEdges.BottomLeft = false;
            this.txtNombreEncargado.CustomizableEdges.TopLeft = false;
            this.txtNombreEncargado.DefaultText = "";
            this.txtNombreEncargado.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNombreEncargado.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNombreEncargado.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNombreEncargado.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNombreEncargado.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.txtNombreEncargado.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(188)))), ((int)(((byte)(43)))));
            this.txtNombreEncargado.FocusedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(188)))), ((int)(((byte)(43)))));
            this.txtNombreEncargado.Font = new System.Drawing.Font("Mohave Medium", 15F, System.Drawing.FontStyle.Bold);
            this.txtNombreEncargado.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(188)))), ((int)(((byte)(43)))));
            this.txtNombreEncargado.Location = new System.Drawing.Point(72, 180);
            this.txtNombreEncargado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombreEncargado.MaximumSize = new System.Drawing.Size(475, 57);
            this.txtNombreEncargado.Name = "txtNombreEncargado";
            this.txtNombreEncargado.PasswordChar = '\0';
            this.txtNombreEncargado.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtNombreEncargado.PlaceholderText = "Digite el nombre del encargado";
            this.txtNombreEncargado.SelectedText = "";
            this.txtNombreEncargado.Size = new System.Drawing.Size(413, 47);
            this.txtNombreEncargado.TabIndex = 70;
            // 
            // pnlCodigoEncargado
            // 
            this.pnlCodigoEncargado.BackColor = System.Drawing.Color.Transparent;
            this.pnlCodigoEncargado.BackgroundImage = global::Metrologia.Properties.Resources.codigo;
            this.pnlCodigoEncargado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlCodigoEncargado.ForeColor = System.Drawing.Color.Coral;
            this.pnlCodigoEncargado.Location = new System.Drawing.Point(21, 110);
            this.pnlCodigoEncargado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlCodigoEncargado.Name = "pnlCodigoEncargado";
            this.pnlCodigoEncargado.Size = new System.Drawing.Size(51, 50);
            this.pnlCodigoEncargado.TabIndex = 69;
            // 
            // pnl9
            // 
            this.pnl9.BackColor = System.Drawing.Color.Transparent;
            this.pnl9.BackgroundImage = global::Metrologia.Properties.Resources.letras;
            this.pnl9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnl9.ForeColor = System.Drawing.Color.Coral;
            this.pnl9.Location = new System.Drawing.Point(21, 179);
            this.pnl9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl9.Name = "pnl9";
            this.pnl9.Size = new System.Drawing.Size(51, 50);
            this.pnl9.TabIndex = 68;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.BackgroundImage = global::Metrologia.Properties.Resources.casco;
            this.panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel7.ForeColor = System.Drawing.Color.Coral;
            this.panel7.Location = new System.Drawing.Point(21, 386);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(51, 50);
            this.panel7.TabIndex = 67;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.BackgroundImage = global::Metrologia.Properties.Resources.fecha;
            this.panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel8.ForeColor = System.Drawing.Color.Coral;
            this.panel8.Location = new System.Drawing.Point(21, 248);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(51, 50);
            this.panel8.TabIndex = 63;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BackgroundImage = global::Metrologia.Properties.Resources.empre;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel6.ForeColor = System.Drawing.Color.Coral;
            this.panel6.Location = new System.Drawing.Point(21, 317);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(51, 50);
            this.panel6.TabIndex = 62;
            // 
            // cbEstado
            // 
            this.cbEstado.BackColor = System.Drawing.Color.Transparent;
            this.cbEstado.BorderRadius = 12;
            this.cbEstado.CustomizableEdges.BottomLeft = false;
            this.cbEstado.CustomizableEdges.TopLeft = false;
            this.cbEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.cbEstado.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(188)))), ((int)(((byte)(43)))));
            this.cbEstado.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(188)))), ((int)(((byte)(43)))));
            this.cbEstado.Font = new System.Drawing.Font("Mohave Medium", 15F, System.Drawing.FontStyle.Bold);
            this.cbEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbEstado.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(188)))), ((int)(((byte)(43)))));
            this.cbEstado.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(188)))), ((int)(((byte)(43)))));
            this.cbEstado.ItemHeight = 30;
            this.cbEstado.Location = new System.Drawing.Point(72, 457);
            this.cbEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(413, 36);
            this.cbEstado.TabIndex = 73;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::Metrologia.Properties.Resources.tipo;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.ForeColor = System.Drawing.Color.Coral;
            this.panel2.Location = new System.Drawing.Point(21, 455);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(51, 50);
            this.panel2.TabIndex = 74;
            // 
            // elipEncarg
            // 
            this.elipEncarg.BorderRadius = 10;
            this.elipEncarg.TargetControl = this;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mohave SemiBold", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(39)))), ((int)(((byte)(77)))));
            this.label1.Location = new System.Drawing.Point(15, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 52);
            this.label1.TabIndex = 75;
            this.label1.Text = "Encargados";
            // 
            // dtpFecha
            // 
            this.dtpFecha.BackColor = System.Drawing.Color.Transparent;
            this.dtpFecha.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dtpFecha.BorderRadius = 12;
            this.dtpFecha.Checked = true;
            this.dtpFecha.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.dtpFecha.CustomFormat = "MM/dd/yyyy";
            this.dtpFecha.CustomizableEdges.BottomLeft = false;
            this.dtpFecha.CustomizableEdges.TopLeft = false;
            this.dtpFecha.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.dtpFecha.Font = new System.Drawing.Font("Mohave Regular", 12F);
            this.dtpFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFecha.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(188)))), ((int)(((byte)(43)))));
            this.dtpFecha.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.dtpFecha.Location = new System.Drawing.Point(72, 250);
            this.dtpFecha.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFecha.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.ShadowDecoration.Color = System.Drawing.Color.BlanchedAlmond;
            this.dtpFecha.Size = new System.Drawing.Size(413, 47);
            this.dtpFecha.TabIndex = 76;
            this.dtpFecha.UseTransparentBackground = true;
            this.dtpFecha.Value = new System.DateTime(2023, 11, 6, 2, 3, 31, 380);
            // 
            // dgcEnca
            // 
            this.dgcEnca.DockIndicatorTransparencyValue = 0.6D;
            this.dgcEnca.TargetControl = this.panel1;
            this.dgcEnca.UseTransparentDrag = true;
            // 
            // Encargados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(226)))), ((int)(((byte)(144)))));
            this.ClientSize = new System.Drawing.Size(516, 606);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlCodigoEncargado);
            this.Controls.Add(this.txtCodigoEncargado);
            this.Controls.Add(this.txtNombreEncargado);
            this.Controls.Add(this.pnl9);
            this.Controls.Add(this.cbCargo);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.cbEmpresa);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Encargados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encargados";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnSalir;
        private Guna.UI2.WinForms.Guna2ComboBox cbCargo;
        private System.Windows.Forms.Panel panel7;
        private Guna.UI2.WinForms.Guna2Button btnAceptar;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
        private System.Windows.Forms.Panel panel8;
        private Guna.UI2.WinForms.Guna2ComboBox cbEmpresa;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel pnlCodigoEncargado;
        private Guna.UI2.WinForms.Guna2TextBox txtCodigoEncargado;
        private Guna.UI2.WinForms.Guna2TextBox txtNombreEncargado;
        private System.Windows.Forms.Panel pnl9;
        private Guna.UI2.WinForms.Guna2ComboBox cbEstado;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Elipse elipEncarg;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFecha;
        private Guna.UI2.WinForms.Guna2DragControl dgcEnca;
    }
}