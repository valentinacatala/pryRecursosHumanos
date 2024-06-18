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
    public partial class frmProvinicia : Form
    {
        public frmProvinicia()
        {
            InitializeComponent();
        }

        private void frmProvinicia_Load(object sender, EventArgs e)
        {
            clsPaises.listarPaises(cboPais);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            clsProvincias.agregarProvincia(Convert.ToInt32(cboPais.SelectedValue),txtProvincia.Text.ToUpper(),dgvListar);
        }

        private void pcbCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
