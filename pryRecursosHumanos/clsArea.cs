using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryRecursosHumanos
{
    public class clsArea
    {
		private int idArea;
		private string nombre;
        private int idSueldo; //Nuevo

        public int IdArea
		{
			get { return idArea; }
			set { idArea = value; }
		}
		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}
        public int IdSueldo //Nuevo
        {
            get { return idSueldo; }
            set { idSueldo = value; }
        }
        clsConexionBaseDatos conexion = new clsConexionBaseDatos();

        public void agregarArea(clsArea nuevaArea)
        {
            conexion.agregarArea(nuevaArea.Nombre, nuevaArea.IdSueldo); 
        }

        public void eliminarArea(clsArea areaAEliminar)
        {
            conexion.eliminarArea(areaAEliminar.IdArea);
        }

        public void modificarArea(clsArea areaAModificar)
        {
            conexion.modificarArea(areaAModificar.IdArea, areaAModificar.Nombre, areaAModificar.IdSueldo);
        }

    }
}
