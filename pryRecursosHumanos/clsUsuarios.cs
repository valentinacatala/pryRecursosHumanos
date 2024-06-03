using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryRecursosHumanos
{
    public class clsUsuarios
    {
		private int idUsuario;
		private int cuit;
		private int contraseña;
		private bool admin;

        public int IdUsuario
		{
			get { return idUsuario; }
			set { idUsuario = value; }
		}
        public int Cuit
        {
            get { return cuit; }
            set { cuit = value; }
        }
        public int Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }
        public bool Admin
        {
            get { return admin; }
            set { admin = value; }
        }
    }
}
