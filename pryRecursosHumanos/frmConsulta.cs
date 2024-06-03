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
    public partial class frmConsulta : Form
    {
        public frmConsulta()
        {
            InitializeComponent();
        }

        private void pcbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pcbCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {
            clsEmpleado empleado = new clsEmpleado();
            empleado.listarEmpleados(dgvListar);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.registrarUsuario(new clsUsuarios());
            clsEmpleado empleado = new clsEmpleado();
            empleado.listarEmpleados(dgvListar);
        }
    }
}
