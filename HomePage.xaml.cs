namespace AppTuLibro;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private async void OnLibrosClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

    private async void OnVenderCliked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//SubirPage");
    }
}