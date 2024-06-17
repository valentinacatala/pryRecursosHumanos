using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

	}
}
