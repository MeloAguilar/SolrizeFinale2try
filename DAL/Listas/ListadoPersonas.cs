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

			lista.Add(new clsPersona("Paco", "Albiñana", "Calle de aki", "667779979"));
			lista.Add(new clsPersona("Carmelo", "Aguilar", "Calle de allá", "667779979"));
			lista.Add(new clsPersona("Pedro", "Cornejo", "Calle esta", "667779979"));
			lista.Add(new clsPersona("Jesús", "García", "To lejos", "667779979"));

			lista.Add(new clsPersona("Paco", "Albiñana", "Calle de aki", "667779979"));
			lista.Add(new clsPersona("Carmelo", "Aguilar", "Calle de allá", "667779979"));
			lista.Add(new clsPersona("Pedro", "Cornejo", "Calle esta", "667779979"));
			lista.Add(new clsPersona("Jesús", "García", "To lejos", "667779979"));

			lista.Add(new clsPersona("Paco", "Albiñana", "Calle de aki", "667779979"));
			lista.Add(new clsPersona("Carmelo", "Aguilar", "Calle de allá", "667779979"));
			lista.Add(new clsPersona("Pedro", "Cornejo", "Calle esta", "667779979"));
			lista.Add(new clsPersona("Jesús", "García", "To lejos", "667779979"));


			return lista;
		}
	}
}
