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
        string modoG;
        public frmEliminarProvincia(string modo)
        {
            InitializeComponent();
            modoG = modo;
            lblModo.Text = modo;
        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPais.SelectedValue != null)
            {
                if(modoG == "Provincia")
                {
                    int id = Convert.ToInt32(cboPais.SelectedValue);
                    clsProvincias.listarProvincias(cboProvincia, id);
                }
                else if (modoG == "Titulo")
                {
                    int id = Convert.ToInt32(cboPais.SelectedValue);
                    clsTitulo.listarTitulos(cboProvincia,id);
                }
            }
        }

        private void frmEliminarProvincia_Load(object sender, EventArgs e)
        {
            if (modoG == "Provincia")
            {
                cboPais.DataSource = null;
                clsPaises.listarPaises(cboPais);
            }
            else if (modoG == "Titulo")
            {
                cboPais.DataSource = null;
                clsUniversidades.listarUniversidades(cboPais);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(cboProvincia.SelectedValue);
                int idPais = Convert.ToInt32(cboPais.SelectedValue);
                if (modoG == "Provincia")
                {
                    clsProvincias.eliminarProvincia(id, idPais, dgvListar);
                }
                else if (modoG == "Titulo")
                {
                    clsTitulo.eliminarTitulo(id,dgvListar);
                }
                
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
