using Android.Graphics;
using Android.Graphics.Drawables.Shapes;
using Java.Util;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.HotReload;
using UI.ViewModels;
using Color = Microsoft.Maui.Graphics.Color;

namespace UI.Views;

public partial class Notas : ContentPage
{
	Entry ntrNota;
	CitaViewModel citaVM;

	public Notas(CitaViewModel vm)
	{
		InitializeComponent();
		citaVM = vm;
		ntrNota = new Entry();

		var bordeEntry = new Border();
		ntrNota.Placeholder = "Escribe aqu?...";
		var rectangulo = new RoundRectangle();
		var radioRectangulo = new CornerRadius(40, 40, 40, 40);
		rectangulo.CornerRadius=radioRectangulo;
		bordeEntry.Padding=9;
		bordeEntry.StrokeShape = rectangulo;
		bordeEntry.Content = ntrNota;
		bordeEntry.BackgroundColor = Colors.Transparent;
		containerNotas.Add(bordeEntry);
		ntrNota.Text = "nop"; 
	}



	private async void btnNota_Clicked(object sender, EventArgs e)
	{
		//Este boton debe recoger una nota y a?adirla al viewmodel que le llega
		//Pero vamos a hacer que se genere una nota.

		


		bool answer = await DisplayAlert("Guardar Nota", "?Est?s seguro de que quieres incluir esta imagen en el informe?", "Si", "No");
		if (answer)
		{
			//Declaro la cantidad de notas para poder enumerarlas 
			var cantidadNotas = citaVM.Observaciones.Count();
			//Instancio un rectangulo con las esquinas redondeadas para 
			//darle la forme al Border
			var rectangulo = new RoundRectangle();
			var radioRectangulo = new CornerRadius(40, 40, 40, 40);
			rectangulo.CornerRadius = radioRectangulo;
			//Declaro el label que contendr? el nombre de la nota y la nota
			var lblTitulo = new Label();
			var lblNota = new Label();
			
			//Establezco las propiedades del label que contendr? el titulo de la nota
			lblTitulo.Text = "Nota " + ++cantidadNotas;
			lblTitulo.FontSize=15;
			lblTitulo.FontAttributes = FontAttributes.Bold;

			//declaro el layout para poder poner el borde al rededor de ambos labels
			var flex = new FlexLayout()
			{
				Direction = Microsoft.Maui.Layouts.FlexDirection.Column,
				JustifyContent = Microsoft.Maui.Layouts.FlexJustify.SpaceAround
			};
			//A?ado los labels al flexLayout


			//Genero el boton que servir? para eliminar la nota si se precisa
			var btn = new Button();
			btn.Text = "-";
			btn.Background = Colors.Black;
			btn.TextColor = Color.FromArgb("#EFF1ED");
			btn.WidthRequest=50;
			btn.FontAttributes = FontAttributes.Bold;
			btn.FontSize=22;

			btn.Clicked += btnQuitarNota_Clicked;
			flex.Add(btn);

			var scroll = new ScrollView()
			{
				Content = flex
			};
			//Declaro el borde para dar est?tica
			var border = new Border
			{
				Content = flex,
				Padding = 30,
				StrokeShape = rectangulo,
				BackgroundColor = Color.FromArgb("#EFF1ED"),
				MaximumHeightRequest = 200
				
			};
			lblNota.Text = ntrNota.Text;
			flex.Children.Add(lblTitulo);
			flex.Children.Add(lblNota);
			citaVM.Observaciones.Add(ntrNota.Text);
			containerNotas.Children.Add(border);
			
			
			


		}

		

	}
	private async void btnQuitarNota_Clicked(object sender, EventArgs e)
	{

		//Boton que deberia quitar las notas de la vista
		//Deberia recoger el boton que la envia y eliminar de la vista la
		//nota necesaria
	}

}