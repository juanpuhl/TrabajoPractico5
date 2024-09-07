using AppFakeStore.Models;
using AppFakeStore.ViewModels;
using AppFakeStore.Services;
namespace AppFakeStore.Views
{
    public partial class UsuarioDetallePage : ContentPage
    {
        private readonly UsuarioDetalleViewModel _viewModel;

        public UsuarioDetallePage(int userId)
        {
            InitializeComponent();
            //UsuarioDetalleViewModel vm = new UsuarioDetalleViewModel();
            //this.BindingContext = vm;
            //vm.Usuario = usuario;

            var usuarioService = new UsuarioService(); // Asegúrate de usar tu método de inyección de dependencias si lo tienes
            _viewModel = new UsuarioDetalleViewModel(usuarioService);
            BindingContext = _viewModel;
            _viewModel.LoadUserDetailsAsync(userId);



        }
    }
}
