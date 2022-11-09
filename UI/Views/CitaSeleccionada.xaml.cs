using UI.ViewModels;

namespace UI.Views;

public partial class CitaSeleccionada : TabbedPage
{
	public CitaSeleccionada(CitaViewModel vm)
	{
		InitializeComponent();


		//Recojo la p�gina Tabbed
		var tab = this as TabbedPage;


		//Instancio las p�ginas
		var pagDetalles = new NavigationPage(new DetallesCita(vm));
		var pagGaleria = new NavigationPage(new Galeria(vm));
		var pagNotas = new NavigationPage(new Notas(vm));

		//Las a�ado a la tabbedPage como hijos
		tab.Children.Add(new NavigationPage(pagDetalles));
		tab.Children.Add(new NavigationPage(pagNotas));
		tab.Children.Add(new NavigationPage(pagGaleria));
		
		//Establezco el icono y el titulo
		tab.Children.ElementAt(0).IconImageSource = "details_icon.png";
		tab.Children.ElementAt(1).IconImageSource = "notes_icon.png";
		tab.Children.ElementAt(2).IconImageSource = "gal_icon.png";
		tab.Children.ElementAt(0).Title = "Detalles";
		tab.Children.ElementAt(1).Title = "Notas";
		tab.Children.ElementAt(2).Title = "Galeria";

	}


}