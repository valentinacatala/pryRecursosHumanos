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
    public partial class frmAdmin : Form
    {
        // Importar las funciones de la API de Windows
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        // Constantes necesarias
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        public frmAdmin()
        {
            InitializeComponent();
            panel2.MouseDown += new MouseEventHandler(panel2_MouseDown);
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void pcbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pcbCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void groupBox14_Enter(object sender, EventArgs e)
        {

        }

        private void label64_Click(object sender, EventArgs e)
        {

        }

        private void tabPage10_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            clsEmpleado nuevoEmpleado = new clsEmpleado();

            nuevoEmpleado.Cuit = 0;
            nuevoEmpleado.Licencia = new clsLicencia();//Combo
            nuevoEmpleado.Sanciones = new List<clsSanciones>();//Nuevo form
            nuevoEmpleado.Area = new clsArea();//Combo
            nuevoEmpleado.FichaMedica = new clsFichaMedica();
            nuevoEmpleado.Usuarios = new clsUsuarios();//Combo
            nuevoEmpleado.Nombre = txtNombre.Text;
            nuevoEmpleado.Apellido = txtApellido.Text;
            nuevoEmpleado.Domicilio = txtDireccion.Text;
            nuevoEmpleado.Telefono = 0;
            nuevoEmpleado.DNI = 0;
            nuevoEmpleado.Email = txtCorreo.Text;
            nuevoEmpleado.FechaNacimiento = new DateTime();
            nuevoEmpleado.Foto = pbxFoto.ImageLocation;
            nuevoEmpleado.Ciudad = new clsCiudades();//Combo
            nuevoEmpleado.MediosContacto = new List<clsMedioContactos>();//Nuevo form
            nuevoEmpleado.Estado = new clsEstado();//Combo
            nuevoEmpleado.Titulo = new clsTitulo();//Combo
            nuevoEmpleado.Instagram = "";
            nuevoEmpleado.TiposContacto = new List<clsTipoContactos>();//Nuevo form

            nuevoEmpleado.agregarEmpleado(nuevoEmpleado);
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
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
