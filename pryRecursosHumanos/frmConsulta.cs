using System;
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
    public partial class frmConsulta : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        // Constantes 
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        public frmConsulta()
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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
