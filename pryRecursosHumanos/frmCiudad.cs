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
    public partial class frmCiudad : Form
    {
        public frmCiudad()
        {
            InitializeComponent();
        }

        private void frmCiudad_Load(object sender, EventArgs e)
        {
            clsPaises.listarPaises(cboPais);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            clsCiudades.agregarCiudad(Convert.ToInt32(cboProvincia.SelectedValue),txtCiudad.Text.ToUpper(),dgvListar,Convert.ToInt32(cboPais.SelectedValue));
        }

        private void pcbCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPais.SelectedValue != null)
            {
                int idPais = Convert.ToInt32(cboPais.SelectedValue);
                clsProvincias.listarProvincias(cboProvincia, idPais);
            }
        }
    }
}
