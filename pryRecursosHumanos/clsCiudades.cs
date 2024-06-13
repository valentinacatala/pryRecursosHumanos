using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryRecursosHumanos
{
    public class clsCiudades
    {
		private int idCiudad;
		private clsProvincias idProvincia;
		private string nombre;

        public  int IdCiudad
		{
			get { return idCiudad; }
			set { idCiudad = value; }
		}
        public clsProvincias IdProvincia
        {
            get { return idProvincia; }
            set { idProvincia = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        clsConexionBaseDatos conexion = new clsConexionBaseDatos();

        public void agregarCiudad(clsCiudades nuevaCiudad)
        {
            conexion.agregarCiudad(nuevaCiudad.IdProvincia.IdProvincia, nuevaCiudad.Nombre);
        }

        public void eliminarCiudad(clsCiudades ciudadAEliminar)
        {
            conexion.eliminarCiudad(ciudadAEliminar.IdCiudad);
        }

        public void modificarCiudad(clsCiudades ciudadAModificar)
        {
            conexion.modificarCiudad(ciudadAModificar.IdCiudad, ciudadAModificar.Nombre);
        }

    }
}
