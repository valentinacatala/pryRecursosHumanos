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
            clsArea.listarArea(cboAreaMod);
            clsEstado.listarEstados(cboEstadoEmpleado);
            clsEmpleado.listarEmpleados(dgvListar);
        }

        private void cboEmpleadoPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboProvincia.ResetText();
            cboProvincia.DataSource = null;
            cboCuidad.ResetText();
            cboCuidad.DataSource = null;
            if (cboEmpleadoPais.SelectedValue != null)
            {
                int idPais = Convert.ToInt32(cboEmpleadoPais.SelectedValue);
                clsProvincias.listarProvincias(cboProvincia, idPais);
            }
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCuidad.ResetText();
            cboCuidad.DataSource = null;
            if (cboProvincia.SelectedValue != null)
            {
                int idProvincia = Convert.ToInt32(cboProvincia.SelectedValue);
                clsCiudades.listarCiudades(cboCuidad, idProvincia);
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
            nuevoEmpleado.Foto = pbFotoEmpleado.Image.ToString();
            nuevoEmpleado.IdCiudad = Convert.ToInt32(cboCuidad.SelectedValue);
            nuevoEmpleado.IdEstado = Convert.ToInt32(cboEstadoEmpleado.SelectedValue);
            nuevoEmpleado.IdTitulo = 1;
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
                int cuit = Convert.ToInt32(txtEliminarCuit.Text);
                clsEmpleado.buscarEmpleado(cuit,lblNombre,lblApellido,lblCorreo,lblDireccion,lblTelefono,lblFechaIngreso,pbEliminarFoto);
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
        #region ABM
        #region agregar
        private void btnAgregarPais_Click(object sender, EventArgs e)
        {
            frmABMCbos frmABMCbos = new frmABMCbos("Pais");
            frmABMCbos.ShowDialog();
        }
        private void btnAgregarProvincias_Click(object sender, EventArgs e)
        {
            frmProvinicia frmProvinicia = new frmProvinicia();
            frmProvinicia.ShowDialog();
        }
        private void btnAgregarCiudad_Click(object sender, EventArgs e)
        {
            frmCiudad frmCiudad = new frmCiudad();
            frmCiudad.ShowDialog();
        }
        private void btnAgregarArea_Click(object sender, EventArgs e)
        {
            frmArea frmArea = new frmArea();
            frmArea.ShowDialog();
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
        private void btnAgregarSancion_Click(object sender, EventArgs e)
        {
            frmAgregarLicSan frmAgregarLicSan = new frmAgregarLicSan("Sancion");
            frmAgregarLicSan.ShowDialog();
        }

        private void btnAgregarLicencia_Click(object sender, EventArgs e)
        {
            frmAgregarLicSan frmAgregarLicSan = new frmAgregarLicSan("Licencia");
            frmAgregarLicSan.ShowDialog();
        }
        
        #endregion
        #region modificar
        private void btnModificarArea_Click(object sender, EventArgs e)
        {
            frmModArea frmModArea = new frmModArea();
            frmModArea.ShowDialog();
        }
        private void btnModificarLicencia_Click(object sender, EventArgs e)
        {
            frmModLicSan frmModLicSan = new frmModLicSan("Licencia");
            frmModLicSan.ShowDialog();
        }

        private void btnModificarSancion_Click(object sender, EventArgs e)
        {
            frmModLicSan frmModLicSan = new frmModLicSan("Sancion");
            frmModLicSan.ShowDialog();
        }
        #endregion
        #region eliminar
        private void btnEliminarEstado_Click(object sender, EventArgs e)
        {
            frmEliminar frmEliminar = new frmEliminar("Estado");
            frmEliminar.ShowDialog();
        }

        private void btnEliminarEnfermedades_Click(object sender, EventArgs e)
        {
            frmEliminar frmEliminar = new frmEliminar("Enfermedad");
            frmEliminar.ShowDialog();
        }

        private void btnEliminarMedicamentos_Click(object sender, EventArgs e)
        {
            frmEliminar frmEliminar = new frmEliminar("Medicamento");
            frmEliminar.ShowDialog();
        }

        private void btnEliminarAlergia_Click(object sender, EventArgs e)
        {
            frmEliminar frmEliminar = new frmEliminar("Alergia");
            frmEliminar.ShowDialog();
        }

        private void btnEliminarDiscapacidad_Click(object sender, EventArgs e)
        {
            frmEliminar frmEliminar = new frmEliminar("Discapacidad");
            frmEliminar.ShowDialog();
        }

        private void btnEliminarArea_Click(object sender, EventArgs e)
        {
            frmEliminar frmEliminar = new frmEliminar("Discapacidad");
            frmEliminar.ShowDialog();
        }

        private void btnEliminarCiudad_Click(object sender, EventArgs e)
        {
            frmEliminarCiudad eliminarCiudad = new frmEliminarCiudad();
            eliminarCiudad.ShowDialog();
        }

        private void btnEliminarProvincia_Click(object sender, EventArgs e)
        {
            frmEliminarProvincia eliminarProvincia = new frmEliminarProvincia();
            eliminarProvincia.ShowDialog();
        }

        private void btnEliminarPais_Click(object sender, EventArgs e)
        {
            frmEliminar frmEliminar = new frmEliminar("Pais");
            frmEliminar.ShowDialog();
        }
        private void btnEliminarSancion_Click(object sender, EventArgs e)
        {
            frmEliminar frmEliminar = new frmEliminar("Sancion");
            frmEliminar.ShowDialog();
        }

        private void btnEliminarLicencia_Click(object sender, EventArgs e)
        {
            frmEliminar frmEliminar = new frmEliminar("Licencia");
            frmEliminar.ShowDialog();
        }
        #endregion
        #region listar
        private void btnListarPaises_Click(object sender, EventArgs e)
        {
            frmListar frmListar = new frmListar("Pais");
            frmListar.ShowDialog();
        }
       
        private void btnListarSanciones_Click(object sender, EventArgs e)
        {
            frmListar frmListar = new frmListar("Sancion");
            frmListar.ShowDialog();
        }

        private void btnListarLicencias_Click(object sender, EventArgs e)
        {
            frmListar frmListar = new frmListar("Licencia");
            frmListar.ShowDialog();
        }

        private void btnListarEstados_Click(object sender, EventArgs e)
        {
            frmListar frmListar = new frmListar("Estado");
            frmListar.ShowDialog();
        }

        private void btnListarEnfermedades_Click(object sender, EventArgs e)
        {
            frmListar frmListar = new frmListar("Enfermedad");
            frmListar.ShowDialog();
        }

        private void btnListarMedicamentos_Click(object sender, EventArgs e)
        {
            frmListar frmListar = new frmListar("Medicamento");
            frmListar.ShowDialog();
        }

        private void btnListarAlergias_Click(object sender, EventArgs e)
        {
            frmListar frmListar = new frmListar("Alergia");
            frmListar.ShowDialog();
        }

        private void btnListarDiscapacidades_Click(object sender, EventArgs e)
        {
            frmListar frmListar = new frmListar("Discapacidad");
            frmListar.ShowDialog();
        }

        private void btnListarAreas_Click(object sender, EventArgs e)
        {
            frmListar frmListar = new frmListar("Area");
            frmListar.ShowDialog();
        }

        private void btnListarCiudades_Click(object sender, EventArgs e)
        {
            frmListar frmListar = new frmListar("Ciudad");
            frmListar.ShowDialog();
        }

        private void btnListarProvincias_Click(object sender, EventArgs e)
        {
            frmListar frmListar = new frmListar("Provincia");
            frmListar.ShowDialog();
        }
        #endregion

        #endregion

        private void btnListarApellido_Click(object sender, EventArgs e)
        {
            clsEmpleado.listarEmpleadosApellido(dgvListar);
        }

        private void btnListarPais_Click(object sender, EventArgs e)
        {
            clsEmpleado.listarEmpleadosPais(dgvListar);
        }

        private void btnListarEstado_Click(object sender, EventArgs e)
        {
            clsEmpleado.listarEmpleadosEstado(dgvListar);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            clsEmpleado.buscarEmpleado(Convert.ToInt32(txtCuitModificar.Text),txtModificarNombre,txtApellidoMod,txtDniMod,txtModificarCorreo,txtModificarDomicilio,txtModificarTelefono,dtpModificarFecha,txtModificarInstagram);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            clsEmpleado.modificarEmpleado(Convert.ToInt32(txtCuitModificar.Text), txtModificarNombre.Text, txtApellidoMod.Text, Convert.ToInt32(txtDniMod.Text), dtpModificarFecha.Value, txtModificarDomicilio.Text, txtModificarCorreo.Text, Convert.ToInt32(txtModificarTelefono.Text),  txtModificarInstagram.Text,Convert.ToInt32(cboAreaMod.SelectedValue));
        }
    }
}
