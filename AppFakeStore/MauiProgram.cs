using AppFakeStore.Services;
using AppFakeStore.ViewModels;
using AppFakeStore.Views;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace AppFakeStore
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                 .UseSkiaSharp() //para usa SkiaSharp
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialDesignIcons");
                    fonts.AddFont("fasolid900.ttf", "Fasolid900");
                    fonts.AddFont("HelvChildren.ttf", "HelvChildren");
                    fonts.AddFont("GothamBold.ttf", "GothamBold");
                    fonts.AddFont("FontAwesomeSolid900.otf", "AwesomeSolid");

                    
                });

            
            builder.Services.AddSingleton<IProductoService, ProductoService>();
            builder.Services.AddTransient<ProductoListaViewModel>();
            builder.Services.AddTransient<ProductoListaPage>();

            builder.Services.AddSingleton<ILoginService, LoginService>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<LoginPage>();



            builder.Services.AddSingleton<IUsuarioService, UsuarioService>();
            builder.Services.AddTransient<UsuarioListaViewModel>();
            builder.Services.AddTransient<UsuarioListaPage>();
            builder.Services.AddTransient<UsuarioDetalleViewModel>();
            builder.Services.AddTransient<UsuarioDetallePage>();
  
           

           
          

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
