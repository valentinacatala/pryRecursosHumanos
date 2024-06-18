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
        #region verificarElemento
        private bool verificarElemento(string nombreTabla,string nombreElemento)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM {nombreTabla} WHERE Nombre = '{nombreElemento}'";

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
        }
        private bool verificarElemento(string nombreTabla, int id, string nombreId)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM {nombreTabla} WHERE {nombreId} = {id}";

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
        }
        #endregion

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
        public void listarEmpleados(DataGridView dgvGrilla,string sqlQuery)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = sqlQuery;

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
                    crearFichaMedica(nuevoEmpleado.Cuit);
                    int idFichaMedica = asignarFichaMedica(nuevoEmpleado.Cuit);
                    comando.CommandText = $@"INSERT INTO Empleados
                                            (Cuit, nombre, apellido, IdArea, IdFichaMedica, Domicilio, Telefono, DNI, CorreoElectronico, FechaDeNacimineto, Foto, IdCiudad, IdEstado, IdTitulo, IdTipoDeContacto, Instagram)
                                            VALUES (@CUIT, @NOMBRE, @APELLIDO, @AREA, @FICHA, @DOMICILIO, @TELEFONO, @DNI, @EMAIL, @NACIMIENTO, @FOTO, @CIUDAD, @ESTADO, @TITULO, @CONTACTO, @INSTAGRAM)";
                    comando.Parameters.AddWithValue("CUIT", nuevoEmpleado.Cuit);
                    comando.Parameters.AddWithValue("NOMBRE", nuevoEmpleado.Nombre);
                    comando.Parameters.AddWithValue("APELLIDO", nuevoEmpleado.Apellido);
                    comando.Parameters.AddWithValue("AREA", nuevoEmpleado.IdArea);
                    comando.Parameters.AddWithValue("FICHA", idFichaMedica);
                    comando.Parameters.AddWithValue("DOMICILIO", nuevoEmpleado.Domicilio);
                    comando.Parameters.AddWithValue("TELEFONO", nuevoEmpleado.Telefono);
                    comando.Parameters.AddWithValue("DNI", nuevoEmpleado.DNI);
                    comando.Parameters.AddWithValue("EMAIL", nuevoEmpleado.Email);
                    comando.Parameters.AddWithValue("NACIMIENTO", nuevoEmpleado.FechaNacimiento.ToShortDateString());
                    comando.Parameters.AddWithValue("FOTO", nuevoEmpleado.Foto);
                    comando.Parameters.AddWithValue("CIUDAD", nuevoEmpleado.IdCiudad);
                    comando.Parameters.AddWithValue("ESTADO", nuevoEmpleado.IdEstado);
                    comando.Parameters.AddWithValue("TITULO", nuevoEmpleado.IdTitulo);
                    comando.Parameters.AddWithValue("CONTACTO", 1);
                    comando.Parameters.AddWithValue("INSTAGRAM", nuevoEmpleado.Instagram);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    
                    MessageBox.Show("Empleado agregado exitosamente!");
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
                comando.CommandText = $"SELECT * FROM Empleados WHERE Cuit = {empleado.Cuit}";

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

        private void crearFichaMedica(int cuitEmpleado)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $@"INSERT INTO FichasMedicas (Cuit) VALUES ({cuitEmpleado})";
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

        public int asignarFichaMedica(int cuitEmpleado)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT IdFichaMedica FROM FichasMedicas WHERE Cuit = {cuitEmpleado}";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                if (tabla.Rows.Count == 0) return 0;
                else
                {
                    return Convert.ToInt32(tabla.Rows[0][0]);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
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
        public string nombreUsuario(long cuit)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT Nombre FROM Empleados WHERE Cuit = {cuit}";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tablaEmpleados = new DataTable();
                adaptador.Fill(tablaEmpleados);
                return tablaEmpleados.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
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

        public void listarUniversidades(ComboBox cbUniversidades)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Universidades";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tablaUniversidades = new DataTable();
                adaptador.Fill(tablaUniversidades);
                cbUniversidades.ValueMember = "IdUniversidad";
                cbUniversidades.DisplayMember = "Nombre";
                cbUniversidades.DataSource = tablaUniversidades;
                cbUniversidades.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void listarTitulos(ComboBox cbTitulos, int idUniversidad)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Titulos WHERE IdUniversidad = {idUniversidad}";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tablaTitulos = new DataTable();
                adaptador.Fill(tablaTitulos);
                cbTitulos.ValueMember = "IdTitulo";
                cbTitulos.DisplayMember = "Nombre";
                cbTitulos.DataSource = tablaTitulos;
                cbTitulos.SelectedIndex = -1;
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
                comando.CommandText = $"SELECT S.IdSancion, S.Nombre, SE.Cuit, SE.Fecha, SE.FechaFin, SE.Observaciones FROM San_Emp as SE, Sanciones as S WHERE SE.Cuit={cuitEmpleado} AND S.IdSancion = SE.IdSancion";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dgvSanciones.DataSource = tabla;
                dgvSanciones.Columns["IdSancion"].Visible = false;
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
                          VALUES ({sancion.IdSancion},{empleado.Cuit}, '{observaciones}', '{fechaInicio.ToShortDateString()}', '{fechaFin.ToShortDateString()}')";

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

        public void eliminarSancion(int cuit, int idSancion)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $@"DELETE FROM San_Emp WHERE IdSancion = {idSancion} AND Cuit = {cuit}";

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
                comando.CommandText = $"SELECT L.IdLicencia, L.Nombre, LE.Cuit, LE.Fecha, LE.FechaFin, LE.Observaciones FROM Lic_Emp as LE, Licencias as L WHERE LE.Cuit = {cuitEmpleado} AND L.IdLicencia = LE.IdLicencia";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dgvLicencias.DataSource = tabla;
                dgvLicencias.Columns["IdLicencia"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void agregarLicenciaAEmpleado(clsLicencia licencia,clsEmpleado empleado, DateTime fechaInicio, string observaciones )
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;

                DateTime fechaFin = fechaInicio.AddDays(licencia.Tiempo);
                comando.CommandText = $@"INSERT INTO Lic_Emp(IdLicencia, Cuit, Fecha, FechaFin, Observaciones) 
                                VALUES ({licencia.IdLicencia},{empleado.Cuit}, '{fechaInicio}', '{fechaFin}', '{observaciones}')";

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

        public void eliminarLicencia(int cuit, int idLicencia)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $@"DELETE FROM Lic_Emp WHERE IdLicencia = {idLicencia} AND Cuit = {cuit}";

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

        #region buscaEliminarEmpleado
        public bool eliminarEmpleado(int cuit)
        {
            bool existeEmpleado = buscarEmpleado(cuit);
            if (existeEmpleado)
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"UPDATE Empleados SET IdEstado = 4 WHERE Cuit = {cuit}";

                conexion.Open();
                comando.ExecuteNonQuery();
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool buscarEmpleado(int cuit)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Empleados WHERE Cuit = {cuit}";

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
        }
        public void llenarDatosEmpleado(int cuit,Label lblNombre, Label lblApellido, Label lblEmail, Label lblDomicilio, Label lblTelefono, Label lblFechaIngreso, PictureBox PbFoto)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Empleados WHERE Cuit = {cuit}";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tablaEmpleados = new DataTable();
                adaptador.Fill(tablaEmpleados);
                if (tablaEmpleados.Rows.Count == 1)
                {
                    lblApellido.Text = tablaEmpleados.Rows[0]["apellido"].ToString();
                    lblNombre.Text = tablaEmpleados.Rows[0]["nombre"].ToString();
                    lblEmail.Text = tablaEmpleados.Rows[0]["CorreoElectronico"].ToString();
                    lblDomicilio.Text = tablaEmpleados.Rows[0]["Domicilio"].ToString();
                    lblTelefono.Text = tablaEmpleados.Rows[0]["Telefono"].ToString();
                    PbFoto.ImageLocation = tablaEmpleados.Rows[0]["Foto"].ToString();
                    lblFechaIngreso.Text = Convert.ToDateTime(tablaEmpleados.Rows[0]["FechaDeNacimineto"]).ToString("dd/MM/yyyy");
                }
                else MessageBox.Show("El cuit ingresado no corresponde a ningun empleado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region modificarEmpleado
        public bool modificarEmpleado(int cuit, string nombre, string apellido, int dni, DateTime fechaNacimiento, string domicilio,string email,long telefono,string instagram,int idArea)
        {
            bool existeEmpleado = buscarEmpleado(cuit);
            if (existeEmpleado == true)
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $@"UPDATE Empleados SET nombre = '{nombre}', apellido = '{apellido}', DNI = {dni}, FechaDeNacimineto =                                                '{fechaNacimiento.ToShortDateString()}',Domicilio = '{domicilio}',
                                      CorreoElectronico = '{email}', Telefono = {telefono}, Instagram =    
                                      '{instagram}', IdArea = {idArea} 
                                      WHERE Cuit = {cuit}";

                conexion.Open();
                comando.ExecuteNonQuery();
                return true;
            }
            else return false;
        }
        public void llenarDatosEmpleado(int cuit,TextBox txtNombre, TextBox txtApellido, TextBox txtDni, TextBox txtEmail, TextBox txtDomicilio, TextBox txtTelefono, DateTimePicker dtpFechaDeNacimiento, TextBox txtInstagram)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Empleados WHERE Cuit = {cuit}";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tablaEmpleados = new DataTable();
                adaptador.Fill(tablaEmpleados);
                if (tablaEmpleados.Rows.Count == 1)
                {
                    txtApellido.Text = tablaEmpleados.Rows[0]["apellido"].ToString();
                    txtNombre.Text = tablaEmpleados.Rows[0]["nombre"].ToString();
                    txtEmail.Text = tablaEmpleados.Rows[0]["CorreoElectronico"].ToString();
                    txtDomicilio.Text = tablaEmpleados.Rows[0]["Domicilio"].ToString();
                    txtTelefono.Text = tablaEmpleados.Rows[0]["Telefono"].ToString();
                    txtDni.Text = tablaEmpleados.Rows[0]["DNI"].ToString(); ;
                    txtInstagram.Text = tablaEmpleados.Rows[0]["Instagram"].ToString(); ;
                    dtpFechaDeNacimiento.Value = Convert.ToDateTime(tablaEmpleados.Rows[0]["FechaDeNacimineto"].ToString()); 
                }
                else MessageBox.Show("El cuit ingresado no corresponde a ningun empleado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region paises
        public void agregarPais(string nuevoPais)
        {
            bool existe = verificarElemento("Paises",nuevoPais);
            if (existe == false)
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"INSERT INTO Paises (Nombre) VALUES ('{nuevoPais}')";

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Pais agregado correctamente");
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
            else MessageBox.Show("Pais existente");
        }
        public void eliminarPais(string paisAEliminar,int idPais)
        {
            bool existe = verificarElemento("Paises",idPais,"IdPais");
            if (existe == true)
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"DELETE FROM Paises WHERE IdPais = {idPais}";

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
            else MessageBox.Show("El pais no existe");
        }
        public void modificarPais(int IdPais, string paisNuevo)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"UPDATE Paises SET Nombre = '{paisNuevo}' WHERE IdPais = '{IdPais}'";

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
        public void listarPaises(DataGridView dgvGrilla, string nombrePais)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT Nombre FROM Paises";

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

        #region provincias
        private bool verificarProvincia(int idPais, string nombreProvincia)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Provincias WHERE Nombre = '{nombreProvincia}' AND IdPais = {idPais}";

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
        }
        public void agregarProvincia(int idPais, string nuevaProvincia)
        {
            if (verificarProvincia(idPais, nuevaProvincia) == false)
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"INSERT INTO Provincias (IdPais, Nombre) VALUES ({idPais}, '{nuevaProvincia}')";

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Provincia agregada");

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
            else MessageBox.Show("Provincia existente");
        }
        public void eliminarProvincia(int idProvincia)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"DELETE FROM Provincias WHERE IdProvincia = {idProvincia}";

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
        public void modificarProvincia(int idProvincia, string provinciaNueva)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"UPDATE Provincias SET Nombre = '{provinciaNueva}' WHERE IdProvincia = {idProvincia}";

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
        public void listarProvincias(DataGridView dgvGrilla,int idPais)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT PR.Nombre as Provincia, PA.Nombre as Pais FROM Provincias as PR, Paises as PA WHERE PR.IdPais = PA.IdPais AND PR.IdPais = {idPais}";

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
        public void listarProvincias(DataGridView dgvGrilla)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $@"SELECT PR.Nombre as Provincia, PA.Nombre as Pais 
                                        FROM Provincias as PR, Paises as PA 
                                        WHERE PR.IdPais = PA.IdPais";

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

        #region ciudad
        private bool verificarCiudad(int idProvincia, string nombreCiudad)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Ciudades WHERE Nombre = '{nombreCiudad}' AND IdProvincia = {idProvincia}";

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
        }
        public void agregarCiudad(int idProvincia, string nuevaCiudad)
        {
            if (verificarCiudad(idProvincia, nuevaCiudad) == false)
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"INSERT INTO Ciudades (IdProvincia, Nombre) VALUES ({idProvincia},'{nuevaCiudad}')";

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Ciudad agregada");
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
            else MessageBox.Show("Ciudad existente");
        }
        public void eliminarCiudad(int idCiudad)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"DELETE FROM Ciudades WHERE IdCiudad = {idCiudad}";

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
        public void modificarCiudad(int idCiudad, string ciudadNueva)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"UPDATE Ciudades SET Nombre = '{ciudadNueva}' WHERE IdCiudad = {idCiudad}";

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
        public void listarCiudades(DataGridView dgvGrilla,int idPais)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $@"SELECT C.Nombre as Ciudad, P.Nombre as Provincia, PA.Nombre as Pais 
                                    FROM Ciudades as C, Provincias as P, Paises as PA
                                    WHERE C.IdProvincia = P.IdProvincia AND P.IdPais = PA.IdPais AND P.IdPais = {idPais}";

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
        public void listarCiudades(DataGridView dgvGrilla)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $@"SELECT C.Nombre as Ciudad, P.Nombre as Provincia, PA.Nombre as Pais 
                                    FROM Ciudades as C, Provincias as P, Paises as PA
                                    WHERE C.IdProvincia = P.IdProvincia AND P.IdPais = PA.IdPais";

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

        #region area
        public void agregarArea(string nuevaArea, int sueldo)
        {
            bool existe = verificarElemento("Areas", nuevaArea);
            if (existe == false)
            {
                try
                {
                    int idSueldo = agregarSueldo(sueldo);
                    if (idSueldo != -1)
                    {
                        conexion = new OleDbConnection(cadena);
                        comando = new OleDbCommand();

                        comando.Connection = conexion;
                        comando.CommandType = CommandType.Text;
                        comando.CommandText = $"INSERT INTO Areas (Nombre, IdSueldo) VALUES ('{nuevaArea}', {idSueldo})";

                        conexion.Open();
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Area agregada");
                    }
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
            else MessageBox.Show("Area existente");
        }
        public void eliminarArea(int idArea)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"DELETE FROM Areas WHERE IdAreas = {idArea}";

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
        public void modificarArea(int idArea,int sueldo)
        {
            try
            {
                int idSueldo = agregarSueldo(sueldo);
                if (idSueldo != -1)
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"UPDATE Areas SET IdSueldo = {idSueldo} WHERE IdAreas = {idArea}";

                    conexion.Open();
                    comando.ExecuteNonQuery();   
                }
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
        public void listarAreas(DataGridView dgvGrilla, string nombreArea)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT A.Nombre, S.Cantidad FROM Areas as A, Sueldos as S WHERE A.IdSueldo = S.IdSueldo";

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

        #region estado
        public void agregarEstado(string nuevoEstado)
       {
            bool existe = verificarElemento("Estados", nuevoEstado);
            if (existe == false)
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"INSERT INTO Estados (Nombre) VALUES ('{nuevoEstado}')";

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
            else MessageBox.Show("Estado existente");
       }
        public void eliminarEstado(int idEstado,string nombreEstado)
        {
            bool existe = verificarElemento("Estados",idEstado,"IdEstado");
            if (existe == true)
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"DELETE FROM Estados WHERE IdEstado = {idEstado}";

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
            else MessageBox.Show("No existe el estado");
        }
        public void modificarEstado(int idEstado, string nuevoNombre)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"UPDATE Estados SET Nombre = '{nuevoNombre}' WHERE IdEstado = {idEstado}";

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
        public void listarEstado(DataGridView dgvGrilla, string nombreEstado)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT Nombre FROM Estados";

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

        #region enfermedad
        public void agregarEnfermedadPatologica(string nuevaEnfermedad)
        {
            bool existe = verificarElemento("EnfermedadesPatologicas", nuevaEnfermedad);
            if (existe == false)
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"INSERT INTO EnfermedadesPatologicas (Nombre) VALUES ('{nuevaEnfermedad}')";

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
            else MessageBox.Show("Enfermedad existente");
        }
        public void eliminarEnfermedadPatologica(int idEnfermedad,string nombreEnfermedad)
        {
            bool existe = verificarElemento("EnfermedadesPatologicas", idEnfermedad, "IdEnfermedadesPatologicas");
            if (existe == true)
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"DELETE FROM EnfermedadesPatologicas WHERE IdEnfermedadesPatologicas = {idEnfermedad}";

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
            else MessageBox.Show("La enfermedad no existe");
        }
        public void modificarEnfermedadPatologica(int idEnfermedad, string nuevoNombre)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"UPDATE EnfermedadesPatologicas SET Nombre = '{nuevoNombre}' WHERE IdEnfermedadesPatologicas = {idEnfermedad}";

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
        public void listarEnfermedadPatologica(DataGridView dgvGrilla, string nombreEnfermedad)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT Nombre FROM EnfermedadesPatologicas";

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

        #region medicamento
        public void agregarMedicamento(string nuevoMedicamento)
        {
            bool existe = verificarElemento("Medicamentos", nuevoMedicamento);
            if (existe == false)
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"INSERT INTO Medicamentos (Nombre) VALUES ('{nuevoMedicamento}')";

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
            else MessageBox.Show("Medicamento existe");
        }
        public void eliminarMedicamento(int idMedicamento,string nombreMedicamento)
        {
            bool existe = verificarElemento("Medicamentos", idMedicamento,"IdMedicamentos");
            if (existe == true)
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"DELETE FROM Medicamentos WHERE IdMedicamentos = {idMedicamento}";

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
            else MessageBox.Show("El medicamento no existe");
        }
        public void modificarMedicamento(int idMedicamento, string nuevoNombre)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"UPDATE Medicamentos SET Nombre = '{nuevoNombre}' WHERE IdMedicamentos = {idMedicamento}";

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
        public void listarMedicamento(DataGridView dgvGrilla, string nombreMedicamento)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT Nombre FROM Medicamentos";

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

        #region alergia
        public void agregarAlergia(string nuevaAlergia)
        {
            bool existe = verificarElemento("Alergias", nuevaAlergia);
            if(existe == false)
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"INSERT INTO Alergias (Nombre) VALUES ('{nuevaAlergia}')";

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
        }
        public void eliminarAlergia(int idAlergia,string nombreAlergia)
        {
            bool existe = verificarElemento("Alergias", idAlergia,"IdAlergias");
            if (existe == true)
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"DELETE FROM Alergias WHERE IdAlergias = {idAlergia}";

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
            else MessageBox.Show("No existe la alergia");
        }
        public void modificarAlergia(int idAlergia, string nuevoNombre)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"UPDATE Alergias SET Nombre = '{nuevoNombre}' WHERE IdAlergias = {idAlergia}";

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
        public void listarAlergia(DataGridView dgvGrilla, string nombreAlergia)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT Nombre FROM Alergias";

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

        #region discapacidad
        public void agregarDiscapacidad(string nuevaDiscapacidad)
        {
            bool existe = verificarElemento("Discapacidades", nuevaDiscapacidad);
            if (existe == false)
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"INSERT INTO Discapacidades (Nombre) VALUES ('{nuevaDiscapacidad}')";

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
            else MessageBox.Show("Discapacidad existente");
        }
        public void eliminarDiscapacidad(int idDiscapacidad, string nombreDiscapacidad)
        {
            bool existe = verificarElemento("Discapacidades", idDiscapacidad,"IdDiscapacidades");
            if (existe == true)
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"DELETE FROM Discapacidades WHERE IdDiscapacidades = {idDiscapacidad}";

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
            else MessageBox.Show("No existe la discapacidad");
        }
        public void modificarDiscapacidad(int idDiscapacidad, string nuevoNombre)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"UPDATE Discapacidades SET Nombre = '{nuevoNombre}' WHERE IdDiscapacidades = {idDiscapacidad}";

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
        public void listarDiscapacidad(DataGridView dgvGrilla, string nombreDiscapacidad)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT Nombre FROM Discapacidades";

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

        #region licencia
        public void agregarLicencia(string nombre, int tiempo)
        {
            if (verificarElemento("Licencias", nombre) == false)
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"INSERT INTO Licencias (Nombre, Tiempo) VALUES ('{nombre}', {tiempo})";

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
            else MessageBox.Show("Licencia existente");
        }
        public void eliminarLicencia(int idLicencia)
        {
            if (verificarElemento("Licencias", idLicencia,"IdLicencia") == true)
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"DELETE FROM Licencias WHERE IdLicencia = {idLicencia}";

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
            else MessageBox.Show("Licencia inexistente");

        }
        public void modificarLicencia(int idLicencia, int nuevoTiempo)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"UPDATE Licencias SET Tiempo = {nuevoTiempo} WHERE IdLicencia = {idLicencia}";

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
        public void listarLicencia(DataGridView dgvGrilla)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT Nombre,Tiempo FROM Licencias";
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

        #region faltas
        public void agregarFaltas(int cuit, string fecha)
        {
            if(validarFaltas(cuit, fecha))
        
        #region sancion
        public void agregarSancion(string nombre, int tiempo)
        {
            if (verificarElemento("Sanciones", nombre) == false)
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"INSERT INTO Presentismo (Cuit, Fecha) VALUES ({cuit}, '{fecha}')";

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Falta agregada");
                    comando.CommandText = $"INSERT INTO Sanciones (Nombre, Tiempo) VALUES ('{nombre}', {tiempo})";

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
                MessageBox.Show("No se pueden cargar 2 faltas en una misma fecha");
            }
        }

        public bool validarFaltas(int cuit, string fecha)
            else MessageBox.Show("Sancion existente");
        }
        public void eliminarSancion(int idSancion)
        {
            if (verificarElemento("Sanciones", idSancion, "IdSancion") == true)
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"DELETE FROM Sanciones WHERE IdSancion = {idSancion}";

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
            else MessageBox.Show("Sancion inexistente");

        }
        public void modificarSancion(int idSancion, int nuevoTiempo)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Presentismo WHERE Cuit = {cuit} AND Fecha = '{fecha}'";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                if (tabla.Rows.Count == 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void listarFaltas(DataGridView dgvFaltas, int cuit)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Presentismo WHERE Cuit = {cuit}";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dgvFaltas.DataSource = tabla;
                dgvFaltas.Columns["Id"].Visible = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void eliminarFaltas(int id)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"DELETE FROM Presentismo WHERE Id = {id}";
                comando.CommandText = $"UPDATE Sanciones SET Tiempo = {nuevoTiempo} WHERE IdSancion = {idSancion}";

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

        #region FichaMedica
        public void agregarEnfermedadAFicha(int idFichaMedica, int idEnfermedad)
        {
            if(validarEnfermedad(idFichaMedica, idEnfermedad))
            {
                try
        public void listarSancion(DataGridView dgvGrilla)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT Nombre,Tiempo FROM Sanciones";
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
        
        #region sueldo
        private int agregarSueldo(int sueldo)
        {
            try
            {
                int idSueldo = buscarSueldo(sueldo);
                if (idSueldo == -1)
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"INSERT INTO Enf_FM (IdFichaMedica, IdEnfermedad) VALUES ({idFichaMedica}, {idEnfermedad})";

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
                MessageBox.Show("No se puede cargar 2 veces la misma enfermedad");
            }
            
        }

        public void listarEnfermedadesPorFicha(DataGridView dgvEnfermedades, int idFichaMedica)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT E.IdEnfermedadesPatologicas as IdEnfermedad, E.Nombre, E.Contagiosa FROM Enf_FM as EF, EnfermedadesPatologicas as E WHERE EF.IdFichaMedica = {idFichaMedica} AND E.IdEnfermedadesPatologicas = EF.IdEnfermedad";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                dgvEnfermedades.DataSource = tabla;
                dgvEnfermedades.Columns["IdEnfermedad"].Visible = false;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool validarEnfermedad(int idFichaMedica, int idEnfermedad)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Enf_FM WHERE IdFichaMedica = {idFichaMedica} AND IdEnfermedad = {idEnfermedad}";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                if (tabla.Rows.Count == 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void eliminarEnfermedad(int idFichaMedica, int idEnfermedad)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"DELETE FROM Enf_FM WHERE IdFichaMedica = {idFichaMedica} AND IdEnfermedad = {idEnfermedad}";

                conexion.Open();
                comando.ExecuteNonQuery();
                    comando.CommandText = $"INSERT INTO Sueldos (Cantidad) VALUES ({sueldo})";

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    return buscarSueldo(sueldo);
                }
                else return idSueldo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void agregarMedicamentoAFicha(int idFichaMedica, int idMedicamento, double dosis)
        {
            if (validarMedicamento(idFichaMedica, idMedicamento))
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"INSERT INTO Med_FM (IdFichaMedica, IdMedicamento, Dosis) VALUES ({idFichaMedica}, {idMedicamento}, {dosis})";

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
                MessageBox.Show("No se puede cargar 2 veces el mismo medicamento");
            }

        }

        public void listarMedicamentosPorFicha(DataGridView dgvMedicamentos, int idFichaMedica)
        private int buscarSueldo(int sueldo)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT M.IdMedicamentos, M.Nombre, MF.Dosis FROM Med_FM as MF, Medicamentos as M WHERE MF.IdFichaMedica = {idFichaMedica} AND M.IdMedicamentos = MF.IdMedicamento";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                dgvMedicamentos.DataSource = tabla;
                dgvMedicamentos.Columns["IdMedicamentos"].Visible = false;

                comando.CommandText = $"SELECT * FROM Sueldos WHERE Cantidad = {sueldo}";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tablaEmpleados = new DataTable();
                adaptador.Fill(tablaEmpleados);
                if (tablaEmpleados.Rows.Count == 1) return Convert.ToInt32(tablaEmpleados.Rows[0][0]);
                else return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool validarMedicamento(int idFichaMedica, int idMedicamento)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Med_FM WHERE IdFichaMedica = {idFichaMedica} AND IdMedicamento = {idMedicamento}";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                if (tabla.Rows.Count == 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void eliminarMedicamento(int idFichaMedica, int idMedicamento)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"DELETE FROM Med_FM WHERE IdFichaMedica = {idFichaMedica} AND IdMedicamento = {idMedicamento}";

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

        public void agregarDiscapacidadAFicha(int idFichaMedica, int idDiscapacidad)
        {
            if (validarDiscapacidad(idFichaMedica, idDiscapacidad))
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"INSERT INTO Disc_FM (IdFichaMedica, IdDiscapacidad) VALUES ({idFichaMedica}, {idDiscapacidad})";

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
                MessageBox.Show("No se puede cargar 2 veces la misma discapacidad");
            }

        }

        public void listarDiscapacidadesPorFicha(DataGridView dgvDiscapacidades, int idFichaMedica)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT D.IdDiscapacidades, D.Nombre FROM Disc_FM as DF, Discapacidades as D WHERE DF.IdFichaMedica = {idFichaMedica} AND D.IdDiscapacidades = DF.IdDiscapacidad";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                dgvDiscapacidades.DataSource = tabla;
                dgvDiscapacidades.Columns["IdDiscapacidades"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool validarDiscapacidad(int idFichaMedica, int idDiscapacidad)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Disc_FM WHERE IdFichaMedica = {idFichaMedica} AND IdDiscapacidad = {idDiscapacidad}";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                if (tabla.Rows.Count == 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public void eliminarDiscapacidad(int idFichaMedica, int idDiscapacidad)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"DELETE FROM Disc_FM WHERE IdFichaMedica = {idFichaMedica} AND IdDiscapacidad = {idDiscapacidad}";

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

        public void agregarAlergiaAFicha(int idFichaMedica, int idAlergia)
        {
            if (validarAlergia(idFichaMedica, idAlergia))
            {
                try
                {
                    conexion = new OleDbConnection(cadena);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = $"INSERT INTO Ale_FM (IdFichaMedica, IdAlergia) VALUES ({idFichaMedica}, {idAlergia})";

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
                MessageBox.Show("No se puede cargar 2 veces la misma alergia");
            }

        }

        public void listarAlergiasPorFicha(DataGridView dgvAlergias, int idFichaMedica)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT A.IdAlergias, A.Nombre FROM Ale_FM as AF, Alergias as A WHERE AF.IdFichaMedica = {idFichaMedica} AND A.IdAlergias = AF.IdAlergia";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                dgvAlergias.DataSource = tabla;
                dgvAlergias.Columns["IdAlergias"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool validarAlergia(int idFichaMedica, int idAlergia)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Ale_FM WHERE IdFichaMedica = {idFichaMedica} AND IdAlergia = {idAlergia}";

                adaptador = new OleDbDataAdapter(comando);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                if (tabla.Rows.Count == 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public void eliminarAlergia(int idFichaMedica, int idAlergia)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"DELETE FROM Ale_FM WHERE IdFichaMedica = {idFichaMedica} AND IdAlergia = {idAlergia}";

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
                return -1;
            }
        } 
        #endregion
}

