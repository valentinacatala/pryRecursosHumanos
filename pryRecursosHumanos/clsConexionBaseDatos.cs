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
                                            (Cuit, nombre, apellido, IdArea, IdFichaMedica, Domicilio, Telefono, DNI, CorreoElectronico, FechaDeNacimineto, Foto, IdCiudad, IdEstado, IdTitulo, IdTipoDeContacto, Instagram)
                                            VALUES (@CUIT, @NOMBRE, @APELLIDO, @AREA, @FICHA, @DOMICILIO, @TELEFONO, @DNI, @EMAIL, @NACIMIENTO, @FOTO, @CIUDAD, @ESTADO, @TITULO, @CONTACTO, @INSTAGRAM)";
                    comando.Parameters.AddWithValue("CUIT", nuevoEmpleado.Cuit);
                    comando.Parameters.AddWithValue("NOMBRE", nuevoEmpleado.Nombre);
                    comando.Parameters.AddWithValue("APELLIDO", nuevoEmpleado.Apellido);
                    comando.Parameters.AddWithValue("AREA", nuevoEmpleado.IdArea);
                    comando.Parameters.AddWithValue("FICHA", 1);
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
                comando.CommandText = $"SELECT L.Nombre, LE.Cuit, LE.Estado, LE.Tiempo FROM Lic_Emp as LE, Licencias as L WHERE LE.Cuit = {cuitEmpleado} AND L.IdLicencia = LE.IdLicencia";

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
                comando.CommandText = $@"INSERT INTO Lic_Emp(IdLicencia, Cuit, Estado, Tiempo) 
                                VALUES ({licencia.IdLicencia},{empleado.Cuit}, {Estado.IdEstado}, {licencia.Tiempo})";

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
        public bool modificarEmpleado(int cuit)
        {
            return true;
        }
        #endregion

        #region paises
        public void agregarPais(string nuevoPais)
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
        public void eliminarPais(string paisAEliminar)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"DELETE FROM Paises WHERE Nombre = '{paisAEliminar}'";

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
                comando.CommandText = $"SELECT * FROM Paises WHERE Nombre = '{nombrePais}'";

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
        public void agregarProvincia(int idPais, string nuevaProvincia)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"INSERT INTO Provincias (IdPais, IdProvincia, Nombre) VALUES ({idPais}, (SELECT MAX(IdProvincia) + 1 FROM Provincias), '{nuevaProvincia}')";

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
        #endregion

        #region ciudad
        public void agregarCiudad(int idProvincia, string nuevaCiudad)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"INSERT INTO Ciudades (IdProvincia, IdCiudad, Nombre) VALUES ({idProvincia}, (SELECT MAX(IdCiudad) + 1 FROM Ciudades), '{nuevaCiudad}')";

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
        #endregion

        #region area
        public void agregarArea(string nuevaArea, int idSueldo)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"INSERT INTO Areas (Nombre, IdSueldo) VALUES ('{nuevaArea}', {idSueldo})";

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
        public void modificarArea(int idArea, string nuevaArea, int idSueldo)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"UPDATE Areas SET Nombre = '{nuevaArea}', IdSueldo = {idSueldo} WHERE IdAreas = {idArea}";

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

        #region estado
       public void agregarEstado(string nuevoEstado)
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
        public void eliminarEstado(int idEstado)
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
                comando.CommandText = $"SELECT * FROM Estados WHERE Nombre = '{nombreEstado}'";

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
        public void eliminarEnfermedadPatologica(int idEnfermedad)
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
                comando.CommandText = $"SELECT * FROM EnfermedadesPatologicas WHERE Nombre = '{nombreEnfermedad}'";

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
        public void eliminarMedicamento(int idMedicamento)
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
                comando.CommandText = $"SELECT * FROM Medicamentos WHERE Nombre = '{nombreMedicamento}'";

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
        public void eliminarAlergia(int idAlergia)
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
                comando.CommandText = $"SELECT * FROM Alergias WHERE Nombre = '{nombreAlergia}'";

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
        public void eliminarDiscapacidad(int idDiscapacidad)
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
                comando.CommandText = $"SELECT * FROM Discapacidades WHERE Nombre = '{nombreDiscapacidad}'";

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
        public void eliminarLicencia(int idLicencia)
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
        public void modificarLicencia(int idLicencia, string nuevoNombre, int nuevoTiempo)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"UPDATE Licencias SET Nombre = '{nuevoNombre}', Tiempo = {nuevoTiempo} WHERE IdLicencia = {idLicencia}";

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
        public void listarLicencia(DataGridView dgvGrilla, string nombreEnfermedad)
        {
            try
            {
                conexion = new OleDbConnection(cadena);
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = $"SELECT * FROM Licencias WHERE Nombre = '{nombreEnfermedad}'";

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
    }
}
