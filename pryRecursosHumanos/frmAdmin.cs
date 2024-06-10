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
            nuevoEmpleado.Foto = pbFotoEmpleado.ImageLocation;
            nuevoEmpleado.Ciudad = new clsCiudades();//Combo
            nuevoEmpleado.MediosContacto = new List<clsMedioContactos>();//Nuevo form
            nuevoEmpleado.Estado = new clsEstado();//Combo
            nuevoEmpleado.Titulo = new clsTitulo();//Combo
            nuevoEmpleado.Instagram = "";
            nuevoEmpleado.TiposContacto = new List<clsTipoContactos>();//Nuevo form

            nuevoEmpleado.agregarEmpleado(nuevoEmpleado);
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {            
            clsPaises.listarPaises(cboEmpleadoPais);
            clsArea.listarArea(cboSeleccionarArea);
            clsEstado.listarEstados(cboEstadoEmpleado);
            clsEnfermedadesPatologicas.listarEnfermedades(cboEnfermedades);
            clsMedicamentos.listarMedicamentos(cboMedicamentos);
            clsDiscapacidades.listarDiscapacidades(cboDiscapacidades);
            clsAlergias.listarAlergias(cboAlergias);
            clsSanciones.listarSanciones(cboTipoSancion);
            clsLicencia.listarLicencias(cboTipoLicencia);
            
        }

        private void cboEmpleadoPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboProvincia.ResetText();
            cboProvincia.DataSource = null;
            cboCuidad.ResetText();
            cboCuidad.DataSource = null;
            if (cboEmpleadoPais.SelectedValue != null)
            {
                clsProvincias provincias = new clsProvincias();
                int idPais = Convert.ToInt32(cboEmpleadoPais.SelectedValue);
                provincias.listarProvincias(cboProvincia, idPais);
            }
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCuidad.ResetText();
            cboCuidad.DataSource = null;
            if (cboProvincia.SelectedValue != null)
            {
                clsCiudades ciudades = new clsCiudades();
                int idProvincia = Convert.ToInt32(cboProvincia.SelectedValue);
                ciudades.listarCiudades(cboCuidad, idProvincia);
            }
        }

        private void btnSiguiente1_Click(object sender, EventArgs e)
        {
            //tabPaso2.Locked = false;
            tabAgregarEmpleados.SelectedTab = tabPaso2;
        }

        private void btnSiguiente2_Click(object sender, EventArgs e)
        {
            //tabPaso3.Locked = false;
            tabAgregarEmpleados.SelectedTab = tabPaso3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //tabPaso4.Locked = false;
            tabAgregarEmpleados.SelectedTab = tabPaso4;
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}
