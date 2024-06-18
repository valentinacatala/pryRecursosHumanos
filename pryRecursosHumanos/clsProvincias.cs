using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public static void listarProvincias(ComboBox cbProvincias, int idPais)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarProvincias(cbProvincias, idPais);
        }
        public static void listarProvincias(DataGridView dgvGrilla)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarProvincias(dgvGrilla);
        }
        public static void agregarProvincia(int idPais,string nuevaProvincia,DataGridView dgvGrilla)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.agregarProvincia(idPais,nuevaProvincia);
            BD.listarProvincias(dgvGrilla,idPais);
        }
        public static void eliminarProvincia(int idProvincia,int idPais,DataGridView dgvGrilla)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.eliminarProvincia(idProvincia);
            BD.listarProvincias(dgvGrilla, idPais);
        }
    }
}
