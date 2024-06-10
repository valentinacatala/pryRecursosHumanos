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

		public void listarCombo(ComboBox combo)
		{
			clsConexionBaseDatos conexion = new clsConexionBaseDatos();
			conexion.listarCombo(combo,"Areas","IdAreas");
		}
		

	}
}
