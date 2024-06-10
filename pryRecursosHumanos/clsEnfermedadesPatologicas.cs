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



	}
}
