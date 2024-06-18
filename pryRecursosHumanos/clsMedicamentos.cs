using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecursosHumanos
{
    public class clsMedicamentos
    {
		private int idMedicamento;
		private string nombre;

		public int IdMedicamento
		{
			get { return idMedicamento; }
			set { idMedicamento = value; }
		}
		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		public static void listarMedicamentos(ComboBox cbMedicamentos)
		{
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.listarMedicamentos(cbMedicamentos);
		}
        public static void listarMedicamentos(DataGridView dgvGrilla, string nuevoMedicamento)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarMedicamento(dgvGrilla, nuevoMedicamento);
        }
        public static void agregarMedicamento(DataGridView dgvGrilla,string nuevoMedicamento)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.agregarMedicamento(nuevoMedicamento);
			BD.listarMedicamento(dgvGrilla,nuevoMedicamento);
        }
		public static void elimiarMedicamento(int idMedicamento,string nombreMedicamento,DataGridView dgvGrilla)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.eliminarMedicamento(idMedicamento, nombreMedicamento);
            BD.listarMedicamento(dgvGrilla, nombreMedicamento);

        }
    }
}
