﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryRecursosHumanos
{
    public class clsSanciones
    {
		private int idSancion;
		private string nombre;
		private string tiempo;

		public int IdSancion
		{
			get { return idSancion; }
			set { idSancion = value; }
		}
		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}
		public string Tiempo
		{
			get { return tiempo; }
			set { tiempo = value; }
		}

	}
}