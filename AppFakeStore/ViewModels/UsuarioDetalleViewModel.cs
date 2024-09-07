using AppFakeStore.Models;
using AppFakeStore.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppFakeStore.ViewModels
{
    public partial class UsuarioDetalleViewModel : BaseViewModel
    {
        private readonly IUsuarioService _usuarioService;

        [ObservableProperty]
        Usuario usuario;

        public UsuarioDetalleViewModel(IUsuarioService usuarioService)
        {
            Title = "Detalle de Usuario";
            _usuarioService = usuarioService;

        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async Task LoadUserDetailsAsync(int userId)
        {

            Usuario = await _usuarioService.GetUsuarioByIdAsync(userId);

           
        }

        


    }
}
