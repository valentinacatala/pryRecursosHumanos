﻿using System;
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
		private string telefono;
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
		public string Telefono
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
  //      public void listarEmpleados(DataGridView dgvGrilla)
		//{
		//	clsConexionBaseDatos BD = new clsConexionBaseDatos();
		//	BD.listarEmpleados(dgvGrilla);
		//}

		public void agregarEmpleado(clsEmpleado nuevoEmpleado)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();

            BD.agregarEmpleado(nuevoEmpleado);
        }

		public static bool validarEmpleado(clsEmpleado empleado)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
			return !BD.validarEmpleado(empleado); // Retorno la negacion porque en clsConexion retorna true en caso de que no exista.
        }
        #endregion

        #region sancionLicencia
        public static void agregarSancion(clsSanciones sancion, clsEmpleado empleado, string observaciones, DateTime fechaInicio)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.agregarSancionAEmpleado(sancion, empleado, observaciones, fechaInicio);
        }

		public static void eliminarSancion(int cuit, int idSancion)
		{
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.eliminarSancion(cuit, idSancion);
		}

		public static void agregarLicencia(clsLicencia licencia, clsEmpleado empleado, DateTime fechaInicio, string observaciones)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();

            BD.agregarLicenciaAEmpleado(licencia,empleado, fechaInicio, observaciones);
        }

        public static void eliminarLicencia(int cuit, int idLicencia)
        {
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.eliminarLicencia(cuit, idLicencia);
        }
        #endregion

        #region buscarEliminarEmpleado
		public static void buscarEmpleado(int cuit, Label lblNombre, Label lblApellido, Label lblEmail, Label lblDomicilio, Label lblTelefono, Label lblFechaIngreso, PictureBox PbFoto)
		{
			clsConexionBaseDatos conexion = new clsConexionBaseDatos();
			conexion.llenarDatosEmpleado(cuit,lblNombre,lblApellido,lblEmail,lblDomicilio,lblTelefono,lblFechaIngreso,PbFoto);
		}
        public static void buscarEmpleado(int cuit,TextBox txtNombre, TextBox txtApellido, TextBox txtDni, TextBox txtEmail, TextBox txtDomicilio, TextBox txtTelefono,  DateTimePicker dtpFechaDeNacimiento, TextBox txtInstagram)
        {
            clsConexionBaseDatos conexion = new clsConexionBaseDatos();
            conexion.llenarDatosEmpleado(cuit,txtNombre,txtApellido,txtDni,txtEmail,txtDomicilio,txtTelefono,dtpFechaDeNacimiento,txtInstagram);
        }
        public bool eliminarEmpleado(int cuit)
		{
            clsConexionBaseDatos conexion = new clsConexionBaseDatos();
			return conexion.eliminarEmpleado(cuit);
        }
		public static void modificarEmpleado(int cuit, string nombre, string apellido, int dni, DateTime fechaNacimiento, string domicilio, string email, long telefono, string instagram, int idArea)
		{
            clsConexionBaseDatos conexion = new clsConexionBaseDatos();
			conexion.modificarEmpleado(cuit,nombre,apellido,dni,fechaNacimiento,domicilio,email,telefono,instagram,idArea);
        }

        #endregion

		public void asignarFichaMedica()
		{
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			this.IdFichaMedica = BD.asignarFichaMedica(this.cuit);
		}

		public static int buscarFichaMedica(int cuitEmpleado)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            return BD.asignarFichaMedica(cuitEmpleado);
        }

        #region listarEmpleados
        public static void listarEmpleados(DataGridView dgvGrilla)
        {
            string comando;
            comando = @"select empleados.Cuit,
                empleados.Nombre,
                empleados.Apellido,
                areas.nombre as Areas,
                empleados.Domicilio,
                empleados.Telefono,
                empleados.DNI,
                empleados.CorreoElectronico,
                empleados.FechaDeNacimineto,
                ciudades.nombre as Ciudad,
                estados.nombre as Estado,
                titulos.nombre as Titulo,
                tipodecontactos.nombre as Contacto,
                empleados.Instagram 
                from empleados, areas, ciudades, estados, titulos, tipodecontactos
				WHERE empleados.IdArea = areas.IdAreas AND empleados.IdCiudad = ciudades.IdCiudad AND empleados.IdEstado = estados.IdEstado
				AND empleados.IdTitulo = titulos.IdTitulo AND empleados.IdTipoDeContacto = tipodecontactos.IdTipoDeContacto";
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarEmpleados(dgvGrilla, comando);
        }
        public static void listarEmpleadosEstado(DataGridView dgvGrilla)
        {
            string comando;
            comando = "select empleados.Cuit," +
                "empleados.Nombre," +
                "empleados.Apellido," +
                "areas.nombre as Areas," +
                "empleados.Domicilio," +
                "empleados.Telefono," +
                "empleados.DNI," +
                "empleados.CorreoElectronico," +
                "empleados.FechaDeNacimineto," +
                "Paises.nombre as Pais," +
                "estados.nombre as Estado," +
                "titulos.nombre as Titulo," +
                "tipodecontactos.nombre as Contacto," +
                "empleados.Instagram " +
                "from empleados, areas, paises, estados, titulos, tipodecontactos order by estados.nombre";
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarEmpleados(dgvGrilla, comando);
        }
        public static void listarEmpleadosApellido(DataGridView dgvGrilla)
        {
            string comando;
            comando = "select empleados.Cuit," +
                "empleados.Nombre," +
                "empleados.Apellido," +
                "areas.nombre as Areas," +
                "empleados.Domicilio," +
                "empleados.Telefono," +
                "empleados.DNI," +
                "empleados.CorreoElectronico," +
                "empleados.FechaDeNacimineto," +
                "Paises.nombre as Pais," +
                "estados.nombre as Estado," +
                "titulos.nombre as Titulo," +
                "tipodecontactos.nombre as Contacto," +
                "empleados.Instagram " +
                "from empleados, areas, paises, estados, titulos, tipodecontactos order by empleados.apellido";
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarEmpleados(dgvGrilla, comando);
        }
        public static void listarEmpleadosPais(DataGridView dgvGrilla)
        {
            string comando;
            comando = "select empleados.Cuit," +
                "empleados.Nombre," +
                "empleados.Apellido," +
                "areas.nombre as Areas," +
                "empleados.Domicilio," +
                "empleados.Telefono," +
                "empleados.DNI," +
                "empleados.CorreoElectronico," +
                "empleados.FechaDeNacimineto," +
                "Paises.nombre as Pais," +
                "estados.nombre as Estado," +
                "titulos.nombre as Titulo," +
                "tipodecontactos.nombre as Contacto," +
                "empleados.Instagram " +
                "from empleados, areas, paises, estados, titulos, tipodecontactos order by paises.nombre";
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarEmpleados(dgvGrilla, comando);
        }
        #endregion
    }
}
