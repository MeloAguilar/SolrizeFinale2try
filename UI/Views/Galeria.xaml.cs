using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using System.Text.Json;
using UI.ViewModels;

namespace UI.Views;




public partial class Galeria : ContentPage
{
	HttpClient httpClient;
	JsonSerializerOptions serializerOptions;
	ImageList imageList;

	class ImageList
	{
		public List<string> Photos { get; set; }
	}

	CitaViewModel cita;



	public Galeria(CitaViewModel citaVM)
	{
		//Instancio el viewModel y la lista de imagenes
		cita = citaVM;
		imageList = new ImageList();
		InitializeComponent();
		httpClient = new HttpClient();
		serializerOptions = new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase
		};

		LoadBitmapCollection();
	}
	async void LoadBitmapCollection()
	{
		try
		{
			Uri uri = new Uri("https://raw.githubusercontent.com/xamarin/docs-archive/master/Images/stock/small/stock.json");

			HttpResponseMessage response = await httpClient.GetAsync(uri);
			if (response.IsSuccessStatusCode)
			{
				string content = await response.Content.ReadAsStringAsync();
				imageList = JsonSerializer.Deserialize<ImageList>(content, serializerOptions);

				//Creamos un objeto imagen para cada Bitmap
				foreach (string photoUri in imageList.Photos)
				{
					ImageButton image = new ImageButton
					{
						Source = ImageSource.FromUri(new Uri(photoUri)),
						HeightRequest = 100,
						WidthRequest = 100,
						
					};

					image.Clicked+= OnImageClicked;
					
					containerPrincipal.Children.Add(image);
				}
			}
		}
		catch
		{
			containerPrincipal.Children.Add(new Label
			{
				Text = "No se puede acceder a la lista de fotos."
			});
		}
		indicadorActividad.IsRunning = false;
		indicadorActividad.IsVisible = false;
	}



	/// <summary>
	/// Método que se encarga de abrir la camara del dispositivo,
	/// espera a que el usuario tome la foto y le pregunta si desea introducirla en su almacenamiento,
	/// para posteriormente, almacenarla o no, segun diga el usuario
	/// 
	/// 
	/// </summary>
	public async void TakePhoto()
	{
		if (MediaPicker.Default.IsCaptureSupported)
		{
			FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
		
			if (photo != null)
			{
				//Recojo el path de el archivo, que se encontrará en la caché 
				string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

				//Monto la imagen
				ImageButton image = new ImageButton
				{
					Source = ImageSource.FromFile(localFilePath),
					HeightRequest = 100,
					WidthRequest = 100
				};

				//Preguntamos si se quiere añadir la foto
				bool answer = await DisplayAlert("Guardar Imagen", "¿Estás seguro de que quieres incluir esta imagen en el informe?", "Si", "No");



				if (answer)
				{
					//Añadimos la foto, tanto al container como a nuestro viewModel
					containerPrincipal.Children.Add(image);
					cita.Imagenes.Add(localFilePath);

					//Aqui se guarda la foto en la memoria interna
					using Stream sourceStream = await photo.OpenReadAsync();
					using FileStream localFileStream = File.OpenWrite(localFilePath);

					await sourceStream.CopyToAsync(localFileStream);
				}

			}
		}
	}



	/// <summary>
	/// Método que solo se encargará de llamar al método que abre la camara y toma fotos
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void Button_Clicked(object sender, EventArgs e)
	{
		TakePhoto();
	}

	async void OnImageClicked(object sender, EventArgs e)
	{
		bool answer = await DisplayAlert("Guardar Imagen", "¿Estás seguro de que quieres incluir esta imagen en el informe?", "Si", "No");
		if (answer)
		{
			//No he descubierto como sacar la foto del evento
			//Aqui debería añadirse la foto a las imagenes del informe


		}
	}

}