using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryRecursosHumanos
{
    public class clsTipoContactos
    {
        private int idTipoContacto;
        private string nombre;

        public int IdTipoContacto
        {
            get { return idTipoContacto; }
            set { idTipoContacto = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}
