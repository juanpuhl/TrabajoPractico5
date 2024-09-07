using AppFakeStore.Views;
using CommunityToolkit.Mvvm.Input;

namespace AppFakeStore.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    public MainViewModel()
    {
        Title = "ITES - Demo MVVM";
    }

    [RelayCommand]
    public async Task GoToProductoLista()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new ProductoListaPage());
    }

    [RelayCommand]
    public async Task GoToUsuarioLista()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new UsuarioListaPage());
    }



    [RelayCommand]
    public async Task GoToAcerca()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new AcercaPage());
    }

    [RelayCommand]
    public async Task Exit()
    {
        bool answer = await Application.Current.MainPage.DisplayAlert("Salir", "¿Desea terminar la sesión y salir?", "Aceptar", "Cancelar");

        if (answer) // Si el usuario selecciona "Aceptar"
        {
            
            // Navegar a la página de inicio de sesión
            await Application.Current.MainPage.Navigation.PopToRootAsync(); // Regresa a la página raíz
            await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new LoginPage())); // Navega a la página de inicio de sesión
        }
    }
}
