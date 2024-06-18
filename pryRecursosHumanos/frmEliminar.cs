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
    public partial class frmEliminar : Form
    {
        string modoG;

        public frmEliminar(string modo)
        {
            InitializeComponent();
            lblModo.Text = modo;
            modoG = modo;
        }

        private void frmEliminar_Load(object sender, EventArgs e)
        {
            if (modoG == "Pais")
            {
                clsPaises.listarPaises(cboEliminar);
            }
            else if (modoG == "Discapacidad")
            {
                clsDiscapacidades.listarDiscapacidades(cboEliminar);
            }
            else if (modoG == "Alergia")
            {
                clsAlergias.listarAlergias(cboEliminar);
            }
            else if (modoG == "Medicamento")
            {
                clsMedicamentos.listarMedicamentos(cboEliminar);
            }
            else if (modoG == "Enfermedad")
            {
                clsEnfermedadesPatologicas.listarEnfermedades(cboEliminar);
            }
            else if (modoG == "Estado")
            {
                clsEstado.listarEstados(cboEliminar);
            }
            else if (modoG == "Sancion")
            {
                clsSanciones.listarSanciones(cboEliminar);
            }
            else if (modoG == "Licencia")
            {
                clsLicencia.listarLicencias(cboEliminar);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(cboEliminar.SelectedValue);
                if (modoG == "Pais")
                {
                    clsPaises.eliminarPais(cboEliminar.SelectedText,id,dgvListar);
                }
                else if (modoG == "Discapacidad")
                {
                    clsDiscapacidades.eliminarDiscapacidad(id,cboEliminar.Text,dgvListar);
                }
                else if (modoG == "Alergia")
                {
                    clsAlergias.eliminarAlergia(id,cboEliminar.Text,dgvListar);
                }
                else if (modoG == "Medicamento")
                {
                    clsMedicamentos.elimiarMedicamento(id,cboEliminar.Text,dgvListar);
                }
                else if (modoG == "Enfermedad")
                {
                    clsEnfermedadesPatologicas.eliminarEnfermedad(id,cboEliminar.Text,dgvListar);
                }
                else if (modoG == "Estado")
                {
                    clsEstado.eliminarEstado(id,cboEliminar.Text,dgvListar);
                }
                else if (modoG == "Sancion")
                {
                    clsSanciones.eliminarSancion(id,dgvListar);
                }
                else if (modoG == "Licencia")
                {
                    clsLicencia.eliminarLicencia(id,dgvListar);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione un nombre");
            }
            cboEliminar.SelectedIndex = -1;
        }

        private void pcbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
