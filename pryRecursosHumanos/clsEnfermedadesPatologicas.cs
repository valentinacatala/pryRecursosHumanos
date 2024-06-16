using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

		public static void listarEnfermedades(ComboBox cbEnfermedades)
		{
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.listarEnfermedades(cbEnfermedades);
		}
		public static void agregarEnfermedad(DataGridView dgvGrilla,string nuevaEnfermedad)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.agregarEnfermedadPatologica(nuevaEnfermedad);
			BD.listarEnfermedadPatologica(dgvGrilla,nuevaEnfermedad);
		}
	}
}
