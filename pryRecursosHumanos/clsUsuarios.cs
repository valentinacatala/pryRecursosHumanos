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
		private long cuit;
		private string contrasena;
		private bool admin;

        public long Cuit
        {
            get { return cuit; }
            set { cuit = value; }
        }
        public int IdUsuario
		{
			get { return idUsuario; }
			set { idUsuario = value; }
		}
        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }
        public bool Admin
        {
            get { return admin; }
            set { admin = value; }
        }

        public bool registrar(clsUsuarios nuevoUsuario)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            // LLENER LOS DATOS DEL USUARIO ANTES DE LLAMAR A ESTE METODO
            return BD.registrarUsuario(nuevoUsuario);
        }
        public List<bool> Iniciar(clsUsuarios User)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            // LLENER LOS DATOS DEL USUARIO ANTES DE LLAMAR A ESTE METODO
            return BD.iniciarSesion(User);
        }
    }
}
