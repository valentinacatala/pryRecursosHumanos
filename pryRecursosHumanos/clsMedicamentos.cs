using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryRecursosHumanos
{
    public class clsMedicamentos
    {
		private int idMedicamento;
		private string nombre;

		public int IdMedicamento
		{
			get { return idMedicamento; }
			set { idMedicamento = value; }
		}
		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

        clsConexionBaseDatos conexion = new clsConexionBaseDatos();

        public void agregarMedicamento(clsMedicamentos nuevoMedicamento)
        {
            conexion.agregarMedicamento(nuevoMedicamento.Nombre);
        }

        public void eliminarMedicamento(clsMedicamentos medicamentoAEliminar)
        {
            conexion.eliminarMedicamento(medicamentoAEliminar.IdMedicamento);
        }

        public void modificarMedicamento(clsMedicamentos medicamentoAModificar)
        {
            conexion.modificarMedicamento(medicamentoAModificar.IdMedicamento, medicamentoAModificar.Nombre);
        }
    }

}
