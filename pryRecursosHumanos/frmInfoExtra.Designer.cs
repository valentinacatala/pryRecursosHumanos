namespace pryRecursosHumanos
{
    partial class frmInfoExtra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfoExtra));
            this.panel2 = new System.Windows.Forms.Panel();
            this.pcbCerrar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblNombreDato = new System.Windows.Forms.Label();
            this.cboDatos = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvListar = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCerrar)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.pcbCerrar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(540, 33);
            this.panel2.TabIndex = 6;
            // 
            // pcbCerrar
            // 
            this.pcbCerrar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pcbCerrar.Image = ((System.Drawing.Image)(resources.GetObject("pcbCerrar.Image")));
            this.pcbCerrar.Location = new System.Drawing.Point(499, 8);
            this.pcbCerrar.Name = "pcbCerrar";
            this.pcbCerrar.Size = new System.Drawing.Size(22, 18);
            this.pcbCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbCerrar.TabIndex = 12;
            this.pcbCerrar.TabStop = false;
            this.pcbCerrar.Click += new System.EventHandler(this.pcbCerrar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.lblNombreDato);
            this.panel1.Controls.Add(this.cboDatos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 66);
            this.panel1.TabIndex = 7;
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
            this.btnAgregar.Location = new System.Drawing.Point(265, 26);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(15, 15);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.UseVisualStyleBackColor = false;
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
            this.cboDatos.Location = new System.Drawing.Point(35, 23);
            this.cboDatos.Name = "cboDatos";
            this.cboDatos.Size = new System.Drawing.Size(224, 21);
            this.cboDatos.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MistyRose;
            this.panel3.Controls.Add(this.lblTitulo);
            this.panel3.Controls.Add(this.dgvListar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 99);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(540, 283);
            this.panel3.TabIndex = 8;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(31, 6);
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
            this.dgvListar.Location = new System.Drawing.Point(0, 40);
            this.dgvListar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvListar.Name = "dgvListar";
            this.dgvListar.ReadOnly = true;
            this.dgvListar.RowHeadersWidth = 51;
            this.dgvListar.RowTemplate.Height = 24;
            this.dgvListar.Size = new System.Drawing.Size(540, 243);
            this.dgvListar.TabIndex = 16;
            // 
            // frmInfoExtra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 382);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInfoExtra";
            this.Text = "frmInfoExtra";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbCerrar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pcbCerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboDatos;
        private System.Windows.Forms.Label lblNombreDato;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvListar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblTitulo;
    }
}