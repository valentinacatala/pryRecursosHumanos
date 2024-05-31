using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryRecursosHumanos
{
    internal class clsPaises
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
    }
}
