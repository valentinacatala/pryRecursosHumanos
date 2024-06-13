using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryRecursosHumanos
{
    public class clsAlergias
    {
		private int idAlergias;
		private string nombre;

		public int IdAlergias
		{
			get { return idAlergias; }
			set { idAlergias = value; }
		}
		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}


        clsConexionBaseDatos conexion = new clsConexionBaseDatos();

        public void agregarAlergia(clsAlergias nuevaAlergia)
        {
            conexion.agregarAlergia(nuevaAlergia.Nombre);
        }

        public void eliminarAlergia(clsAlergias alergiaAEliminar)
        {
            conexion.eliminarAlergia(alergiaAEliminar.IdAlergias);
        }

        public void modificarAlergia(clsAlergias alergiaAModificar)
        {
            conexion.modificarAlergia(alergiaAModificar.IdAlergias, alergiaAModificar.Nombre);
        }
    }
}
