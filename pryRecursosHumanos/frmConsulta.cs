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

        }
     

        private void frmConsulta_Load_1(object sender, EventArgs e)
        {
            clsEmpleado.listarEmpleados(dgvListar);
            clsEstado.listarEstados(cboEstados);
        }

        private void btnListarApellido_Click(object sender, EventArgs e)
        {
            dgvListar.DataSource = null;
            dgvListarEstado.DataSource = null;
            if (txtListarApellido.Text != string.Empty) clsEmpleado.listarEmpleadosApellido(dgvListarApellido, txtListarApellido.Text);
        }

        private void btnListarEstado_Click(object sender, EventArgs e)
        {
            dgvListar.DataSource = null;
            dgvListarApellido.DataSource = null;
            if(cboEstados.SelectedIndex != -1)
            {
                int idEstado = Convert.ToInt32(cboEstados.SelectedValue.ToString());  
                if(idEstado != -1) clsEmpleado.listarEmpleadosEstado(dgvListarEstado, idEstado);
            }
        }

        private void btnListarTodo_Click(object sender, EventArgs e)
        {
            dgvListarEstado.DataSource = null;
            dgvListarApellido.DataSource = null;
            clsEmpleado.listarEmpleados(dgvListar);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtListarApellido.Text = "";
            dgvListarApellido.DataSource = null;
        }

        private void btnBorrarEstado_Click(object sender, EventArgs e)
        {
            cboEstados.SelectedIndex = -1;
            dgvListarEstado.DataSource = null;
        }
    }
}
