using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecursosHumanos
{
    public class clsCiudades
    {
        private int idCiudad;
        private clsProvincias idProvincia;
        private string nombre;

        public int IdCiudad
        {
            get { return idCiudad; }
            set { idCiudad = value; }
        }
        public clsProvincias IdProvincia
        {
            get { return idProvincia; }
            set { idProvincia = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public static void listarCiudades(ComboBox cbCiudades, int idProvincia)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarCiudades(cbCiudades, idProvincia);
        }
        public static void listarCiudades(DataGridView dgvGrilla)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarCiudades(dgvGrilla);
        }

        public static void agregarCiudad(int idProvincia, string nuevaCiudad, DataGridView dgvGrilla, int idPais)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.agregarCiudad(idProvincia, nuevaCiudad);
            BD.listarCiudades(dgvGrilla, idPais);
        }
        public static void eliminarCiudad(int idCiudad,DataGridView dgvGrilla,int idPais)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.eliminarCiudad(idCiudad);
            BD.listarCiudades(dgvGrilla, idPais);
        }
    }
}
