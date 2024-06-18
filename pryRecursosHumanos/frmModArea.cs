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
    public partial class frmModArea : Form
    {
        public frmModArea()
        {
            InitializeComponent();
        }

        private void pcbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmModArea_Load(object sender, EventArgs e)
        {
            clsArea.listarArea(cboArea);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int sueldo = Convert.ToInt32(txtSueldo.Text);
                clsArea.modArea(cboArea.SelectedText,sueldo,dgvListar,Convert.ToInt32(cboArea.SelectedValue));
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese un numero en el campo 'Sueldo'");
            }
        }
    }
}
