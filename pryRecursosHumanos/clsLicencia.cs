using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryRecursosHumanos
{
    internal class clsLicencia
    {
		private int idLicencia;
		private string nombre;
		private int tiempo;//consultar tipo de dato

        public int IdLicencia
		{
			get { return idLicencia; }
			set { idLicencia = value; }
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

    }
}
