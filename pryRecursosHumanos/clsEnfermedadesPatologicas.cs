using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryRecursosHumanos
{
    public class clsEnfermedadesPatologicas
    {
		private int idEnfermedadPatologica;
		private string nombre;
		private bool contagiosa;



		public int IdEnfermedadPatologica
		{
			get { return idEnfermedadPatologica; }
			set { idEnfermedadPatologica = value; }
		}
		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}
		public bool Contagiosa
		{
			get { return contagiosa; }
			set { contagiosa = value; }
		}

        clsConexionBaseDatos conexion = new clsConexionBaseDatos();

        public void agregarEnfermedadPatologica(clsEnfermedadesPatologicas nuevaEnfermedad)
        {
            conexion.agregarEnfermedadPatologica(nuevaEnfermedad.Nombre);
        }

        public void eliminarEnfermedadPatologica(clsEnfermedadesPatologicas enfermedadAEliminar)
        {
            conexion.eliminarEnfermedadPatologica(enfermedadAEliminar.IdEnfermedadPatologica);
        }

        public void modificarEnfermedadPatologica(clsEnfermedadesPatologicas enfermedadAModificar)
        {
            conexion.modificarEnfermedadPatologica(enfermedadAModificar.IdEnfermedadPatologica, enfermedadAModificar.Nombre);
        }

    }
}
