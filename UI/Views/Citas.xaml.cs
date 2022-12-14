using DAL.Listas;
using Entities;
using System.Collections.ObjectModel;
using UI.ViewModels;


namespace UI.Views;

public partial class Citas : ContentPage
{
	ListadoPersonas dal;

	public Citas()
	{

		InitializeComponent();
		//Genero la lista de mis objetos necesarios
		ObservableCollection<CitaViewModel> cvm = new ObservableCollection<CitaViewModel>();


		


		//Le digo a la DAL que genere la lista y me la devuelva
		dal = new ListadoPersonas();
		var list = dal.getListadoCompletoPersonas();

		//Convierto la lista en un ObservableCollection de CItaModel
		int minutos = 0;
		foreach (var item in list)
		{
			minutos+=45;
			cvm.Add(new CitaViewModel(new clsPersona(item.Nombre, item.Apellidos, item.Direccion, item.Telefono), DateTime.Now.AddMinutes(minutos)));
			
		}



		//Le digo al Collection view cual sera su modelo de datos
		ClientesListView.ItemsSource = cvm;
	}


	/// <summary>
	/// M?todo que se encarga de recoger la seleccion de cliente y enviarla a la pagina "Detalles Cita"
	/// </summary>
	/// <pre>Nada</pre>
	/// <post>Nada</post>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private async void ClientesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		//Recojo el cliente seleccionado del collectionView
		CitaViewModel clie = e.CurrentSelection[0] as CitaViewModel;

		//Envio al usuario a la pagina de esa Cita en concreto
		await Navigation.PushAsync(new NavigationPage(new CitaSeleccionada(clie)));


	}


	/// <summary>
	/// Sobreescribe el boton back para modificar el navigationStack y reinicia 
	/// la
	/// </summary>
	/// <returns></returns>
	protected override bool OnBackButtonPressed()
	{

		//Pongo la pagina de inicio y borro la anterior
		Navigation.InsertPageBefore(new Login(), Navigation.NavigationStack.First());
		return base.OnBackButtonPressed();


	}
}