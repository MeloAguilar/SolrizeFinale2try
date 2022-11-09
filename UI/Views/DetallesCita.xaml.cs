using UI.ViewModels;

namespace UI.Views;

public partial class DetallesCita : ContentPage
{
	CitaViewModel vm;
	public DetallesCita(CitaViewModel model)
	{

		InitializeComponent();

		//Instancio el viewModel y se lo envio a la vista
		vm = model;
		Detalles.BindingContext = vm;

	}
}