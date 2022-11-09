using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class clsPersona
	{
		#region Atributos

		public String Nombre { get; set; }
		public String Apellidos { get; set; }
		public String NombreCompleto => $"{Nombre} {Apellidos}";
		public String Direccion { get; set; }
		public String Telefono { get; set; }

		#endregion


		#region Constructores

		public clsPersona()
		{
			this.Nombre = "";
			this.Apellidos= "";
			this.Direccion = "";
			this.Telefono = "";
		}


		public clsPersona(String _nombre, String _apellidos, String _direccion, string telefono)
		{
			this.Nombre = _nombre;
			this.Apellidos = _apellidos;
			this.Direccion = _direccion;
			this.Telefono=telefono;
		}
		#endregion
	}
}
