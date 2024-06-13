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
    public partial class frmLicenciaSancion : Form
    {
        private string modo = "";
        private clsEmpleado empleado = null;
        public frmLicenciaSancion(string modo, clsEmpleado empleado)
        {
            InitializeComponent();
            this.modo = modo;
            this.empleado = empleado;
        }

        private void frmLicenciaSancion_Load(object sender, EventArgs e)
        {
            if(modo == "sanciones")
            {
                lblNombreDato.Text = "Agregar sanciones";
                lblTitulo.Text = "Sanciones";
                clsSanciones.listarSanciones(cboDatos);
                clsSanciones.listarSancionesPorEmpleado(dgvListar, empleado.Cuit);
            }
            else
            {
                lblNombreDato.Text = "Agregar licencia";
                lblTitulo.Text = "Licencias";
                clsLicencia.listarLicencias(cboDatos);
            }
        }

        private void pcbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (modo == "sanciones")
            {
                if (cboDatos.SelectedItem is DataRowView selectedRow)
                {
                    clsSanciones sancion = new clsSanciones
                    {
                        IdSancion = (int)selectedRow["IdSancion"],
                        Nombre = selectedRow["Nombre"].ToString(),
                        Tiempo = (int)selectedRow["Tiempo"]
                    };
                    clsEmpleado.agregarSancion(sancion, empleado, txtObservaciones.Text, dtpFechaInicio.Value);
                    clsSanciones.listarSancionesPorEmpleado(dgvListar, empleado.Cuit);
                }
            }
        }
    }
}
