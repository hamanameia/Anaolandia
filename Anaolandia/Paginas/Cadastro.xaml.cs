using Anaolandia.Model;

namespace Anaolandia.Paginas;

public partial class Cadastro : ContentPage
{

    Usuario _usuario;
    public Cadastro()
    {
        _usuario = new Usuario();
        this.BindingContext = _usuario; 
        InitializeComponent();
    }

    private async void Cadastrar_Tapped(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(_usuario.Cartao) || string.IsNullOrEmpty(_usuario.Senha) || string.IsNullOrEmpty(_usuario.Nome))
        {
            await DisplayAlert("Erro", "Preencha seus Dados.", "Fechar");
            return;
        }
        if (_usuario.Cartao.Length != 16)
        {
            await DisplayAlert("Erro", "Passa o Número Ai.", "Fechar");
            return;
        }
        
        var cadastro = await App.BancoDados.UsuarioDataTable.SalvarUsuario(_usuario);

        if (cadastro > 0)
        {
            await DisplayAlert("Sucesso", "Usuário cadastrado.", "Fechar");
            await Navigation.PopAsync();
        }
    }

    private async void jalogin_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Login());

    }

}