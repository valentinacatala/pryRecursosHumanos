using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecursosHumanos
{
    public class clsTitulo
    {
		private int idTitulo;
		private string nombre;
		private int idUniversidad;

		public int IdTitulo
		{
			get { return idTitulo; }
			set { idTitulo = value; }
		}
		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}
		public int IdUniversidad
		{
			get { return idUniversidad; }
			set { idUniversidad = value; }
		}

		public static void listarTitulos(ComboBox cbTitulos, int idUniversidad)
		{
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.listarTitulos(cbTitulos, idUniversidad);
		}
	}
}
