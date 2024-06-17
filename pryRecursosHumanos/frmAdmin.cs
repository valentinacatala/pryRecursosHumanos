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
        private int idTitulo = 0;
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
            this.Close();
        }


        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
        private void frmAdmin_Load(object sender, EventArgs e)
        {            
            clsPaises.listarPaises(cboEmpleadoPais);
            clsArea.listarArea(cboSeleccionarArea);
            clsEstado.listarEstados(cboEstadoEmpleado);
            clsUniversidades.listarUniversidades(cboUniversidad);
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
            clsEmpleado nuevoEmpleado = new clsEmpleado();

            nuevoEmpleado.Cuit = Convert.ToInt32(txtCuit.Text);
            nuevoEmpleado.Sanciones = new List<int>();
            nuevoEmpleado.IdArea = Convert.ToInt32(txtCuit);
            nuevoEmpleado.IdFichaMedica = 0;
            nuevoEmpleado.IdUsuarios = 0;
            nuevoEmpleado.Nombre = txtNombre.Text;
            nuevoEmpleado.Apellido = txtApellido.Text;
            nuevoEmpleado.Domicilio = txtDireccion.Text;
            nuevoEmpleado.Telefono = Convert.ToInt32(txtTelefono.Text);
            nuevoEmpleado.DNI = Convert.ToInt32(txtDni.Text);
            nuevoEmpleado.Email = txtCorreo.Text;
            nuevoEmpleado.FechaNacimiento = Convert.ToDateTime(dtpFechaNacimiento);
            nuevoEmpleado.Foto = pbFotoEmpleado.Image.ToString();
            nuevoEmpleado.IdPais = Convert.ToInt32(cboEmpleadoPais);
            nuevoEmpleado.IdProvincia = Convert.ToInt32(cboProvincia);
            nuevoEmpleado.IdCiudad = Convert.ToInt32(cboCuidad.SelectedValue);
            nuevoEmpleado.MediosContacto = new List<int>();
            nuevoEmpleado.IdEstado = Convert.ToInt32(cboEstadoEmpleado.SelectedValue);
            nuevoEmpleado.IdTitulo = 0;
            nuevoEmpleado.Instagram = txtInstagram.Text;
            nuevoEmpleado.TiposContacto = new List<int>();

            nuevoEmpleado.agregarEmpleado(nuevoEmpleado);
        }

        private void btnSanciones_Click(object sender, EventArgs e)
        {
            clsEmpleado empleado = new clsEmpleado();
            empleado.Cuit = 146;
            frmLicenciaSancion frm = new frmLicenciaSancion("sanciones", empleado);
            frm.ShowDialog();
        }

        private void btnLicencias_Click(object sender, EventArgs e)
        {
            clsEmpleado empleado = new clsEmpleado();
            empleado.Cuit = 146;
            frmLicenciaSancion frm = new frmLicenciaSancion("licencias", empleado);
            frm.ShowDialog();
        }

        private void btnFinRegistro_Click(object sender, EventArgs e)
        {
            clsEmpleado nuevoEmpleado = new clsEmpleado();

            idTitulo = Convert.ToInt32(cboTitulo.SelectedValue);

            nuevoEmpleado.Cuit = Convert.ToInt32(txtCuit.Text);
            nuevoEmpleado.IdArea = Convert.ToInt32(cboSeleccionarArea.SelectedValue);
            //nuevoEmpleado.IdFichaMedica = 0;
            //nuevoEmpleado.IdUsuarios = 0;
            nuevoEmpleado.Nombre = txtNombre.Text;
            nuevoEmpleado.Apellido = txtApellido.Text;
            nuevoEmpleado.Domicilio = txtDireccion.Text;
            nuevoEmpleado.Telefono = Convert.ToInt32(txtTelefono.Text);
            nuevoEmpleado.DNI = Convert.ToInt32(txtDni.Text);
            nuevoEmpleado.Email = txtCorreo.Text;
            nuevoEmpleado.FechaNacimiento = dtpFechaNacimiento.Value;
            nuevoEmpleado.Foto = pbFotoEmpleado.ImageLocation.ToString();
            nuevoEmpleado.IdCiudad = Convert.ToInt32(cboCuidad.SelectedValue);
            nuevoEmpleado.IdEstado = Convert.ToInt32(cboEstadoEmpleado.SelectedValue);
            nuevoEmpleado.IdTitulo = idTitulo;
            nuevoEmpleado.Instagram = txtInstagram.Text;

            nuevoEmpleado.agregarEmpleado(nuevoEmpleado);
        }

        private void pbFotoEmpleado_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.png;*.jpg;*.jpeg|Todos los archivos|*.*";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaImagen = openFileDialog.FileName;
                pbFotoEmpleado.ImageLocation = rutaImagen;
            }
        }
        private void txtEliminarCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                clsEmpleado empleado = new clsEmpleado();
                int cuit = Convert.ToInt32(txtEliminarCuit.Text);
                empleado.buscarEmpleado(cuit,lblNombre,lblApellido,lblCorreo,lblDireccion,lblTelefono,lblFechaIngreso,pbEliminarFoto);
                e.Handled = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            clsEmpleado empleado = new clsEmpleado();
            bool eliminado = empleado.eliminarEmpleado(Convert.ToInt32(txtEliminarCuit.Text));
            if (eliminado)
            {
                MessageBox.Show($"Empleado con CUIT {txtCuit.Text} eliminado correctamente","Eliminado",MessageBoxButtons.OK);
            }
            else MessageBox.Show("El cuit ingresado no corresponde a ningun empleado");
        }

        private void btnCancelarEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarPais_Click(object sender, EventArgs e)
        {
            frmABMCbos frmABMCbos = new frmABMCbos("Pais");
            frmABMCbos.ShowDialog();
        }

        private void btnAgregarProvincias_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAgregarCiudad_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAgregarArea_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAgregarDiscapacidad_Click(object sender, EventArgs e)
        {
            frmABMCbos frmABMCbos = new frmABMCbos("Discapacidad");
            frmABMCbos.ShowDialog();
        }

        private void btnAgregarAlergia_Click(object sender, EventArgs e)
        {
            frmABMCbos frmABMCbos = new frmABMCbos("Alergia");
            frmABMCbos.ShowDialog();
        }

        private void btnAgregarMedicamentos_Click(object sender, EventArgs e)
        {
            frmABMCbos frmABMCbos = new frmABMCbos("Medicamento");
            frmABMCbos.ShowDialog();
        }

        private void btnAgregarEnfermedades_Click(object sender, EventArgs e)
        {
            frmABMCbos frmABMCbos = new frmABMCbos("Enfermedad");
            frmABMCbos.ShowDialog();
        }

        private void btnAgregarEstado_Click(object sender, EventArgs e)
        {
            frmABMCbos frmABMCbos = new frmABMCbos("Estado");
            frmABMCbos.ShowDialog();
        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNo.Checked)
            {
                cboUniversidad.Enabled = false;
                cboTitulo.Enabled = false;
                idTitulo = 0;
            }
            else
            {
                cboUniversidad.Enabled = true;
                cboTitulo.Enabled = true;
            }
        }

        private void cboUniversidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboUniversidad.SelectedValue != null)
            {
                int idUniversidad = Convert.ToInt32(cboUniversidad.SelectedValue.ToString());
                clsTitulo.listarTitulos(cboTitulo, idUniversidad);
            }
        }

        private void cboTitulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboTitulo.SelectedValue != null)
            {
                idTitulo = Convert.ToInt32(cboTitulo.SelectedValue.ToString());
            }
        }
    }
}
