using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecursosHumanos
{
    public class clsEmpleado
    {
		private int idEmpleado;
		private string nombre;
		private clsArea area;

		public int IdEmpleado
		{
			get { return idEmpleado; }
			set { idEmpleado = value; }
		}
		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}
		public clsArea Area
		{
			get { return area; }
			set { area = value; }
		}

		public void listarEmpleados(DataGridView dgvGrilla)
		{
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.listarEmpleados(dgvGrilla);
		}
	}
}
