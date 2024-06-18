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
    public partial class frmAgregarLicSan : Form
    {
        string modoG;

        public frmAgregarLicSan(string modo)
        {
            InitializeComponent();
            lblModo.Text = modo;
            modoG = modo;
        }

        private void pcbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int tiempo = Convert.ToInt32(txtTiempo.Text);
                if (modoG == "Sancion")
                {
                    clsSanciones.agregarSancion(txtNombre.Text.ToUpper(), tiempo, dgvListar);
                }
                else if (modoG == "Licencia")
                {
                    clsLicencia.agregarLicencia(txtNombre.Text.ToUpper(), tiempo, dgvListar);

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese el numero de dias correspondientes en el campo 'Tiempo'");
            }
        }
    }
}
