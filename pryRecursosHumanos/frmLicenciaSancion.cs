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
                lblTitulo.Text = $"Sanciones: {empleado.Cuit}";
                clsSanciones.listarSanciones(cboDatos);
                clsSanciones.listarSancionesPorEmpleado(dgvListar, empleado.Cuit);
            }
            else
            {
                lblNombreDato.Text = "Agregar licencia";
                lblTitulo.Text = $"Licencias: {empleado.Cuit}";
                clsLicencia.listarLicencias(cboDatos);
                clsLicencia.listarLicenciasPorEmpleado(dgvListar, empleado.Cuit);
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
                    string fechaInicio = dtpFechaInicio.Value.ToString("dd/MM/yyyy");
                    clsEmpleado.agregarSancion(sancion, empleado, txtObservaciones.Text, Convert.ToDateTime(fechaInicio));
                    clsSanciones.listarSancionesPorEmpleado(dgvListar, empleado.Cuit);
                    clsEmpleado.actualizarEstadoEmpleado(empleado.Cuit, 2);
                }
            }
            else
            {
                clsEstado estado = new clsEstado();
                estado.IdEstado = 1; 
                if (cboDatos.SelectedItem is DataRowView selectedRow)
                {
                    clsLicencia licencia = new clsLicencia
                    {
                        IdLicencia = (int)selectedRow["IdLicencia"],
                        Nombre = selectedRow["Nombre"].ToString(),
                        Tiempo = (int)selectedRow["Tiempo"]
                    };
                    string fechaInicio = dtpFechaInicio.Value.ToString("dd/MM/yyyy");
                    clsEmpleado.agregarLicencia(licencia, empleado, Convert.ToDateTime(fechaInicio), txtObservaciones.Text);
                    clsLicencia.listarLicenciasPorEmpleado(dgvListar, empleado.Cuit);
                    clsEmpleado.actualizarEstadoEmpleado(empleado.Cuit, 3);
                }
            }
        }

        private void dgvListar_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(modo == "sanciones")
            {
                int idSancion = Convert.ToInt32(dgvListar.SelectedRows[0].Cells["IdSancion"].Value);
                DialogResult result = MessageBox.Show("¿Eliminar sancion?", "Aviso", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    clsEmpleado.eliminarSancion(empleado.Cuit, idSancion);
                    clsSanciones.listarSancionesPorEmpleado(dgvListar, empleado.Cuit);
                }
            }
            else
            {
                int idLicencia = Convert.ToInt32(dgvListar.SelectedRows[0].Cells["IdLicencia"].Value);
                DialogResult result = MessageBox.Show("¿Eliminar licencia?", "Aviso", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    clsEmpleado.eliminarLicencia(empleado.Cuit, idLicencia);
                    clsLicencia.listarLicenciasPorEmpleado(dgvListar, empleado.Cuit);
                }
            }
        }
    }
}
