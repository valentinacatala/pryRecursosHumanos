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
        #region listarEmpleado
        public void listarEmpleados(DataGridView dgvGrilla)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM Empleados";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tablaEmpleados = new DataTable();
                adaptador.Fill(tablaEmpleados);
                dgvGrilla.DataSource = tablaEmpleados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        #endregion

        #region agregarEmpleado
        public void agregarEmpleado(clsEmpleado nuevoEmpleado)
        {
            // ESTE METODO TIENEN QUE LLAMAR EN LA RESPECTIVA CLASE; NO PROGRAMEN ACA
            bool empleadoNoExiste = validarEmpleado(nuevoEmpleado);
            if (empleadoNoExiste)
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"INSERT INTO Empleados(Cuit, nombre, apellido, IdArea, IdFichaMedica, Domicilio, Telefono, DNI, CorreoElectronico, FechaDeNacimiento, Foto, IdPais, IdEstado, IdTitulo, IdTipoDeContacto, Instagram ) VALUES ('{nuevoEmpleado.Cuit}', '{nuevoEmpleado.Apellido}', '{nuevoEmpleado.Nombre}' ,'{nuevoEmpleado.Instagram}' , '{nuevoEmpleado.DNI}' , '{nuevoEmpleado.Foto}' , '{nuevoEmpleado.Domicilio}' , '{nuevoEmpleado.Telefono}', '{nuevoEmpleado.IdArea}' ,'{nuevoEmpleado.IdFichaMedica}' , '{nuevoEmpleado.IdPais}', '{nuevoEmpleado.IdEstado}', '{nuevoEmpleado.IdTitulo}', '{nuevoEmpleado.IdTipoDeContacto}')";

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexion.Close();
                }
            }
            else
            {
                MessageBox.Show("Ya existe un usuario con ese CUIT");
            }
        }
        public bool validarEmpleado(clsEmpleado empleado)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Empleados WHERE Nombre = '{empleado.Cuit}'";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tablaEmpleados = new DataTable();
                adaptador.Fill(tablaEmpleados);

                if (tablaEmpleados.Rows.Count == 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        #endregion

        #region inicioSesion
        public List<bool> iniciarSesion(clsUsuarios usuario)
        {
            List<bool> user = new List<bool>();
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT Cuit, Admin FROM Usuarios WHERE Cuit = {usuario.Cuit} AND Contraseña = '{usuario.Contrasena}'";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tablaEmpleados = new DataTable();
                adaptador.Fill(tablaEmpleados);

                if (tablaEmpleados.Rows.Count == 1) { user.Add(true); user.Add(Convert.ToBoolean(tablaEmpleados.Rows[0][1])); return user; }
                else { user.Add(false); user.Add(Convert.ToBoolean(tablaEmpleados.Rows[0]["Admin"])); return user; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            // ESTE METODO TIENEN QUE LLAMAR EN LA RESPECTIVA CLASE; NO PROGRAMEN ACA
        }
        #endregion
        
        #region registrarUsuario
        public void registrarUsuario(clsUsuarios nuevoUsuario)
        {
            // REHACER CUANDO EXISTAN LOS DATOS
            bool usuarioNoExiste = validarUsuario(nuevoUsuario);
            if (usuarioNoExiste)
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $@"INSERT INTO Usuarios(Cuit, Contraseña, Admin) 
                                VALUES ({nuevoUsuario.Cuit}, '{nuevoUsuario.Contrasena}', {nuevoUsuario.Admin})";

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexion.Close();
                }
            }
            else
            {
                MessageBox.Show("Ya existe un usuario con ese CUIT");
            }
        }
        public bool validarUsuario(clsUsuarios usuario)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Usuarios WHERE Cuit = {usuario.Cuit}";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tablaEmpleados = new DataTable();
                adaptador.Fill(tablaEmpleados);

                if (tablaEmpleados.Rows.Count == 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            // ESTE METODO TIENEN QUE LLAMAR EN LA RESPECTIVA CLASE; NO PROGRAMEN ACA
        }
        #endregion

    }
}
