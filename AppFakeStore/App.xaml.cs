using AppFakeStore.Services;
using AppFakeStore.ViewModels;
using AppFakeStore.Views;

namespace AppFakeStore
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new AppShell();

            // Configuración del servicio de usuario
            //var usuarioService = new UsuarioService();


           
           //MainPage = new NavigationPage(new MainPage());
            MainPage = new NavigationPage(new MainPage());
            //MainPage = new NavigationPage(new MainPage());
           ShowLoginPage();
        }

       private async void ShowLoginPage()
        {
            await MainPage.Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
        }
    }
}
