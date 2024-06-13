using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryRecursosHumanos
{
    public class clsEstado
    {
		private int idEstado;
		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}


		public int IdEstado
		{
			get { return idEstado; }
			set { idEstado = value; }
		}
        clsConexionBaseDatos conexion = new clsConexionBaseDatos();

        public void agregarEstado(clsEstado nuevoEstado)
        {
            conexion.agregarEstado(nuevoEstado.Nombre);
        }

        public void eliminarEstado(clsEstado estadoAEliminar)
        {
            conexion.eliminarEstado(estadoAEliminar.IdEstado);
        }

        public void modificarEstado(clsEstado estadoAModificar)
        {
            conexion.modificarEstado(estadoAModificar.IdEstado, estadoAModificar.Nombre);
        }

    }
}
