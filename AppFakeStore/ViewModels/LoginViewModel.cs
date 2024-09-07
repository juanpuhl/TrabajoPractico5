using AppFakeStore.Models;
using AppFakeStore.Services;
using AppFakeStore.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace AppFakeStore.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        private readonly ILoginService loginService;

        public LoginViewModel()
        {
            Title = "Login";
            loginService = new LoginService(); // Crear una instancia de LoginService
        }

        [RelayCommand]
        private async Task Login()
        {
            // Validar que los campos no est�n vac�os
            if (string.IsNullOrWhiteSpace(Username))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El nombre de usuario es obligatorio.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "La contrase�a es obligatoria.", "OK");
                return;
            }

            // L�gica para el login
            var loginModel = new Login
            {
                Username = Username,
                Password = Password
            };

            // Aqu� puedes llamar a tu servicio de login para autenticar al usuario
            var token = await loginService.AuthenticateAsync(loginModel);

            if (!string.IsNullOrEmpty(token))
            {
                // Validar el token
                //bool isValidToken = await loginService.ValidateTokenAsync(token);

                //if (isValidToken)
                //{
                // Guardar el token y navegar a la p�gina principal
                ResetFields();
                await Application.Current.MainPage.Navigation.PopModalAsync();

                //}
                //else
                //{
                // Mostrar mensaje de error si el token no es v�lido
                //await Application.Current.MainPage.DisplayAlert("Error", "Token inv�lido", "OK");
                //}
            }
            else
            {
                // Mostrar mensaje de error
                await Application.Current.MainPage.DisplayAlert("Error", "Login fallido", "OK");
            }
        }

        private void ResetFields()
        {
            Username = string.Empty;
            Password = string.Empty;
        }
    }
}