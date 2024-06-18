using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecursosHumanos
{
    public class clsPresentismo
    {
		private int idPresentismo;
		private DateTime fecha;

		public DateTime Fecha
		{
			get { return fecha; }
			set { fecha = value; }
		}



		public int IdPresentismo
		{
			get { return idPresentismo; }
			set { idPresentismo = value; }
		}

		public static void agregarFalta(int cuit, string fecha)
		{
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.agregarFaltas(cuit, fecha);
		}

		public static void eliminarFaltas(int id)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.eliminarFaltas(id);
        }

		public static void listarFaltas(DataGridView dgvFaltas, int cuit)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarFaltas(dgvFaltas, cuit);
        }
	}
}
