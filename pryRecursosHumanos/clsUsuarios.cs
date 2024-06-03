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
		private int contrasena;
		private bool admin;

        public int Cuit
        {
            get { return cuit; }
            set { cuit = value; }
        }
        public int IdUsuario
		{
			get { return idUsuario; }
			set { idUsuario = value; }
		}
        public int Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }
        public bool Admin
        {
            get { return admin; }
            set { admin = value; }
        }

        public void registrar()
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            // LLENER LOS DATOS DEL USUARIO ANTES DE LLAMAR A ESTE METODO
            BD.registrarUsuario(this);
        }
    }
}
