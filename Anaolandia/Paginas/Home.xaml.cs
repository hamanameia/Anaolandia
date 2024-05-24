namespace Anaolandia.Paginas;

public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();
	}

    private async void Home_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Home());
    }
    private async void Sucesso_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sucesso());
    }
    private async void Lojinha_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Lojinha());
    }
    private async void Usuario_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PaginaUsuario());
    }
}