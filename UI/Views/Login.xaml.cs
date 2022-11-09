namespace UI.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
	private void btnInicio_Clicked(object sender, EventArgs e)
	{
		
		//Si el texto que nos llega de txPass y txtUser no es null
		if (txtUser.Text is not null && txtPass.Text is not null)
		{
			//Si tampoco est�n vac�os
			if (!(txtPass.Text.Equals("") || txtUser.Text.Equals("")))
			{
				//Nos movemos a la p�gina de citas
				Navigation.PushAsync(new NavigationPage(new Citas()));
			}
		}
		else
		{
			//Si no, muestro un mensaje 
			DisplayAlert("Fallo en Log-in", "Debe introducir un usuario y contrase�a", "vale");
			
		}
	}
}