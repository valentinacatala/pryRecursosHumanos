using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecursosHumanos
{
    public class clsSanciones
    {
		private int idSancion;
		private string nombre;
		private int tiempo;

		public int IdSancion
		{
			get { return idSancion; }
			set { idSancion = value; }
		}
		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}
		public int Tiempo
		{
			get { return tiempo; }
			set { tiempo = value; }
		}

        public static void listarSanciones(ComboBox cbSanciones)
		{
			
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.listarSanciones(cbSanciones);
		}

		public static void listarSancionesPorEmpleado(DataGridView dgvSanciones, long cuitEmpleado)
		{
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.listarSancionPorEmpleado(dgvSanciones, cuitEmpleado);
		}
	}
}
