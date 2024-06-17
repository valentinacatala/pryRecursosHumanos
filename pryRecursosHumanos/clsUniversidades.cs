using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecursosHumanos
{
    public class clsUniversidades
    {
		private int idUniversidad;

		private string nombre;

		public int IdUniversidad
		{
			get { return idUniversidad; }
			set { idUniversidad = value; }
		}
		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

        public static void listarUniversidades(ComboBox cbTitulos)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarUniversidades(cbTitulos);
        }
    }
}
