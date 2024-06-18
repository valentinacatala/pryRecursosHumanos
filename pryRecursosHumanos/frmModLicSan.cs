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
    public partial class frmModLicSan : Form
    {
        string modoG;
        public frmModLicSan(string modo)
        {
            InitializeComponent();
            modoG = modo;
            lblModo.Text = modo;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(cboNombre.SelectedValue);
                int tiempo = Convert.ToInt32(txtTiempo.Text);
                if (modoG == "Sancion")
                {
                    clsSanciones.modificarSancion(dgvListar,id,tiempo);
                }
                else if (modoG == "Licencia")
                {
                    clsLicencia.modificarLicencia(dgvListar, id, tiempo);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Complete todos los campos");
            }
        }

        private void frmModLicSan_Load(object sender, EventArgs e)
        {
            if (modoG == "Sancion")
            {
                clsSanciones.listarSanciones(cboNombre);
            }
            else if (modoG == "Licencia")
            {
                clsLicencia.listarLicencias(cboNombre);
            }
        }

        private void pcbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
