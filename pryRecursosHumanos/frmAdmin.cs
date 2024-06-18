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
using System.IO;

namespace pryRecursosHumanos
{
    public partial class frmAdmin : Form
    {
        private int idTitulo = 1;
        private clsEmpleado empleadoSeleccionado = new clsEmpleado();
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
            clsEnfermedadesPatologicas.listarEnfermedades(cboEnfermedades);
            clsMedicamentos.listarMedicamentos(cboMedicamentos);
            clsAlergias.listarAlergias(cboAlergias);
            clsDiscapacidades.listarDiscapacidades(cboDiscapacidades);
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

        private void btnSanciones_Click(object sender, EventArgs e)
        {
            frmLicenciaSancion frm = new frmLicenciaSancion("sanciones", empleadoSeleccionado);
            frm.ShowDialog();
        }

        private void btnLicencias_Click(object sender, EventArgs e)
        {
            frmLicenciaSancion frm = new frmLicenciaSancion("licencias", empleadoSeleccionado);
            frm.ShowDialog();
        }

        private void btnFinRegistro_Click(object sender, EventArgs e)
        {
            clsEmpleado nuevoEmpleado = new clsEmpleado();
            try
            {
                if (rbSi.Checked) idTitulo = Convert.ToInt32(cboTitulo.SelectedValue);
                nuevoEmpleado.Cuit = Convert.ToInt32(txtCuit.Text);
                nuevoEmpleado.IdArea = Convert.ToInt32(cboSeleccionarArea.SelectedValue);
                nuevoEmpleado.Nombre = txtNombre.Text;
                nuevoEmpleado.Apellido = txtApellido.Text;
                nuevoEmpleado.Domicilio = txtDireccion.Text;
                nuevoEmpleado.Telefono = txtTelefono.Text;
                nuevoEmpleado.DNI = Convert.ToInt32(txtDni.Text);
                nuevoEmpleado.Email = txtCorreo.Text;
                nuevoEmpleado.FechaNacimiento = dtpFechaNacimiento.Value;
                nuevoEmpleado.Foto = pbFotoEmpleado.ImageLocation.ToString();
                nuevoEmpleado.IdCiudad = Convert.ToInt32(cboCuidad.SelectedValue);
                nuevoEmpleado.IdEstado = Convert.ToInt32(cboEstadoEmpleado.SelectedValue);
                nuevoEmpleado.IdTitulo = idTitulo;
                nuevoEmpleado.Instagram = txtInstagram.Text;

                nuevoEmpleado.agregarEmpleado(nuevoEmpleado);
                nuevoEmpleado.asignarFichaMedica();
                empleadoSeleccionado = nuevoEmpleado;
                txtBuscarCuit.Text = empleadoSeleccionado.Cuit.ToString();
                lblFichaMedica.Text = $"Ficha Medica N°: {empleadoSeleccionado.IdFichaMedica}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dgvEnfermedades.DataSource = null;
                dgvMedicamentos.DataSource = null;
                dgvDiscapacidades.DataSource = null;
                dgvAlergias.DataSource = null;
                idTitulo = 1;
            }
        }

        private void pbFotoEmpleado_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath + "\\img";
            openFileDialog.Filter = "Archivos de imagen|*.png;*.jpg;*.jpeg|Todos los archivos|*.*";
            openFileDialog.RestoreDirectory = false;
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

        private void btnAgregarFalta_Click(object sender, EventArgs e)
        {
            clsPresentismo.agregarFalta(empleadoSeleccionado.Cuit, dtpAusencia.Value.ToString("dd/MM/yyyy"));
            clsPresentismo.listarFaltas(dgvFaltas, empleadoSeleccionado.Cuit);
        }

        private void btnAgregarEnfermedad_Click(object sender, EventArgs e)
        {
            if(cboEnfermedades.SelectedValue != null)
            {
                //empleadoSeleccionado.IdFichaMedica = clsEmpleado.buscarFichaMedica(Convert.ToInt32(txtBuscarCuit.Text));
                int idEnfermedad = Convert.ToInt32(cboEnfermedades.SelectedValue.ToString());
                clsFichaMedica.agregarEnfermedad(empleadoSeleccionado.IdFichaMedica, idEnfermedad);
                clsFichaMedica.listarEnfermedades(dgvEnfermedades, empleadoSeleccionado.IdFichaMedica);
            }
        }

        private void btnAgregarMedicamento_Click(object sender, EventArgs e)
        {
            if (cboMedicamentos.SelectedValue != null)
            {
                //empleadoSeleccionado.IdFichaMedica = clsEmpleado.buscarFichaMedica(Convert.ToInt32(txtBuscarCuit.Text));
                int idMedicamento = Convert.ToInt32(cboMedicamentos.SelectedValue.ToString());
                double dosis = Convert.ToDouble(txtDosis.Text);
                clsFichaMedica.agregarMedicamento(empleadoSeleccionado.IdFichaMedica, idMedicamento, dosis);
                clsFichaMedica.listarMedicamentos(dgvMedicamentos, empleadoSeleccionado.IdFichaMedica);
                txtDosis.Text = "0";
            }
        }

        private void btnAgregarDiscapacidadFM_Click(object sender, EventArgs e)
        {
            if (cboDiscapacidades.SelectedValue != null)
            {
                //empleadoSeleccionado.IdFichaMedica = clsEmpleado.buscarFichaMedica(Convert.ToInt32(txtBuscarCuit.Text));
                int idDiscapacidad = Convert.ToInt32(cboDiscapacidades.SelectedValue.ToString());
                clsFichaMedica.agregarDiscapacidad(empleadoSeleccionado.IdFichaMedica, idDiscapacidad);
                clsFichaMedica.listarDiscapacidades(dgvDiscapacidades, empleadoSeleccionado.IdFichaMedica);
            }
        }

        private void btnAgregarAlergiaFM_Click(object sender, EventArgs e)
        {
            if (cboAlergias.SelectedValue != null)
            {
                //empleadoSeleccionado.IdFichaMedica = clsEmpleado.buscarFichaMedica(Convert.ToInt32(txtBuscarCuit.Text));
                int idAlergia = Convert.ToInt32(cboAlergias.SelectedValue.ToString());
                clsFichaMedica.agregarAlergia(empleadoSeleccionado.IdFichaMedica, idAlergia);
                clsFichaMedica.listarAlergias(dgvAlergias, empleadoSeleccionado.IdFichaMedica);
            }
        }

        private void btnBuscarCuit_Click(object sender, EventArgs e)
        {
            if(txtBuscarCuit.Text != String.Empty)
            {
                int cuit = Convert.ToInt32(txtBuscarCuit.Text);
                empleadoSeleccionado.Cuit = cuit;
                if (clsEmpleado.validarEmpleado(empleadoSeleccionado) == true)
                {
                    empleadoSeleccionado.IdFichaMedica = clsEmpleado.buscarFichaMedica(cuit);
                    lblFichaMedica.Text = "Usuario válido";
                    lblFichaMedica.ForeColor = Color.Green;
                    clsFichaMedica.listarEnfermedades(dgvEnfermedades, empleadoSeleccionado.IdFichaMedica);
                    clsFichaMedica.listarMedicamentos(dgvMedicamentos, empleadoSeleccionado.IdFichaMedica);
                    clsFichaMedica.listarDiscapacidades(dgvDiscapacidades, empleadoSeleccionado.IdFichaMedica);
                    clsFichaMedica.listarAlergias(dgvAlergias, empleadoSeleccionado.IdFichaMedica);
                    btnAgregarEnfermedad.Enabled = true;
                    btnAgregarMedicamento.Enabled = true;
                    btnAgregarDiscapacidadFM.Enabled = true;
                    btnAgregarAlergiaFM.Enabled = true;
                }
                else
                {
                    lblFichaMedica.Text = "Usuario inválido";
                    lblFichaMedica.ForeColor = Color.Red;
                    btnAgregarEnfermedad.Enabled = false;
                    btnAgregarMedicamento.Enabled = false;
                    btnAgregarDiscapacidadFM.Enabled = false;
                    btnAgregarAlergiaFM.Enabled = false;
                    dgvEnfermedades.DataSource = null;
                    dgvMedicamentos.DataSource = null;
                    dgvDiscapacidades.DataSource = null;
                    dgvAlergias.DataSource = null;
                }
            }
        }

        private void btnBuscarSL_Click(object sender, EventArgs e)
        {
            if (txtBuscarCuitSL.Text != string.Empty)
            {
                int cuit = Convert.ToInt32(txtBuscarCuitSL.Text);
                empleadoSeleccionado.Cuit = cuit;
                if (clsEmpleado.validarEmpleado(empleadoSeleccionado) == true)
                {
                    lblEmpleadoExiste.ForeColor = Color.Green;
                    lblEmpleadoExiste.Text = "Usuario válido";
                    clsPresentismo.listarFaltas(dgvFaltas, empleadoSeleccionado.Cuit);
                    btnSanciones.Enabled = true;
                    btnLicencias.Enabled = true;
                    btnAgregarFalta.Enabled = true;
                }
                else
                {
                    lblEmpleadoExiste.ForeColor = Color.Red;
                    lblEmpleadoExiste.Text = "Usuario inválido";
                    btnSanciones.Enabled = false;
                    btnLicencias.Enabled = false;
                    btnAgregarFalta.Enabled = false;
                    dgvFaltas.DataSource = null;
                }
            }
        }

        private void dgvEnfermedades_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int cuit = Convert.ToInt32(txtBuscarCuit.Text);
            int idFichaMedica = clsEmpleado.buscarFichaMedica(cuit);
            int idEnfermedad = Convert.ToInt32(dgvEnfermedades.SelectedRows[0].Cells["IdEnfermedad"].Value);
            DialogResult result = MessageBox.Show("¿Eliminar enfermedad?", "Aviso", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                clsFichaMedica.eliminarEnfermedad(idFichaMedica, idEnfermedad);
                clsFichaMedica.listarEnfermedades(dgvEnfermedades, idFichaMedica);
            }
        }

        private void dgvMedicamentos_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int cuit = Convert.ToInt32(txtBuscarCuit.Text);
            int idFichaMedica = clsEmpleado.buscarFichaMedica(cuit);
            int idMedicamento = Convert.ToInt32(dgvMedicamentos.SelectedRows[0].Cells["IdMedicamentos"].Value);
            DialogResult result = MessageBox.Show("¿Eliminar medicamento?", "Aviso", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                clsFichaMedica.eliminarMedicamento(idFichaMedica, idMedicamento);
                clsFichaMedica.listarMedicamentos(dgvMedicamentos, idFichaMedica);
            }
        }

        private void dgvDiscapacidades_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int cuit = Convert.ToInt32(txtBuscarCuit.Text);
            int idFichaMedica = clsEmpleado.buscarFichaMedica(cuit);
            int idDiscapacidad = Convert.ToInt32(dgvDiscapacidades.SelectedRows[0].Cells["IdDiscapacidades"].Value);
            DialogResult result = MessageBox.Show("¿Eliminar discapacidad?", "Aviso", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                clsFichaMedica.eliminarDiscapacidad(idFichaMedica, idDiscapacidad);
                clsFichaMedica.listarDiscapacidades(dgvDiscapacidades, idFichaMedica);
            }
        }

        private void dgvAlergias_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int cuit = Convert.ToInt32(txtBuscarCuit.Text);
            int idFichaMedica = clsEmpleado.buscarFichaMedica(cuit);
            int idAlergia = Convert.ToInt32(dgvAlergias.SelectedRows[0].Cells["IdAlergias"].Value);
            DialogResult result = MessageBox.Show("¿Eliminar alergia?", "Aviso", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                clsFichaMedica.eliminarAlergia(idFichaMedica, idAlergia);
                clsFichaMedica.listarAlergias(dgvAlergias, idFichaMedica);
            }
        }

        private void dgvFaltas_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = Convert.ToInt32(dgvFaltas.SelectedRows[0].Cells["Id"].Value);
            DialogResult result = MessageBox.Show("¿Eliminar falta?", "AVISO", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                clsPresentismo.eliminarFaltas(id);
                clsPresentismo.listarFaltas(dgvFaltas, empleadoSeleccionado.Cuit);
            }
        }
    }
}
