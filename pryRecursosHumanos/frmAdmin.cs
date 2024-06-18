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
            clsArea.listarArea(cboAreaMod);
            clsEstado.listarEstados(cboEstadoEmpleado);
            clsUniversidades.listarUniversidades(cboUniversidad);
            clsEnfermedadesPatologicas.listarEnfermedades(cboEnfermedades);
            clsMedicamentos.listarMedicamentos(cboMedicamentos);
            clsAlergias.listarAlergias(cboAlergias);
            clsDiscapacidades.listarDiscapacidades(cboDiscapacidades);
            clsEstado.listarEstados(cboListarEstados);
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
                nuevoEmpleado.Cuit = txtCuit.Text;
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
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Complete todos los campos");
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
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaImagen = openFileDialog.FileName;
                pbFotoEmpleado.ImageLocation = rutaImagen;
            }
        }
        private void txtEliminarCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                int cuit;
                try
                {
                    cuit = Convert.ToInt32(txtEliminarCuit.Text);
                    clsEmpleado.buscarEmpleado(cuit, lblNombre, lblApellido, lblCorreo, lblDireccion, lblTelefono, lblFechaIngreso, pbEliminarFoto);
                    e.Handled = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ingrse un numero en CUIT");
                }
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int cuit = Convert.ToInt32(txtEliminarCuit.Text);
                clsEmpleado empleado = new clsEmpleado();
                bool eliminado = empleado.eliminarEmpleado(cuit);
                if (eliminado)
                {
                    MessageBox.Show($"Empleado con CUIT {txtCuit.Text} eliminado correctamente", "Eliminado", MessageBoxButtons.OK);
                }
                else MessageBox.Show("El cuit ingresado no corresponde a ningun empleado");
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese un CUIT");
            }
        }

        private void btnCancelarEliminar_Click(object sender, EventArgs e)
        {
            txtEliminarCuit.Text = "";
            lblNombre.Text = "";
            lblApellido.Text = "";
            lblCorreo.Text = "";
            lblDireccion.Text = "";
            lblTelefono.Text = "";
            lblFechaIngreso.Text = "";
            pbEliminarFoto.Image = null;
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
            frmProvinicia frmProvinicia = new frmProvinicia("Provincia");
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
            if (cboUniversidad.SelectedValue != null)
            {
                int idUniversidad = Convert.ToInt32(cboUniversidad.SelectedValue.ToString());
                clsTitulo.listarTitulos(cboTitulo, idUniversidad);
            }
        }

        private void cboTitulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTitulo.SelectedValue != null)
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
            if (cboEnfermedades.SelectedValue != null)
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
            if (txtBuscarCuit.Text != String.Empty)
            {
                try
                {
                    int cuit = Convert.ToInt32(txtBuscarCuit.Text);
                    empleadoSeleccionado.Cuit = cuit.ToString();
                    if (clsEmpleado.validarEmpleado(empleadoSeleccionado) == true)
                    {
                        empleadoSeleccionado.IdFichaMedica = clsEmpleado.buscarFichaMedica(cuit.ToString());
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
                catch (Exception)
                {
                    MessageBox.Show("Ingrese un numero");
                }
            }
        }

        private void btnBuscarSL_Click(object sender, EventArgs e)
        {
            if (txtBuscarCuitSL.Text != string.Empty)
            {
                try
                {
                    int cuit = Convert.ToInt32(txtBuscarCuitSL.Text);
                    empleadoSeleccionado.Cuit = cuit.ToString();
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
                catch (Exception)
                {
                    MessageBox.Show("Ingrese un numero");
                }
            }
        }

        private void dgvEnfermedades_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int cuit = Convert.ToInt32(txtBuscarCuit.Text);
            int idFichaMedica = clsEmpleado.buscarFichaMedica(cuit.ToString());
            int idEnfermedad = Convert.ToInt32(dgvEnfermedades.SelectedRows[0].Cells["IdEnfermedad"].Value);
            DialogResult result = MessageBox.Show("¿Eliminar enfermedad?", "Aviso", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                clsFichaMedica.eliminarEnfermedad(idFichaMedica, idEnfermedad);
                clsFichaMedica.listarEnfermedades(dgvEnfermedades, idFichaMedica);
            }
        }

        private void dgvMedicamentos_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int cuit = Convert.ToInt32(txtBuscarCuit.Text);
            int idFichaMedica = clsEmpleado.buscarFichaMedica(cuit.ToString());
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
            int idFichaMedica = clsEmpleado.buscarFichaMedica(cuit.ToString());
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
            int idFichaMedica = clsEmpleado.buscarFichaMedica(cuit.ToString());
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
            if (result == DialogResult.Yes)
            {
                clsPresentismo.eliminarFaltas(id);
                clsPresentismo.listarFaltas(dgvFaltas, empleadoSeleccionado.Cuit);
            }
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
                frmEliminarProvincia eliminarProvincia = new frmEliminarProvincia("Provincia");
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
            dgvListar.DataSource = null;
            dgvListarEstado.DataSource = null;
            if (txtListarApellido.Text != string.Empty) clsEmpleado.listarEmpleadosApellido(dgvListarApellido, txtListarApellido.Text);
        }

        private void btnListarEstado_Click(object sender, EventArgs e)
        {
            dgvListar.DataSource = null;
            dgvListarApellido.DataSource = null;
            if (cboListarEstados.SelectedIndex != -1)
            {
                int idEstado = Convert.ToInt32(cboListarEstados.SelectedValue.ToString());
                if (idEstado != -1) clsEmpleado.listarEmpleadosEstado(dgvListarEstado, idEstado);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                clsEmpleado.buscarEmpleado(Convert.ToInt32(txtCuitModificar.Text), txtModificarNombre, txtApellidoMod, txtDniMod, txtModificarCorreo, txtModificarDomicilio, txtModificarTelefono, dtpModificarFecha, txtModificarInstagram,cboAreaMod);
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese un CUIT");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                clsEmpleado.modificarEmpleado(Convert.ToInt32(txtCuitModificar.Text), txtModificarNombre.Text, txtApellidoMod.Text, Convert.ToInt32(txtDniMod.Text), dtpModificarFecha.Value, txtModificarDomicilio.Text, txtModificarCorreo.Text, Convert.ToInt32(txtModificarTelefono.Text), txtModificarInstagram.Text, Convert.ToInt32(cboAreaMod.SelectedValue));   
                MessageBox.Show("Empleado modificado correctamente");
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese un numero en CUIT");
            }
        }

        private void btnListarTodo_Click(object sender, EventArgs e)
        {
            dgvListarEstado.DataSource = null;
            dgvListarApellido.DataSource = null;
            clsEmpleado.listarEmpleados(dgvListar);
        }

        private void btnListarEstadoBorrar_Click(object sender, EventArgs e)
        {
            cboListarEstados.SelectedIndex = -1;
            dgvListarEstado.DataSource = null;
        }

        private void btnListarApellidoBorrar_Click(object sender, EventArgs e)
        {
            txtListarApellido.Text = "";
            dgvListarApellido.DataSource = null;
        }

        private void btnCancelarModificar_Click(object sender, EventArgs e)
        {
            txtCuitModificar.Text = "";
            txtModificarNombre.Text = "";
            txtApellidoMod.Text = "";
            txtDniMod.Text = "";
            txtModificarCorreo.Text = "";
            txtModificarDomicilio.Text = "";
            txtModificarTelefono.Text = "";
            dtpModificarFecha.Value = DateTime.Now;
            txtModificarInstagram.Text = "";
            cboAreaMod.SelectedIndex = -1;
        }

        private void btnListarTitulo_Click(object sender, EventArgs e)
        {
            frmListar frmListar = new frmListar("Titulo");
            frmListar.ShowDialog();
        }

        private void btnEliminarTitulo_Click(object sender, EventArgs e)
        {
            frmEliminarProvincia eliminarProvincia = new frmEliminarProvincia("Titulo");
            eliminarProvincia.ShowDialog();
        }

        private void btnAgregarTitulo_Click(object sender, EventArgs e)
        {
            frmProvinicia frmProvinicia = new frmProvinicia("Titulo");
            frmProvinicia.ShowDialog();
        }

        private void btnListarUni_Click(object sender, EventArgs e)
        {
            frmListar frmListar = new frmListar("Universidad");
            frmListar.ShowDialog();
        }

        private void btnEliminarUni_Click(object sender, EventArgs e)
        {
            frmEliminar frmEliminar = new frmEliminar("Universidad");
            frmEliminar.ShowDialog();
        }

        private void btnAgregarUni_Click(object sender, EventArgs e)
        {
            frmABMCbos frmABMCbos = new frmABMCbos("Universidad");
            frmABMCbos.ShowDialog();
        }
    }
}
