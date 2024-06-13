using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pryRecursosHumanos;

namespace pryRecursosHumanos
{
    public class clsPaises
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

        clsConexionBaseDatos conexion = new clsConexionBaseDatos();
        public void agregarPais(string nuevoPais)
        {
            conexion.agregarPais(nuevoPais);
        }
        public void eliminarPais(string paisAEliminar)
        {
            conexion.eliminarPais(paisAEliminar);
        }
        public void modificarPais(int IdPais, string paisNuevo)
        {
            conexion.modificarPais(IdPais, paisNuevo);
        }
    }
}
