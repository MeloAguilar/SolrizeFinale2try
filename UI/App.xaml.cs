namespace UI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage();
		MainPage.Navigation.PushAsync(new Views.Login());
	}
}
