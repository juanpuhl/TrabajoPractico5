namespace AppFakeStore.Views;

using Microsoft.Maui.Controls;

public partial class AcercaPage : ContentPage
{
	public AcercaPage()
	{
		InitializeComponent();
	}

    private void BtnVolver_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage()); // Regresar a la vista anterior
    }
    private void BtnLlamar_Clicked(object sender, EventArgs e)
    {
        string phoneNumber = "+5492954222222"; // Reemplaza con el número
        PhoneDialer.Default.Open(phoneNumber);
    }


    private async void BtnMail_Clicked(object sender, EventArgs e)
    {
        var message = new EmailMessage
        {
            Subject = "Asunto del correo",
            Body = "Me gustaria ponerme en contacto contigo: ",
            To = new List<string> { "juanjuan@gmail.com" } // Dirección de correo del destinatario
        };

        await Email.ComposeAsync(message);
    }
}