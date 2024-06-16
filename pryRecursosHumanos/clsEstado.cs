using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecursosHumanos
{
    public class clsEstado
    {
		private int idEstado;
		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}


		public int IdEstado
		{
			get { return idEstado; }
			set { idEstado = value; }
		}

		public static void listarEstados(ComboBox cbEstados)
		{
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.listarEstados(cbEstados);
		}

		public static void agregarEstado(DataGridView dgvGrilla,string nuevoEstado)
		{
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.agregarEstado(nuevoEstado);
			BD.listarEstado(dgvGrilla,nuevoEstado);
		}

	}
}
