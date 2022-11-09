using UI.ViewModels;

namespace UI.Views;

public partial class DetallesCita : ContentPage
{
	CitaViewModel vm;
	public DetallesCita(CitaViewModel model)
	{

		InitializeComponent();


		vm = model;
		Detalles.BindingContext = vm;
	}
}