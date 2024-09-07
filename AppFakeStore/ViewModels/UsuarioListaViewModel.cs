﻿using AppFakeStore.Models;
using AppFakeStore.Services;
using AppFakeStore.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AppFakeStore.ViewModels;

public partial class UsuarioListaViewModel : BaseViewModel
{
    public ObservableCollection<Usuario> Usuarios { get; } = new();

    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    Usuario usuarioSeleccionado;

    IUsuarioService _usuarioService;


    public UsuarioListaViewModel(IUsuarioService usuarioService)
    {
        Title = "Lista de Usuarios";
        _usuarioService = usuarioService;
    }

    [RelayCommand]
    private async Task GetUsuariosAsync()
    {
        if (!IsBusy)
        {
            try
            {
                IsBusy = true;

                // consultamos lista de usuarios
                var usuarios = await _usuarioService.GetUsersAsync();

                if (usuarios != null)
                {
                    if (Usuarios.Count != 0)
                        Usuarios.Clear();

                    foreach (var usuario in usuarios)
                        Usuarios.Add(usuario);
                }

                IsBusy = false;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error!", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = false;
            }

        }
    }

    [RelayCommand]
    private async Task GoToDetail()
    {
        if (usuarioSeleccionado == null)
        {
            return;
        }

        await Application.Current.MainPage.Navigation.PushAsync(new UsuarioDetallePage(usuarioSeleccionado.Id), true);
    }

}
