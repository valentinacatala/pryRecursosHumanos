using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryRecursosHumanos
{
    public class clsMedicamentoFichaMedica
    {
		private int idMedicamento;
		private int idFichaMedica;
		private string dosis;

		public int IdMedicamento
		{
			get { return idMedicamento; }
			set { idMedicamento = value; }
		}
		public int IdFichaMedica
		{
			get { return idFichaMedica; }
			set { idFichaMedica = value; }
		}
		public string Dosis
		{
			get { return dosis; }
			set { dosis = value; }
		}



	}
}
