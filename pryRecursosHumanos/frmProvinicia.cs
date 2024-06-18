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
        string modoG;
        public frmProvinicia(string modo)
        {
            InitializeComponent();
            modoG = modo;
            lblModo.Text = modo;
        }

        private void frmProvinicia_Load(object sender, EventArgs e)
        {
            if(modoG == "Provincia")
            {
                clsPaises.listarPaises(cboPais);
            }
            else if(modoG == "Titulo")
            {
                clsUniversidades.listarUniversidades(cboPais);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtProvincia.Text != null && cboPais.SelectedIndex != -1)
            {
                if(modoG == "Provincia")
                {
                    clsProvincias.agregarProvincia(Convert.ToInt32(cboPais.SelectedValue), txtProvincia.Text.ToUpper(), dgvListar);
                }
                else if (modoG == "Titulo")
                {
                    clsTitulo.agregarTitulo(txtProvincia.Text.ToUpper(), Convert.ToInt32(cboPais.SelectedValue), dgvListar);
                }
            }
        }

        private void pcbCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
