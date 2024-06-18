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
    public partial class frmABMCbos : Form
    {
        string modoG;
        public frmABMCbos(string modo)
        {
            InitializeComponent();
            lblModo.Text = modo;
            modoG = modo;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(modoG == "Pais")
            {
                clsPaises.agregarPais(dgvListar,txtAgregar.Text.ToUpper());
            }
            else if (modoG == "Discapacidad")
            {
                clsDiscapacidades.agregarDiscapacidad(dgvListar, txtAgregar.Text.ToUpper());
            }
            else if (modoG == "Alergia")
            {
                clsAlergias.agregarAlergia(dgvListar, txtAgregar.Text.ToUpper());
            }
            else if (modoG == "Medicamento")
            {
                clsMedicamentos.agregarMedicamento(dgvListar, txtAgregar.Text.ToUpper());
            }
            else if (modoG == "Enfermedad")
            {
                clsEnfermedadesPatologicas.agregarEnfermedad(dgvListar, txtAgregar.Text.ToUpper());
            }
            else if (modoG == "Estado")
            {
                clsEstado.agregarEstado(dgvListar, txtAgregar.Text.ToUpper());
            }
            txtAgregar.Text = "";
        }

        private void pcbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
