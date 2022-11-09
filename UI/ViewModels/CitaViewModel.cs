using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UI.ViewModels
{
	public class CitaViewModel
	{
		public ICommand usarMapa { get; set; }
		private DateTime fechaHoraCita;

		public DateTime FechaHoraCita { get; set; }
		public string NombreVM
		{
			get { return Cliente.Nombre; }
			set
			{

				Cliente.Nombre = value;
			}
		}

		public string ApellidosVM
		{
			get { return Cliente.Apellidos; }
			set
			{

				Cliente.Apellidos = value;
			}
		}

		public string DireccionVM
		{
			get { return Cliente.Direccion; }
			set
			{
				Cliente.Direccion = value;
			}
		}

		public string TelefonoVM
		{
			get { return Cliente.Telefono; }
			set
			{
				Cliente.Telefono = value;
			}
		}

		public string NombreCompletoVM => $"{Cliente.Nombre} {Cliente.Apellidos}";
		public clsPersona Cliente { get; set; }
		public List<string> Observaciones { get; set; }
		public bool Apto { get; set; }
		public List<string> Imagenes { get; set; }

		public CitaViewModel(clsPersona _cliente, DateTime _fechaHora)
		{
			this.Cliente = _cliente;
			this.TelefonoVM = _cliente.Telefono;
			this.ApellidosVM = _cliente.Apellidos;
			this.NombreVM = _cliente.Nombre;
			this.Observaciones = new List<string>();
			this.Imagenes = new List<string>();
			this.Apto = false;
			this.FechaHoraCita = _fechaHora;
			usarMapa = new Command(() => Map.Default.OpenAsync(new Location(37.45513718547035, -122.11575688327474), new MapLaunchOptions { NavigationMode = NavigationMode.Driving }));
		}

		public CitaViewModel()
		{
			this.Cliente = new clsPersona();
			this.Observaciones = new List<string>();
			this.Imagenes = new List<string>();
			this.Apto = false;
			this.FechaHoraCita = (DateTime.Now.AddHours(new Random(4).NextDouble()));
		}

	}

}
