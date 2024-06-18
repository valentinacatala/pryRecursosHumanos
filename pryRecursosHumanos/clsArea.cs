using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecursosHumanos
{
    public class clsArea
    {
		private int idArea;
		private string nombre;

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

		public static void listarArea(ComboBox cbAreas)
		{
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.listarAreas(cbAreas);
		}
        public static void listarArea(DataGridView dgvGrilla,string nombreArea)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarAreas(dgvGrilla,nombreArea);
        }
        public static void agregarArea(string nombreArea, int sueldo,DataGridView dgvGrilla)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.agregarArea(nombreArea,sueldo);
			BD.listarAreas(dgvGrilla,nombreArea);
        }
		public static void modArea(string nombreArea, int sueldo, DataGridView dgvGrilla,int idArea)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.modificarArea(idArea,sueldo);
            BD.listarAreas(dgvGrilla, nombreArea);
        }
    }
}
