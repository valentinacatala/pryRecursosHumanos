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
            bool empleadoNoExiste = validarEmpleado(nuevoEmpleado);
            if (empleadoNoExiste)
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.Clear();
                    comando.CommandText = $@"INSERT INTO Empleados
                                            (Cuit, nombre, apellido, IdArea, IdFichaMedica, Domicilio, Telefono, DNI, CorreoElectronico, FechaDeNacimiento, Foto, IdPais, IdEstado, IdTitulo, IdTipoDeContacto, Instagram)
                                            VALUES (@CUIT, '@NOMBRE', '@APELLIDO', @AREA, @FICHA, '@DOMICILIO', @TELEFONO, @DNI, '@EMAIL', @NACIMIENTO, '@FOTO', @PAIS, @ESTADO, @TITULO, '@INSTAGRAM')";
                    comando.Parameters.AddWithValue("CUIT", nuevoEmpleado.Cuit);
                    comando.Parameters.AddWithValue("NOMBRE", nuevoEmpleado.Nombre);
                    comando.Parameters.AddWithValue("APELLIDO", nuevoEmpleado.Apellido);
                    comando.Parameters.AddWithValue("AREA", nuevoEmpleado.IdArea);
                    comando.Parameters.AddWithValue("FICHA", nuevoEmpleado.IdFichaMedica);
                    comando.Parameters.AddWithValue("DOMICILIO", nuevoEmpleado.Domicilio);
                    comando.Parameters.AddWithValue("TELEFONO", nuevoEmpleado.Telefono);
                    comando.Parameters.AddWithValue("DNI", nuevoEmpleado.DNI);
                    comando.Parameters.AddWithValue("EMAIL", nuevoEmpleado.Email);
                    comando.Parameters.AddWithValue("NACIMIENTO", nuevoEmpleado.FechaNacimiento);
                    comando.Parameters.AddWithValue("FOTO", nuevoEmpleado.Foto);
                    comando.Parameters.AddWithValue("PAIS", nuevoEmpleado.IdCiudad);
                    comando.Parameters.AddWithValue("ESTADO", nuevoEmpleado.IdTitulo);
                    comando.Parameters.AddWithValue("INSTAGRAM", nuevoEmpleado.Instagram);
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
            catch (Exception)
            {
                return null;
            }
            // ESTE METODO TIENEN QUE LLAMAR EN LA RESPECTIVA CLASE; NO PROGRAMEN ACA
        }
        #endregion
        
        #region registrarUsuario
        public bool registrarUsuario(clsUsuarios nuevoUsuario)
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
                    usuarioNoExiste = false;
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
                finally
                {
                    conexion.Close();
                }
            }
            else
            {
                MessageBox.Show("Ya existe un usuario con ese CUIT");
                return false;
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

        #region llenarCombos
        public void listarPaises(ComboBox cbPaises)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM Paises";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tablaPaises = new DataTable();
                adaptador.Fill(tablaPaises);
                cbPaises.ValueMember = "IdPais";
                cbPaises.DisplayMember = "Nombre";
                cbPaises.DataSource = tablaPaises;
                cbPaises.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void listarProvincias(ComboBox cbProvincias, int idPais)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Provincias WHERE IdPais = {idPais}";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tablaProvincias = new DataTable();
                adaptador.Fill(tablaProvincias);
                cbProvincias.ValueMember = "IdProvincia";
                cbProvincias.DisplayMember = "Nombre";
                cbProvincias.DataSource = tablaProvincias;
                cbProvincias.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void listarCiudades(ComboBox cbCiudades, int idProvincia)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Ciudades WHERE IdProvincia = {idProvincia}";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tablaCiudades = new DataTable();
                adaptador.Fill(tablaCiudades);
                cbCiudades.ValueMember = "IdCiudad";
                cbCiudades.DisplayMember = "Nombre";
                cbCiudades.DataSource = tablaCiudades;
                cbCiudades.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void listarAreas(ComboBox cbAreas)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Areas";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tablaAreas = new DataTable();
                adaptador.Fill(tablaAreas);
                cbAreas.ValueMember = "IdAreas";
                cbAreas.DisplayMember = "Nombre";
                cbAreas.DataSource = tablaAreas;
                cbAreas.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void listarEstados(ComboBox cbEstados)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Estados";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tablaEstados = new DataTable();
                adaptador.Fill(tablaEstados);
                cbEstados.ValueMember = "IdEstado";
                cbEstados.DisplayMember = "Nombre";
                cbEstados.DataSource = tablaEstados;
                cbEstados.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void listarEnfermedades(ComboBox cbEnfermedades)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM EnfermedadesPatologicas";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tablaEnfermedades = new DataTable();
                adaptador.Fill(tablaEnfermedades);
                cbEnfermedades.ValueMember = "IdEnfermedadesPatologicas";
                cbEnfermedades.DisplayMember = "Nombre";
                cbEnfermedades.DataSource = tablaEnfermedades;
                cbEnfermedades.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void listarMedicamentos(ComboBox cbMedicamentos)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = $"Medicamentos";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tablaMedicamentos = new DataTable();
                adaptador.Fill(tablaMedicamentos);
                cbMedicamentos.ValueMember = "IdMedicamentos";
                cbMedicamentos.DisplayMember = "Nombre";
                cbMedicamentos.DataSource = tablaMedicamentos;
                cbMedicamentos.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void listarDiscapacidades(ComboBox cbDiscapacidades)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Discapacidades";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tablaDiscapacidades = new DataTable();
                adaptador.Fill(tablaDiscapacidades);
                cbDiscapacidades.ValueMember = "IdDiscapacidades";
                cbDiscapacidades.DisplayMember = "Nombre";
                cbDiscapacidades.DataSource = tablaDiscapacidades;
                cbDiscapacidades.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void listarAlergias(ComboBox cbAlergias)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Alergias";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tablaAlergias = new DataTable();
                adaptador.Fill(tablaAlergias);
                cbAlergias.ValueMember = "IdAlergias";
                cbAlergias.DisplayMember = "Nombre";
                cbAlergias.DataSource = tablaAlergias;
                cbAlergias.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void listarSanciones(ComboBox cbSanciones)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Sanciones";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tablaSanciones = new DataTable();
                adaptador.Fill(tablaSanciones);
                cbSanciones.ValueMember = "IdSancion";
                cbSanciones.DisplayMember = "Nombre";
                cbSanciones.DataSource = tablaSanciones;
                cbSanciones.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void listarLicencias(ComboBox cbLicencias)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Licencias";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tablaLicencias = new DataTable();
                adaptador.Fill(tablaLicencias);
                cbLicencias.ValueMember = "IdLicencia";
                cbLicencias.DisplayMember = "Nombre";
                cbLicencias.DataSource = tablaLicencias;
                cbLicencias.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Sanciones
        public void listarSancionPorEmpleado(DataGridView dgvSanciones, long cuitEmpleado)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT S.Nombre, SE.Cuit, SE.Fecha, SE.FechaFin, SE.Observaciones FROM San_Emp as SE, Sanciones as S WHERE SE.Cuit={cuitEmpleado} AND S.IdSancion = SE.IdSancion";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dgvSanciones.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void agregarSancionAEmpleado(clsSanciones sancion, clsEmpleado empleado, string observaciones, DateTime fechaInicio)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;

                //int diasSancion = retornarDiasSancion(sancion);
                DateTime fechaFin = fechaInicio.AddDays(sancion.Tiempo);
                comando.CommandText = $@"INSERT INTO San_Emp(IdSancion, Cuit, Observaciones, Fecha, FechaFin) 
                                VALUES ({sancion.IdSancion},{empleado.Cuit}, '{observaciones}', '{fechaInicio}', '{fechaFin}')";

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
        #endregion

        #region Licencias
        public void listarLicenciaPorEmpleado(DataGridView dgvLicencias, long cuitEmpleado)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT L.Nombre, LE.Cuit, LE.Estado, LE.Tiempo FROM LIc-Emp as LE, Licencias as L WHERE LE.Cuit={cuitEmpleado} AND L.IdSancion = LE.IdSancion";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dgvLicencias.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void agregarLicenciaAEmpleado(clsLicencia licencia,clsEmpleado empleado ,clsEstado Estado, int Tiempo)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;

                //int diasSancion = retornarDiasSancion(sancion);
                //DateTime fechaFin = fechaInicio.AddDays(licencia.Tiempo);
                comando.CommandText = $@"INSERT INTO LIc-Emp(IdLicencia, Cuit, Estado, Tiempo) 
                                VALUES ({licencia.IdLicencia},{empleado.Cuit}, {Estado.IdEstado}, {Tiempo})";

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
        #endregion


    }
}
