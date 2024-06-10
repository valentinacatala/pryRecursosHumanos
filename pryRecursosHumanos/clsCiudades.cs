using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecursosHumanos
{
    public class clsCiudades
    {
		private int idCiudad;
		private clsProvincias idProvincia;
		private string nombre;

        public  int IdCiudad
		{
			get { return idCiudad; }
			set { idCiudad = value; }
		}
        public clsProvincias IdProvincia
        {
            get { return idProvincia; }
            set { idProvincia = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public void listarCiudades(ComboBox cbCiudades, int idProvincia)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarCiudades(cbCiudades, idProvincia);
        }

    }
}
