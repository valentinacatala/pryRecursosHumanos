using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryRecursosHumanos
{
    public class clsLicencia
    {
        private int idLicencia;
		private string nombre;
		private int tiempo;//consultar tipo de dato

        public int IdLicencia
		{
			get { return idLicencia; }
			set { idLicencia = value; }
		}
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Tiempo
        {
            get { return tiempo; }
            set { tiempo = value; }
        }

        clsConexionBaseDatos conexion = new clsConexionBaseDatos();

        public void agregarLicencia(clsLicencia nuevaLicencia)
        {
            conexion.agregarLicencia(nuevaLicencia.Nombre, nuevaLicencia.Tiempo);
        }

        public void eliminarLicencia(clsLicencia licenciaAEliminar)
        {
            conexion.eliminarLicencia(licenciaAEliminar.IdLicencia);
        }

        public void modificarLicencia(clsLicencia licenciaAModificar)
        {
            conexion.modificarLicencia(licenciaAModificar.IdLicencia, licenciaAModificar.Nombre, licenciaAModificar.Tiempo);
        }
    }
}
