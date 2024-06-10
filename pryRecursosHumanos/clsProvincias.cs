using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecursosHumanos
{
    public class clsProvincias
    {
		private int idProvincia;
		private clsPaises idPais;
		private string nombre;

        public int IdProvincia
		{
			get { return idProvincia; }
			set { idProvincia = value; }
		}
        public clsPaises IdPais
        {
            get { return idPais; }
            set { idPais = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public void listarProvincias(ComboBox cbProvincias, int idPais)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarProvincias(cbProvincias, idPais);
        }

    }
}
