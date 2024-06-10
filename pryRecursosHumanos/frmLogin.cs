using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace pryRecursosHumanos
{
    public partial class frmLogin : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        // Constantes 
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        public frmLogin()
        {
            InitializeComponent();
            panel2.MouseDown += new MouseEventHandler(panel2_MouseDown);
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
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            clsUsuarios usuario = new clsUsuarios();
            usuario.Cuit = long.Parse(txtUsuario.Text);
            usuario.Contrasena = txtContraseña.Text;
            List<bool> inicio = usuario.Iniciar(usuario);
            if (inicio[0] == true)
            {
                MessageBox.Show("¡Inicio de sesión exitoso!", "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (inicio[1])
                {
                    frmAdmin frmAdmin = new frmAdmin();
                    frmAdmin.ShowDialog();
                }
                else
                {
                    frmConsulta frmConsulta = new frmConsulta();
                    frmConsulta.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos. Intente nuevamente.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
