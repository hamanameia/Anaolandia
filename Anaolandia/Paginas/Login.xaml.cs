using Microsoft.Maui.Controls.PlatformConfiguration;

namespace Anaolandia.Paginas;

public partial class Login : ContentPage
{
	public Login()
	{

        InitializeComponent();


    }

    private async void naologin_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Cadastro());

    }
    private async void Entrar_Tapped(object sender, EventArgs e)
    {
        string nome = txtnome.Text;
        string senha = txtsenha.Text;

        if (!string.IsNullOrWhiteSpace(nome) && !string.IsNullOrWhiteSpace(senha))
        {
            var usuario = await App.BancoDados.UsuarioDataTable.ObtemUsuario(nome, senha);

            if (usuario != null)
            {
                await Navigation.PushAsync(new Home());
                App.Usuario = usuario;
            }
            else
            {
                await DisplayAlert("Erro", "Usuário ou senha não combinam.", "OK");
                return;
            }
        }
        else
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                await DisplayAlert("Erro", "Escreva o seu Nome.", "OK");
            }
            else if (string.IsNullOrWhiteSpace(senha))
            {
                await DisplayAlert("Erro", "Escreva sua Senha.", "OK");
            }
        }
    }


}