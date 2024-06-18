using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

		public static void listarAlergias(ComboBox cbAlergias)
		{
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.listarAlergias(cbAlergias);
		}
        public static void listarAlergias(DataGridView dgvGrilla, string nuevaAlergia)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarAlergia(dgvGrilla, nuevaAlergia);
        }
        public static void agregarAlergia(DataGridView dgvGrilla, string nuevaAlergia)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.agregarAlergia(nuevaAlergia);
			BD.listarAlergia(dgvGrilla,nuevaAlergia);
        }
		public static void eliminarAlergia(int idAlergia, string nombreAlergia,DataGridView dgvGrilla)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.eliminarAlergia(idAlergia,nombreAlergia);
            BD.listarAlergia(dgvGrilla, nombreAlergia);

        }
    }
}
