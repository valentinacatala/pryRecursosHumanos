using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryRecursosHumanos
{
    public class clsFichaMedica
    {
		private int idFichaMedica;
		private int idAlergia;
		private int idEnfermedadPatologica;
		private int idDiscapacidad;

		public int IdFichaMedica
		{
			get { return idFichaMedica; }
			set { idFichaMedica = value; }
		}
		public int IdAlergia
		{
			get { return idAlergia; }
			set { idAlergia = value; }
		}
		public int IdEnfermedadPatologica
		{
			get { return idEnfermedadPatologica; }
			set { idEnfermedadPatologica = value; }
		}
		public int IdDiscapacidad
        {
			get { return idDiscapacidad; }
			set { idDiscapacidad = value; }
		}

	}
}
