using Android.Graphics.Drawables.Shapes;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.HotReload;
using UI.ViewModels;

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


		ntrNota.Placeholder = "Pipopipo pipo";

		containerNotas.Add(ntrNota);
	}



	private async void btnNota_Clicked(object sender, EventArgs e)
	{
		//Este boton debe recoger una nota y añadirla al viewmodel que le llega
		//Pero vamos a hacer que se genere una nota.

		


		bool answer = await DisplayAlert("Guardar Imagen", "¿Estás seguro de que quieres incluir esta imagen en el informe?", "Si", "No");
		if (answer)
		{
			//Declaro la cantidad de notas para poder enumerarlas 
			var cantidadNotas = citaVM.Observaciones.Count();
			//Instancio un rectangulo con las esquinas redondeadas para 
			//darle la forme al Border
			var rectangulo = new RoundRectangle();
			var radioRectangulo = new CornerRadius(40, 40, 40, 40);
			rectangulo.CornerRadius = radioRectangulo;
			//Declaro el label que contendrá el nombre de la nota y la nota
			var lblTitulo = new Label();
			var lblNota = new Label();
			
			//Establezco las propiedades del label que contendrá el titulo de la nota
			lblTitulo.Text = "Nota " + cantidadNotas;
			lblTitulo.FontSize=15;
			lblTitulo.FontAttributes = FontAttributes.Bold;

			//declaro el layout para poder poner el borde al rededor de ambos labels
			var flex = new FlexLayout()
			{
				Direction = Microsoft.Maui.Layouts.FlexDirection.Column,
				JustifyContent = Microsoft.Maui.Layouts.FlexJustify.SpaceAround
			};
			//Añado los labels al flexLayout

			var btn = new Button();
			btn.Text = "-";
			btn.FontAttributes = FontAttributes.Bold;
			btn.FontSize=22;
			btn.Clicked += btnQuitarNota_Clicked;
			

			//Declaro el borde para dar estética
			var border = new Border
			{
				Content = flex,
				Padding = 30,
				StrokeShape = rectangulo,
				BackgroundColor = Colors.DimGray,
				MaximumHeightRequest = 200
				
			};
			flex.Children.Add(lblTitulo);
			flex.Children.Add(lblNota);
			citaVM.Observaciones.Add(ntrNota.Text);
			containerNotas.Children.Add(border);
			
			//Añado otra nota
			ntrNota = new Entry();
			containerNotas.Children.Add(ntrNota);
			


		}

		

	}
	private async void btnQuitarNota_Clicked(object sender, EventArgs e)
	{

	}

}