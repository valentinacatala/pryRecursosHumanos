using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecursosHumanos
{
    public class clsDiscapacidades
    {
		private int idDiscapacidad;
		private string nombre;

		public int IdDiscapacidad
		{
			get { return idDiscapacidad; }
			set { idDiscapacidad = value; }
		}
		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		public static void listarDiscapacidades(ComboBox cbDiscapacidades)
		{
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.listarDiscapacidades(cbDiscapacidades);
		}
        public static void listarDiscapacidades(DataGridView dgvGrilla, string discapacidad)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarDiscapacidad(dgvGrilla, discapacidad);
        }
        public static void agregarDiscapacidad(DataGridView dgvGrilla, string nuevaDiscapacidad)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.agregarDiscapacidad(nuevaDiscapacidad);
			BD.listarDiscapacidad(dgvGrilla,nuevaDiscapacidad);
        }
		public static void eliminarDiscapacidad(int idDiscapacidad,string nombreDiscapacidad,DataGridView dgvGrilla)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.eliminarDiscapacidad(idDiscapacidad,nombreDiscapacidad);
            BD.listarDiscapacidad(dgvGrilla, nombreDiscapacidad);

        }
    }
}
