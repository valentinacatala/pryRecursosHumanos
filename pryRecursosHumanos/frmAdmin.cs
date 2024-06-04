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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
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
    }
}
