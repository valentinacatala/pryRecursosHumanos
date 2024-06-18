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
    public partial class frmListar : Form
    {
        string modoG;

        public frmListar(string modo)
        {
            InitializeComponent();
            lblTitulo.Text = modo;
            modoG = modo;
        }

        private void pcbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListar_Load(object sender, EventArgs e)
        {
            if (modoG == "Pais")
            {
                clsPaises.listarPaises(dgvListar,modoG);
            }
            else if (modoG == "Discapacidad")
            {
                clsDiscapacidades.listarDiscapacidades(dgvListar, modoG);
            }
            else if (modoG == "Alergia")
            {
                clsAlergias.listarAlergias(dgvListar, modoG);
            }
            else if (modoG == "Medicamento")
            {
                clsMedicamentos.listarMedicamentos(dgvListar, modoG);
            }
            else if (modoG == "Enfermedad")
            {
                clsEnfermedadesPatologicas.listarEnfermedades(dgvListar, modoG);
            }
            else if (modoG == "Estado")
            {
                clsEstado.listarEstados(dgvListar, modoG);
            }
            else if (modoG == "Provincia")
            {
                clsProvincias.listarProvincias(dgvListar);
            }
            else if (modoG == "Ciudad")
            {
               clsCiudades.listarCiudades(dgvListar);
            }
            else if (modoG == "Area")
            {
                clsArea.listarArea(dgvListar, modoG);
            }
            else if (modoG == "Sancion")
            {
                clsSanciones.listarSanciones(dgvListar);
            }
            else if (modoG == "Licencia")
            {
                clsLicencia.listarLicencias(dgvListar);
            }
        }
    }
}
