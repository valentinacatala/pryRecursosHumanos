﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecursosHumanos
{
    public partial class frmRegistrarUser : Form
    {
            [DllImport("user32.dll")]
            private static extern bool ReleaseCapture();

            [DllImport("user32.dll")]
            private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

            // Constantes 
            private const int WM_NCLBUTTONDOWN = 0xA1;
            private const int HT_CAPTION = 0x2;
        public frmRegistrarUser()
        {
            panel2.MouseDown += new MouseEventHandler(panel2_MouseDown);
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

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            clsUsuarios nuevoUsuario = new clsUsuarios();
            bool admin = false;
            admin = nuevoUsuario.Admin; // REDUNDANTE

            if (txtUsuario.Text != "" && txtContraseña.Text != "" && txtRepetirContraseña.Text != "")
            {
                if (txtContraseña.Text == txtRepetirContraseña.Text)
                {
                    nuevoUsuario.Cuit = Convert.ToInt64(txtUsuario.Text);
                    nuevoUsuario.Contrasena = txtContraseña.Text;
                    if (rbAdministrador.Checked)
                    {
                        admin = true;
                        nuevoUsuario.Admin = admin;
                        //nuevoUsuario.Admin = rbAdministrador.Checked;
                    }
                    nuevoUsuario.registrar(nuevoUsuario);
                }
                else
                {
                    MessageBox.Show("LAS CONTRASEÑAS NO COINCIDEN");
                }
            }
            else
            {
                MessageBox.Show("COMPLETE TODOS LOS CAMPOS");
            }
        }
    }
}
