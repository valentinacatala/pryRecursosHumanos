using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryRecursosHumanos
{
    public class clsMedioContactos
    {
		private int idMedioContacto;
		private string nombre;

        public int IdMedioContacto
		{
			get { return idMedioContacto; }
			set { idMedioContacto = value; }
		}
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

    }
}
