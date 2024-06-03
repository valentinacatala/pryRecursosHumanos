using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryRecursosHumanos
{
    public class clsSancionesEmpleados
    {
		private int cuit;
		private int idSancion;
		private string observaciones;
		private DateTime fecha;


		public int Cuit
		{
			get { return cuit; }
			set { cuit = value; }
		}
		public int IdSancion
		{
			get { return idSancion; }
			set { idSancion = value; }
		}
		public string Observaciones
		{
			get { return observaciones; }
			set { observaciones = value; }
		}
		public DateTime Fecha
		{
			get { return fecha; }
			set { fecha = value; }
		}


	}
}
