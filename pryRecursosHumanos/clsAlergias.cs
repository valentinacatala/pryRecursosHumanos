using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecursosHumanos
{
    public class clsAlergias
    {
		private int idAlergias;
		private string nombre;

		public int IdAlergias
		{
			get { return idAlergias; }
			set { idAlergias = value; }
		}
		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		public static void listarAlergias(ComboBox cbAlergias)
		{
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.listarAlergias(cbAlergias);
		}

	}
}
