using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryRecursosHumanos
{
    public class clsEmpleado
    {
		private int cuit;
		private int idLicencia;
		private List<int> sanciones;
		private int idArea;
		private int idFichaMedica;
		private int idUsuario;
		private string nombre;
		private string apellido;
		private string domicilio;
		private int telefono;
		private int dni;
		private string email;
		private DateTime fechaNacimiento;
		private string foto;
		private int idPais;
		private int idProvincia;
		private int idCiudad;
		private List<int> mediosContacto;
		private int idEstado;
		private int idTitulo;
		private string instagram;
		private List<int> tiposContacto;
		private int idMedicamento;
		private int idEnfermedad;
		private int idAlergia;
		private int idDiscapacidad;

        #region propiedades
        public int Cuit
		{
			get { return cuit; }
			set { cuit = value; }
		}
		public int IdLicencia
		{
			get { return idLicencia; }
			set { idLicencia = value; }
		}
		public List<int> Sanciones
        {
			get { return sanciones; }
			set { sanciones = value; }
		}
		public int IdArea
        {
			get { return idArea; }
			set { idArea = value; }
		}
		public int IdFichaMedica
		{
			get { return idFichaMedica; }
			set { idFichaMedica = value; }
		}
		public int IdUsuarios
		{
			get { return idUsuario; }
			set { idUsuario = value; }
		}
		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}
		public string Email
		{
			get { return email; }
			set { email = value; }
		}
		public string Domicilio
        {
			get { return domicilio; }
			set { domicilio = value; }
		}
		public int Telefono
        {
			get { return telefono; }
			set { telefono = value; }
		}
		public int DNI
		{
			get { return dni; }
			set { dni = value; }
		}
		public string Apellido
		{
			get { return apellido; }
			set { apellido = value; }
		}
		public DateTime FechaNacimiento
        {
			get { return fechaNacimiento; }
			set { fechaNacimiento = value; }
		}
		public string Foto
        {
			get { return foto; }
			set { foto = value; }
		}
		public int IdPais
		{
			get { return idPais; }
			set { idPais = value; }
		}
		public int IdProvincia
		{
			get { return idProvincia; }
			set { idProvincia = value; }
		}
		public int IdCiudad
		{
			get { return idCiudad; }
			set { idCiudad = value; }
		}
		public List<int> MediosContacto
        {
			get { return mediosContacto; }
			set { mediosContacto = value; }
		}
		public int IdEstado
        {
			get { return idEstado; }
			set { idEstado = value; }
		}
		public int IdTitulo
		{
			get { return idTitulo; }
			set { idTitulo = value; }
		}
		public string Instagram
        {
			get { return instagram; }
			set { instagram = value; }
		}
		public List<int> TiposContacto
        {
			get { return tiposContacto; }
			set { tiposContacto = value; }
		}
		public int IdMedicamento
		{
			get { return idMedicamento; }
			set { idMedicamento = value; }
		}
		public int IdEnfermedad
		{
			get { return idEnfermedad; }
			set { idEnfermedad = value; }
		}
		public int IdAlergia
		{
			get { return idAlergia; }
			set { idAlergia = value; }
		}
		public int IdDiscapacidad
		{
			get { return idDiscapacidad; }
			set { idDiscapacidad = value; }
		}
        #endregion

        #region listarAgregarEmpleado
        public void listarEmpleados(DataGridView dgvGrilla)
		{
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.listarEmpleados(dgvGrilla);
		}

		public void agregarEmpleado(clsEmpleado nuevoEmpleado)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();

            BD.agregarEmpleado(nuevoEmpleado);
        }
        #endregion

        #region sancionLicencia
        public static void agregarSancion(clsSanciones sancion, clsEmpleado empleado, string observaciones, DateTime fechaInicio)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();

			BD.agregarSancionAEmpleado(sancion, empleado, observaciones, fechaInicio);
        }

		public static void agregarLicencia(clsLicencia licencia, clsEmpleado empleado, clsEstado Estado, int Tiempo)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();

            BD.agregarLicenciaAEmpleado(licencia,empleado,Estado,Tiempo);
        }
        #endregion

        #region buscarEliminarEmpleado
		public void buscarEmpleado(int cuit, Label lblNombre, Label lblApellido, Label lblEmail, Label lblDomicilio, Label lblTelefono, Label lblFechaIngreso, PictureBox PbFoto)
		{
			clsConexionBaseDatos conexion = new clsConexionBaseDatos();
			conexion.llenarDatosEmpleado(cuit,lblNombre,lblApellido,lblEmail,lblDomicilio,lblTelefono,lblFechaIngreso,PbFoto);
		}
		public bool eliminarEmpleado(int cuit)
		{
            clsConexionBaseDatos conexion = new clsConexionBaseDatos();
			return conexion.eliminarEmpleado(cuit);
        }

        #endregion

    }
}
