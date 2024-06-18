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
    public partial class frmEliminarCiudad : Form
    {
        public frmEliminarCiudad()
        {
            InitializeComponent();
        }

        private void pcbCerrar_Click(object sender, EventArgs e)
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

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedValue != null)
            {
                int idProvincia = Convert.ToInt32(cboProvincia.SelectedValue);
                clsCiudades.listarCiudades(cboCiudad, idProvincia);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int idCiudad = Convert.ToInt32(cboCiudad.SelectedValue);
                int idPais = Convert.ToInt32(cboPais.SelectedValue);
                clsCiudades.eliminarCiudad(idCiudad,dgvListar,idPais);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frmEliminarCiudad_Load(object sender, EventArgs e)
        {
            clsPaises.listarPaises(cboPais);
        }
    }
}
