using UI.ViewModels;

namespace UI.Views;

public partial class CitaSeleccionada : TabbedPage
{
	public CitaSeleccionada(CitaViewModel vm)
	{
		InitializeComponent();


		var tab = this as TabbedPage;

		tab.Children.Add(new NavigationPage(new DetallesCita(vm)));
		tab.Children.Add(new NavigationPage(new Localizar()));
	}
}