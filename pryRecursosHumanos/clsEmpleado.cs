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
		private clsLicencia licencia;
		private List<clsSanciones> sanciones;
		private clsArea area;
		private clsFichaMedica fichaMedica;
		private clsUsuarios usuario;
		private string nombre;
		private string apellido;
		private string domicilio;
		private int telefono;
		private int dni;
		private string email;
		private DateTime fechaNacimiento;
		private string foto;
		private clsCiudades ciudad;
		private List<clsMedioContactos> mediosContacto;
		private clsEstado estado;
		private clsTitulo titulo;
		private string instagram;
		private List<clsTipoContactos> tiposContacto;

		public int Cuit
		{
			get { return cuit; }
			set { cuit = value; }
		}
		public clsLicencia Licencia
		{
			get { return licencia; }
			set { licencia = value; }
		}
		public List<clsSanciones> Sanciones
        {
			get { return sanciones; }
			set { sanciones = value; }
		}
		public clsArea Area
        {
			get { return area; }
			set { area = value; }
		}
		public clsFichaMedica FichaMedica
		{
			get { return fichaMedica; }
			set { fichaMedica = value; }
		}
		public clsUsuarios Usuarios
		{
			get { return usuario; }
			set { usuario = value; }
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
		public clsCiudades Ciudad
		{
			get { return ciudad; }
			set { ciudad = value; }
		}
		public List<clsMedioContactos> MediosContacto
        {
			get { return mediosContacto; }
			set { mediosContacto = value; }
		}
		public clsEstado Estado
        {
			get { return estado; }
			set { estado = value; }
		}
		public clsTitulo Titulo
		{
			get { return titulo; }
			set { titulo = value; }
		}
		public string Instagram
        {
			get { return instagram; }
			set { instagram = value; }
		}
		public List<clsTipoContactos> TiposContacto
        {
			get { return tiposContacto; }
			set { tiposContacto = value; }
		}

		public void listarEmpleados(DataGridView dgvGrilla)
        {
            string comando;
			comando = "select empleados.cuit, empleados.nombre as Nombre, empleados.apellido, empleados.domicilio" +
				", areas.nombre as Areas, Paises.nombre as Pais from empleados, areas, paises";
			clsConexionBaseDatos BD = new clsConexionBaseDatos();
			BD.listarEmpleados(dgvGrilla,comando);
		}
        public void listarEmpleadosEstado(DataGridView dgvGrilla)
        {
            string comando;
            comando = "select * from empleados order by IdEstado";
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarEmpleados(dgvGrilla, comando);
        }
        public void listarEmpleadosApellido(DataGridView dgvGrilla)
        {
            string comando;
            comando = "select * from empleados order by Apellido ";
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarEmpleados(dgvGrilla, comando);
        }
        public void listarEmpleadosPais(DataGridView dgvGrilla)
        {
            string comando;
            comando = "select * from empleados order by IdPais";
            clsConexionBaseDatos BD = new clsConexionBaseDatos();
            BD.listarEmpleados(dgvGrilla, comando);
        }

        public void agregarEmpleado(clsEmpleado nuevoEmpleado)
		{
            clsConexionBaseDatos BD = new clsConexionBaseDatos();

            BD.agregarEmpleado(nuevoEmpleado);
        }
	}
}
