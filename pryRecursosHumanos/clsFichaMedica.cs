using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public static void agregarEnfermedad(int idFichaMedica, int idEnfermedad)
        {
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.agregarEnfermedadAFicha(idFichaMedica, idEnfermedad);
        }

		public static void listarEnfermedades(DataGridView dgvEnfermedades, int idFichaMedica)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.listarEnfermedadesPorFicha(dgvEnfermedades, idFichaMedica);
        }

        public static void agregarMedicamento(int idFichaMedica, int idMedicamento, double dosis)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.agregarMedicamentoAFicha(idFichaMedica, idMedicamento,dosis);
        }

        public static void listarMedicamentos(DataGridView dgvMedicamentos, int idFichaMedica)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarMedicamentosPorFicha(dgvMedicamentos, idFichaMedica);
        }

        public static void agregarDiscapacidad(int idFichaMedica, int idDiscapacidad)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.agregarDiscapacidadAFicha(idFichaMedica, idDiscapacidad);
        }
        public static void listarDiscapacidades(DataGridView dgvDiscapacidades, int idFichaMedica)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarDiscapacidadesPorFicha(dgvDiscapacidades, idFichaMedica);
        }

        public static void agregarAlergia(int idFichaMedica, int idAlergia)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.agregarAlergiaAFicha(idFichaMedica, idAlergia);
        }
        public static void listarAlergias(DataGridView dgvAlergias, int idFichaMedica)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarAlergiasPorFicha(dgvAlergias, idFichaMedica);
        }
    }
}
