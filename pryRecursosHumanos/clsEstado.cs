using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecursosHumanos
{
    public class clsEstado
    {
		private int idEstado;
		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}


		public int IdEstado
		{
			get { return idEstado; }
			set { idEstado = value; }
		}

		public static void listarEstados(ComboBox cbEstados)
		{
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.listarEstados(cbEstados);
		}
        public static void listarEstados(DataGridView dgvGrilla, string nuevoEstado)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarEstado(dgvGrilla, nuevoEstado);
        }

        public static void agregarEstado(DataGridView dgvGrilla,string nuevoEstado)
		{
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.agregarEstado(nuevoEstado);
			BD.listarEstado(dgvGrilla,nuevoEstado);
		}
		public static void eliminarEstado(int idEstado,string nombreEstado,DataGridView dgvGrilla)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.eliminarEstado(idEstado,nombreEstado);
            BD.listarEstado(dgvGrilla, nombreEstado);

        }
    }
}
