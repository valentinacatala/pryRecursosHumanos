using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryRecursosHumanos
{
    public class clsDiscapacidades
    {
		private int idDiscapacidad;
		private string nombre;

		public int IdDiscapacidad
		{
			get { return idDiscapacidad; }
			set { idDiscapacidad = value; }
		}
		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

        clsConexionBaseDatos conexion = new clsConexionBaseDatos();

        public void agregarDiscapacidad(clsDiscapacidades nuevaDiscapacidad)
        {
            conexion.agregarDiscapacidad(nuevaDiscapacidad.Nombre);
        }

        public void eliminarDiscapacidad(clsDiscapacidades discapacidadAEliminar)
        {
            conexion.eliminarDiscapacidad(discapacidadAEliminar.IdDiscapacidad);
        }

        public void modificarDiscapacidad(clsDiscapacidades discapacidadAModificar)
        {
            conexion.modificarDiscapacidad(discapacidadAModificar.IdDiscapacidad, discapacidadAModificar.Nombre);
        }
    }
}

