using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryRecursosHumanos
{
    public class clsLicenciasEmpleados
    {
		private int cuit;
		private int idLicencia;
		private string estado;
		private string tiempo;

		public int Cuit
		{
			get { return cuit; }
			set { cuit = value; }
		}
		public int IdLicencia
		{
			get { return idLicencia; }
			set { idLicencia = value; }
		}
		public string Estado
		{
			get { return estado; }
			set { estado = value; }
		}
		public string Tiempo
		{
			get { return tiempo; }
			set { tiempo = value; }
		}

	}
}
