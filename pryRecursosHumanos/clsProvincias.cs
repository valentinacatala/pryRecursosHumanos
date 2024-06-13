using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryRecursosHumanos
{
    public class clsProvincias
    {
		private int idProvincia;
		private clsPaises idPais;
		private string nombre;

        public int IdProvincia
		{
			get { return idProvincia; }
			set { idProvincia = value; }
		}
        public clsPaises IdPais
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

        public void agregarProvincia(int idPais, string nuevaProvincia)
        {
            conexion.agregarProvincia(idPais, nuevaProvincia);
        }
        public void eliminarProvincia(int idProvincia)
        {
            conexion.eliminarProvincia(idProvincia);
        }
        public void modificarProvincia(int idProvincia, string provinciaNueva)
        {
            conexion.modificarProvincia(idProvincia, provinciaNueva);
        }


    }
}
