﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecursosHumanos
{
    public partial class frmArea : Form
    {
        public frmArea()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int sueldo = Convert.ToInt32(txtSueldo.Text);
                clsArea.agregarArea(txtNombre.Text.ToUpper(),sueldo,dgvListar);
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese un numero en el campo 'Sueldo'");
            }
        }

        private void pcbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
