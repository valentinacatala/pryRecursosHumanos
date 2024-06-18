namespace pryRecursosHumanos
{
    partial class frmConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsulta));
            this.panel2 = new System.Windows.Forms.Panel();
            this.pcbCerrar = new System.Windows.Forms.PictureBox();
            this.pcbMinimizar = new System.Windows.Forms.PictureBox();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.btnListarTodo = new System.Windows.Forms.Button();
            this.dgvListar = new System.Windows.Forms.DataGridView();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.txtListarApellido = new System.Windows.Forms.TextBox();
            this.label90 = new System.Windows.Forms.Label();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnListarApellido = new System.Windows.Forms.Button();
            this.dgvListarApellido = new System.Windows.Forms.DataGridView();
            this.tabPage16 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.cboEstados = new System.Windows.Forms.ComboBox();
            this.btnBorrarEstado = new System.Windows.Forms.Button();
            this.btnListarEstado = new System.Windows.Forms.Button();
            this.dgvListarEstado = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMinimizar)).BeginInit();
            this.tabControl4.SuspendLayout();
            this.tabPage13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).BeginInit();
            this.tabPage14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarApellido)).BeginInit();
            this.tabPage16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarEstado)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.pcbCerrar);
            this.panel2.Controls.Add(this.pcbMinimizar);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(590, 33);
            this.panel2.TabIndex = 5;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // pcbCerrar
            // 
            this.pcbCerrar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pcbCerrar.Image = ((System.Drawing.Image)(resources.GetObject("pcbCerrar.Image")));
            this.pcbCerrar.Location = new System.Drawing.Point(556, 10);
            this.pcbCerrar.Name = "pcbCerrar";
            this.pcbCerrar.Size = new System.Drawing.Size(22, 18);
            this.pcbCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbCerrar.TabIndex = 12;
            this.pcbCerrar.TabStop = false;
            this.pcbCerrar.Click += new System.EventHandler(this.pcbCerrar_Click);
            // 
            // pcbMinimizar
            // 
            this.pcbMinimizar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pcbMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("pcbMinimizar.Image")));
            this.pcbMinimizar.Location = new System.Drawing.Point(527, 10);
            this.pcbMinimizar.Margin = new System.Windows.Forms.Padding(4);
            this.pcbMinimizar.Name = "pcbMinimizar";
            this.pcbMinimizar.Size = new System.Drawing.Size(22, 18);
            this.pcbMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbMinimizar.TabIndex = 11;
            this.pcbMinimizar.TabStop = false;
            this.pcbMinimizar.Click += new System.EventHandler(this.pcbMinimizar_Click);
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage13);
            this.tabControl4.Controls.Add(this.tabPage14);
            this.tabControl4.Controls.Add(this.tabPage16);
            this.tabControl4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl4.Location = new System.Drawing.Point(-5, 35);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(595, 605);
            this.tabControl4.TabIndex = 6;
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.btnListarTodo);
            this.tabPage13.Controls.Add(this.dgvListar);
            this.tabPage13.Location = new System.Drawing.Point(4, 24);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage13.Size = new System.Drawing.Size(587, 577);
            this.tabPage13.TabIndex = 0;
            this.tabPage13.Text = "Todos los empleados";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // btnListarTodo
            // 
            this.btnListarTodo.BackColor = System.Drawing.Color.MistyRose;
            this.btnListarTodo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnListarTodo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListarTodo.Location = new System.Drawing.Point(513, 10);
            this.btnListarTodo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnListarTodo.Name = "btnListarTodo";
            this.btnListarTodo.Size = new System.Drawing.Size(66, 25);
            this.btnListarTodo.TabIndex = 19;
            this.btnListarTodo.Text = "Listar";
            this.btnListarTodo.UseVisualStyleBackColor = false;
            this.btnListarTodo.Click += new System.EventHandler(this.btnListarTodo_Click);
            // 
            // dgvListar
            // 
            this.dgvListar.AllowUserToAddRows = false;
            this.dgvListar.AllowUserToDeleteRows = false;
            this.dgvListar.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgvListar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListar.Location = new System.Drawing.Point(13, 39);
            this.dgvListar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvListar.Name = "dgvListar";
            this.dgvListar.ReadOnly = true;
            this.dgvListar.RowHeadersWidth = 51;
            this.dgvListar.RowTemplate.Height = 24;
            this.dgvListar.Size = new System.Drawing.Size(566, 519);
            this.dgvListar.TabIndex = 15;
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.txtListarApellido);
            this.tabPage14.Controls.Add(this.label90);
            this.tabPage14.Controls.Add(this.btnBorrar);
            this.tabPage14.Controls.Add(this.btnListarApellido);
            this.tabPage14.Controls.Add(this.dgvListarApellido);
            this.tabPage14.Location = new System.Drawing.Point(4, 24);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(587, 577);
            this.tabPage14.TabIndex = 1;
            this.tabPage14.Text = "Listar por Apellido";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // txtListarApellido
            // 
            this.txtListarApellido.BackColor = System.Drawing.Color.MistyRose;
            this.txtListarApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtListarApellido.Location = new System.Drawing.Point(116, 15);
            this.txtListarApellido.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtListarApellido.Multiline = true;
            this.txtListarApellido.Name = "txtListarApellido";
            this.txtListarApellido.Size = new System.Drawing.Size(309, 22);
            this.txtListarApellido.TabIndex = 73;
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.Location = new System.Drawing.Point(13, 15);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(96, 17);
            this.label90.TabIndex = 21;
            this.label90.Text = "Seleccionar";
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBorrar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.Location = new System.Drawing.Point(513, 14);
            this.btnBorrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(66, 25);
            this.btnBorrar.TabIndex = 19;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnListarApellido
            // 
            this.btnListarApellido.BackColor = System.Drawing.Color.MistyRose;
            this.btnListarApellido.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnListarApellido.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListarApellido.Location = new System.Drawing.Point(432, 14);
            this.btnListarApellido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnListarApellido.Name = "btnListarApellido";
            this.btnListarApellido.Size = new System.Drawing.Size(66, 25);
            this.btnListarApellido.TabIndex = 18;
            this.btnListarApellido.Text = "Listar";
            this.btnListarApellido.UseVisualStyleBackColor = false;
            this.btnListarApellido.Click += new System.EventHandler(this.btnListarApellido_Click);
            // 
            // dgvListarApellido
            // 
            this.dgvListarApellido.AllowUserToAddRows = false;
            this.dgvListarApellido.AllowUserToDeleteRows = false;
            this.dgvListarApellido.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgvListarApellido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListarApellido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListarApellido.Location = new System.Drawing.Point(13, 52);
            this.dgvListarApellido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvListarApellido.Name = "dgvListarApellido";
            this.dgvListarApellido.ReadOnly = true;
            this.dgvListarApellido.RowHeadersWidth = 51;
            this.dgvListarApellido.RowTemplate.Height = 24;
            this.dgvListarApellido.Size = new System.Drawing.Size(566, 507);
            this.dgvListarApellido.TabIndex = 20;
            // 
            // tabPage16
            // 
            this.tabPage16.Controls.Add(this.label2);
            this.tabPage16.Controls.Add(this.cboEstados);
            this.tabPage16.Controls.Add(this.btnBorrarEstado);
            this.tabPage16.Controls.Add(this.btnListarEstado);
            this.tabPage16.Controls.Add(this.dgvListarEstado);
            this.tabPage16.Location = new System.Drawing.Point(4, 24);
            this.tabPage16.Name = "tabPage16";
            this.tabPage16.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage16.Size = new System.Drawing.Size(587, 577);
            this.tabPage16.TabIndex = 3;
            this.tabPage16.Text = "Listar por Estado";
            this.tabPage16.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Seleccionar";
            // 
            // cboEstados
            // 
            this.cboEstados.BackColor = System.Drawing.Color.MistyRose;
            this.cboEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstados.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboEstados.FormattingEnabled = true;
            this.cboEstados.Items.AddRange(new object[] {
            "Poner Que filtar",
            "Prueba",
            "Hola xd"});
            this.cboEstados.Location = new System.Drawing.Point(126, 16);
            this.cboEstados.Name = "cboEstados";
            this.cboEstados.Size = new System.Drawing.Size(282, 23);
            this.cboEstados.TabIndex = 22;
            // 
            // btnBorrarEstado
            // 
            this.btnBorrarEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBorrarEstado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBorrarEstado.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarEstado.Location = new System.Drawing.Point(513, 16);
            this.btnBorrarEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBorrarEstado.Name = "btnBorrarEstado";
            this.btnBorrarEstado.Size = new System.Drawing.Size(66, 25);
            this.btnBorrarEstado.TabIndex = 24;
            this.btnBorrarEstado.Text = "Borrar";
            this.btnBorrarEstado.UseVisualStyleBackColor = false;
            this.btnBorrarEstado.Click += new System.EventHandler(this.btnBorrarEstado_Click);
            // 
            // btnListarEstado
            // 
            this.btnListarEstado.BackColor = System.Drawing.Color.MistyRose;
            this.btnListarEstado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnListarEstado.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListarEstado.Location = new System.Drawing.Point(432, 16);
            this.btnListarEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnListarEstado.Name = "btnListarEstado";
            this.btnListarEstado.Size = new System.Drawing.Size(66, 25);
            this.btnListarEstado.TabIndex = 23;
            this.btnListarEstado.Text = "Listar";
            this.btnListarEstado.UseVisualStyleBackColor = false;
            this.btnListarEstado.Click += new System.EventHandler(this.btnListarEstado_Click);
            // 
            // dgvListarEstado
            // 
            this.dgvListarEstado.AllowUserToAddRows = false;
            this.dgvListarEstado.AllowUserToDeleteRows = false;
            this.dgvListarEstado.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgvListarEstado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListarEstado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListarEstado.Location = new System.Drawing.Point(13, 45);
            this.dgvListarEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvListarEstado.Name = "dgvListarEstado";
            this.dgvListarEstado.ReadOnly = true;
            this.dgvListarEstado.RowHeadersWidth = 51;
            this.dgvListarEstado.RowTemplate.Height = 24;
            this.dgvListarEstado.Size = new System.Drawing.Size(566, 507);
            this.dgvListarEstado.TabIndex = 25;
            // 
            // frmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(590, 629);
            this.Controls.Add(this.tabControl4);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmConsulta";
            this.Load += new System.EventHandler(this.frmConsulta_Load_1);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMinimizar)).EndInit();
            this.tabControl4.ResumeLayout(false);
            this.tabPage13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).EndInit();
            this.tabPage14.ResumeLayout(false);
            this.tabPage14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarApellido)).EndInit();
            this.tabPage16.ResumeLayout(false);
            this.tabPage16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarEstado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pcbCerrar;
        private System.Windows.Forms.PictureBox pcbMinimizar;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage13;
        private System.Windows.Forms.DataGridView dgvListar;
        private System.Windows.Forms.TabPage tabPage14;
        private System.Windows.Forms.TabPage tabPage16;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnListarApellido;
        private System.Windows.Forms.DataGridView dgvListarApellido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboEstados;
        private System.Windows.Forms.Button btnBorrarEstado;
        private System.Windows.Forms.Button btnListarEstado;
        private System.Windows.Forms.DataGridView dgvListarEstado;
        private System.Windows.Forms.TextBox txtListarApellido;
        private System.Windows.Forms.Button btnListarTodo;
    }
}