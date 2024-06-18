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
		private int tiempo;

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
		public int Tiempo
		{
			get { return tiempo; }
			set { tiempo = value; }
		}

        public static void listarSanciones(ComboBox cbSanciones)
		{
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.listarSanciones(cbSanciones);
		}
        public static void listarSanciones(DataGridView dgvGrilla)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarSancion(dgvGrilla);
        }
        public static void listarSancionesPorEmpleado(DataGridView dgvSanciones, string cuitEmpleado)
		{
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.listarSancionPorEmpleado(dgvSanciones, cuitEmpleado);
		}
        public static void agregarSancion(string nombre, int tiempo, DataGridView dgvGrilla)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.agregarSancion(nombre, tiempo);
            BD.listarSancion(dgvGrilla);
        }
		public static void eliminarSancion(int idSancion,DataGridView dgvGrilla)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.eliminarSancion(idSancion);
            BD.listarSancion(dgvGrilla);
        }
		public static void modificarSancion(DataGridView dgvGrilla,int idSancion,int nuevoTiempo)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.modificarSancion(idSancion,nuevoTiempo);
            BD.listarSancion(dgvGrilla);
        }
    }
}
