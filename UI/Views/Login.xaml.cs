namespace UI.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}
	private void btnInicio_Clicked(object sender, EventArgs e)
	{
		
		if (txtUser.Text is not null && txtPass.Text is not null)
		{
			if (!(txtPass.Text.Equals("") || txtUser.Text.Equals("")))
			{
				
				Navigation.PushAsync(new NavigationPage(new Citas()));
			}
		}
	}
}