﻿using System;
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
                comando.CommandText = "SELECT E.IdEmpleado, E.Nombre, A.Nombre FROM Empleados E, Areas A WHERE E.IdArea = A.IdArea";

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
                    comando.CommandText = $"INSERT INTO Empleados(Nombre, IdArea) VALUES ('{nuevoEmpleado.Cuit}', '{2}')";

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
        public bool iniciarSesion(clsUsuarios usuario)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT Nombre, Admin FROM Empleados WHERE Nombre = '{usuario.Cuit}' AND Contraseña = '{usuario.Contrasena}'";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tablaEmpleados = new DataTable();
                adaptador.Fill(tablaEmpleados);

                if (tablaEmpleados.Rows.Count == 1) return true;
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
                    comando.CommandText = $"INSERT INTO Empleados(Nombre, IdArea) VALUES ('{nuevoUsuario.Cuit}', '{2}')";

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
                comando.CommandText = $"SELECT * FROM Empleados WHERE Nombre = '{usuario.Cuit}'";

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
