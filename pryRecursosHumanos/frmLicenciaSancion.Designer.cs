namespace pryRecursosHumanos
{
    partial class frmLicenciaSancion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLicenciaSancion));
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvListar = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblNombreDato = new System.Windows.Forms.Label();
            this.cboDatos = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pcbCerrar = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MistyRose;
            this.panel3.Controls.Add(this.lblTitulo);
            this.panel3.Controls.Add(this.dgvListar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 164);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(597, 289);
            this.panel3.TabIndex = 11;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(31, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(38, 24);
            this.lblTitulo.TabIndex = 44;
            this.lblTitulo.Text = "----";
            // 
            // dgvListar
            // 
            this.dgvListar.AllowUserToAddRows = false;
            this.dgvListar.AllowUserToDeleteRows = false;
            this.dgvListar.BackgroundColor = System.Drawing.Color.MistyRose;
            this.dgvListar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvListar.Location = new System.Drawing.Point(0, 55);
            this.dgvListar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvListar.Name = "dgvListar";
            this.dgvListar.ReadOnly = true;
            this.dgvListar.RowHeadersWidth = 51;
            this.dgvListar.RowTemplate.Height = 24;
            this.dgvListar.Size = new System.Drawing.Size(597, 234);
            this.dgvListar.TabIndex = 16;
            this.dgvListar.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvListar_RowHeaderMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtObservaciones);
            this.panel1.Controls.Add(this.dtpFechaInicio);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.lblNombreDato);
            this.panel1.Controls.Add(this.cboDatos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 131);
            this.panel1.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(32, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(138, 76);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(239, 49);
            this.txtObservaciones.TabIndex = 14;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CalendarMonthBackground = System.Drawing.SystemColors.HotTrack;
            this.dtpFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(279, 30);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(98, 21);
            this.dtpFechaInicio.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(276, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Fecha de inicio:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregar.BackgroundImage = global::pryRecursosHumanos.Properties.Resources.mas;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAgregar.Location = new System.Drawing.Point(392, 78);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(15, 15);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblNombreDato
            // 
            this.lblNombreDato.AutoSize = true;
            this.lblNombreDato.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblNombreDato.Location = new System.Drawing.Point(32, 4);
            this.lblNombreDato.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreDato.Name = "lblNombreDato";
            this.lblNombreDato.Size = new System.Drawing.Size(19, 16);
            this.lblNombreDato.TabIndex = 8;
            this.lblNombreDato.Text = "---";
            // 
            // cboDatos
            // 
            this.cboDatos.BackColor = System.Drawing.Color.SeaShell;
            this.cboDatos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDatos.FormattingEnabled = true;
            this.cboDatos.Location = new System.Drawing.Point(35, 30);
            this.cboDatos.Name = "cboDatos";
            this.cboDatos.Size = new System.Drawing.Size(192, 21);
            this.cboDatos.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.pcbCerrar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(597, 33);
            this.panel2.TabIndex = 9;
            // 
            // pcbCerrar
            // 
            this.pcbCerrar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pcbCerrar.Image = ((System.Drawing.Image)(resources.GetObject("pcbCerrar.Image")));
            this.pcbCerrar.Location = new System.Drawing.Point(563, 9);
            this.pcbCerrar.Name = "pcbCerrar";
            this.pcbCerrar.Size = new System.Drawing.Size(22, 18);
            this.pcbCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbCerrar.TabIndex = 12;
            this.pcbCerrar.TabStop = false;
            this.pcbCerrar.Click += new System.EventHandler(this.pcbCerrar_Click);
            // 
            // frmLicenciaSancion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 453);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLicenciaSancion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLicenciaSancion";
            this.Load += new System.EventHandler(this.frmLicenciaSancion_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbCerrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvListar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblNombreDato;
        private System.Windows.Forms.ComboBox cboDatos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pcbCerrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtObservaciones;
    }
}