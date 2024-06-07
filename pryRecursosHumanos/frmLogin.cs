using System;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
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

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            clsUsuarios usuario = new clsUsuarios();
            usuario.Cuit = long.Parse(txtUsuario.Text);
            usuario.Contrasena = txtContraseña.Text;
            bool inicio = usuario.Iniciar(usuario);

            if (inicio == true)
            {
                MessageBox.Show("¡Inicio de sesión exitoso!", "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos. Intente nuevamente.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
