using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Listas
{
	public class ListadoPersonas
	{

		public List<clsPersona> getListadoCompletoPersonas()
		{
			List<clsPersona> lista = new List<clsPersona>();

			lista.Add(new clsPersona("Paco", "Albiñana", "1600 Amphitheatre Parkway Mountain View, California, Estados Unidos", "667779979"));
			lista.Add(new clsPersona("Carmelo", "Aguilar", "1600 Amphitheatre Parkway Mountain View, California, Estados Unidos", "667779979"));
			lista.Add(new clsPersona("Pedro", "Cornejo", "1600 Amphitheatre Parkway Mountain View, California, Estados Unidos", "667779979"));
			lista.Add(new clsPersona("Jesús", "García", "1600 Amphitheatre Parkway Mountain View, California, Estados Unidos", "667779979"));

			return lista;
		}
	}
}
