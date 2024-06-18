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
    public partial class frmEliminarProvincia : Form
    {
        public frmEliminarProvincia()
        {
            InitializeComponent();
        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPais.SelectedValue != null)
            {
                int idPais = Convert.ToInt32(cboPais.SelectedValue);
                clsProvincias.listarProvincias(cboProvincia, idPais);
            }
        }

        private void frmEliminarProvincia_Load(object sender, EventArgs e)
        {
            clsPaises.listarPaises(cboPais);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(cboProvincia.SelectedValue);
                int idPais = Convert.ToInt32(cboPais.SelectedValue);
                clsProvincias.eliminarProvincia(id,idPais,dgvListar);
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione una provincia");
            }
        }

        private void pcbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
