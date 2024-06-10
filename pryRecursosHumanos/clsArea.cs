using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecursosHumanos
{
    public class clsArea
    {
		private int idArea;
		private string nombre;

		public int IdArea
		{
			get { return idArea; }
			set { idArea = value; }
		}
		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		public static void listarArea(ComboBox cbAreas)
		{
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.listarAreas(cbAreas);
		}


	}
}
