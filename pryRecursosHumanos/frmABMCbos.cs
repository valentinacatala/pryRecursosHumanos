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
                clsPaises clsPaises = new clsPaises();
                clsPaises.agregarPais(dgvListar,txtAgregar.Text);
            }
            else if (modoG == "Discapacidad")
            {
                clsDiscapacidades clsDiscapacidades = new clsDiscapacidades();
                clsDiscapacidades.agregarDiscapacidad(dgvListar, txtAgregar.Text);
            }
            else if (modoG == "Alergia")
            {
                clsAlergias clsAlergias = new clsAlergias();
                clsAlergias.agregarAlergia(dgvListar, txtAgregar.Text);
            }
            else if (modoG == "Medicamento")
            {
                clsMedicamentos clsMedicamentos = new clsMedicamentos();
                clsMedicamentos.agregarMedicamento(dgvListar, txtAgregar.Text);
            }
            else if (modoG == "Enfermedad")
            {
                clsEnfermedadesPatologicas clsEnfermedadesPatologicas = new clsEnfermedadesPatologicas();
                clsEnfermedadesPatologicas.agregarEnfermedad(dgvListar, txtAgregar.Text);
            }
            else if (modoG == "Estado")
            {
                clsEstado clsEstado = new clsEstado();
                clsEstado.agregarEstado(dgvListar, txtAgregar.Text);
            }
            txtAgregar.Text = "";
        }

        private void pcbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
