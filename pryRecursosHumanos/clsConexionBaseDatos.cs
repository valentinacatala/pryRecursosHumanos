using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace pryRecursosHumanos
{
    public class clsConexionBaseDatos
    {
        OleDbCommand comando;
        OleDbConnection conexion;
        OleDbDataAdapter adaptador;
        string cadena;
        public clsConexionBaseDatos()
        {
            cadena = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
        }

        public void listarEmpleados(DataGridView dgvGrilla)
        {
            conexion = new OleDbConnection(cadena);
            comando = new OleDbCommand();

            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT E.IdEmpleado, E.Nombre, A.Nombre FROM Empleados E, Areas A WHERE E.IdArea = A.IdArea";

            adaptador = new OleDbDataAdapter(comando);
            DataTable tablaEmpleados = new DataTable();
            adaptador.Fill(tablaEmpleados);
            dgvGrilla.DataSource = tablaEmpleados;
        }
    }
}
