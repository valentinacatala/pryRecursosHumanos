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
		private string tiempo;

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
		public string Tiempo
		{
			get { return tiempo; }
			set { tiempo = value; }
		}

		public static void listarSanciones(ComboBox cbSanciones)
		{
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.listarSanciones(cbSanciones);
		}
	}
}
