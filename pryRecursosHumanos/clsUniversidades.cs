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
        public static void agregarUniversidad(string nombre,DataGridView dgvGrilla)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.agregarUniversidad(nombre); 
            BD.listarUniversidad(dgvGrilla);
        }
        public static void eliminarUniversidad(int idUniversidad, DataGridView dgvGrilla)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.eliminarUniversidad(idUniversidad);
            BD.listarUniversidad(dgvGrilla);
        }
        public static void listarUniversidad(DataGridView dgvGrilla)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarUniversidad(dgvGrilla);
        }
    }
}
