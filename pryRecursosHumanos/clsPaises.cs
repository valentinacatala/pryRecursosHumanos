using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecursosHumanos
{
    public class clsPaises
    {
		private int idPais;
		private string nombre;

        public int IdPais
		{
			get { return idPais; }
			set { idPais = value; }
		}
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public static void listarPaises(ComboBox cbPaises)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarPaises(cbPaises);
        }
        public static void agregarPais(DataGridView dgvGrilla,string nuevoPais)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.agregarPais(nuevoPais);
            BD.listarPaises(dgvGrilla,nuevoPais);
        }
    }
}
