using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecursosHumanos
{
    public class clsLicencia
    {
        private int idLicencia;
		private string nombre;
		private int tiempo;//consultar tipo de dato

        public int IdLicencia
		{
			get { return idLicencia; }
			set { idLicencia = value; }
		}
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Tiempo
        {
            get { return tiempo; }
            set { tiempo = value; }
        }

        public static void listarLicencias(ComboBox cbLicencias)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarLicencias(cbLicencias);
        }
        public static void listarLicencias(DataGridView dgvGrilla)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarLicencia(dgvGrilla);
        }
        public static void listarLicenciasPorEmpleado(DataGridView grilla, long cuitEmpleado)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarLicenciaPorEmpleado(grilla,cuitEmpleado);
        }
        public static void agregarLicencia(string nombre, int tiempo,DataGridView dgvGrilla)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.agregarLicencia(nombre,tiempo);
            BD.listarLicencia(dgvGrilla);
        }
        public static void eliminarLicencia(int idLicencia,DataGridView dgvGrilla)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.eliminarLicencia(idLicencia);
            BD.listarLicencia(dgvGrilla);
        }
        public static void modificarLicencia(DataGridView dgvGrilla,int idLicencia,int nuevoTiempo)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.modificarLicencia(idLicencia,nuevoTiempo);
            BD.listarLicencia(dgvGrilla);
        }
    }
}
